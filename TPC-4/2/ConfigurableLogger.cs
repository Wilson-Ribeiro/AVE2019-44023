using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public interface IGetter {
    string GetName();
    object GetValue(object target);
}
public class GetterField : IGetter{
    FieldInfo f; 
    public GetterField(FieldInfo f) { this.f = f;}
    public string GetName() { return f.Name; }
    public object GetValue(object target) {
        return f.GetValue(target);
    }
}
public class GetterMethod : IGetter{
    MethodInfo m;
    public GetterMethod(MethodInfo m) {this.m = m;}
    public string GetName() { return m.Name; }
    public object GetValue(object target) { 
        return m.Invoke(target, new object[0]);
    }
}
public class GetterProperty : IGetter{
    PropertyInfo p;
    public GetterProperty(PropertyInfo p) {this.p = p;}
    public string GetName() { return p.Name; }
    public object GetValue(object target) { 
        return p.GetValue(target);
    }
}

public class ConfigurableLogger {

    List<MethodInfo> configuration = new List<MethodInfo>();

    public void Log(object o) {
        Type t = o.GetType();
        if(t.IsArray) LogArray((IEnumerable) o);
        else {
            var getters = new List<IGetter>();
            foreach(MethodInfo m in configuration){
                getters.AddRange((List<IGetter>)m.Invoke(o,new object[]{t}));
            }
            LogObject(o, getters);
        }
    }
    
    public static List<IGetter> InitFields(Type t) {
        List<IGetter> l = new List<IGetter>();
        foreach(FieldInfo m in t.GetFields()) {
            l.Add(new GetterField(m));
        }
        return l;
    }
    public static List<IGetter> InitMethods(Type t) {
        List<IGetter> l = new List<IGetter>();
        foreach(MethodInfo m in t.GetMethods()) {
            if(m.ReturnType != typeof(void) && m.GetParameters().Length == 0) {
                l.Add(new GetterMethod(m));
            }
        }
        return l;
    }
    public static List<IGetter> InitProperties(Type t) {
        List<IGetter> l = new List<IGetter>();
        foreach(PropertyInfo p in t.GetProperties()) {
            l.Add(new GetterProperty(p));
        }
        return l;
    }
    
    public void LogArray(IEnumerable o) {
        Type elemType = o.GetType().GetElementType(); // Tipo dos elementos do Array
        var getters = new List<IGetter>();
            foreach(MethodInfo m in configuration){
                getters.AddRange((List<IGetter>)m.Invoke(o,new object[]{elemType}));
            }
        Console.WriteLine("Array of " + elemType.Name + "[");
        foreach(object item in o) LogObject(item, getters); // * 
        Console.WriteLine("]");
    }
    
    public void LogObject(object o, IEnumerable<IGetter> gs) {
        Type t = o.GetType();
        Console.Write(t.Name + "{");
        foreach(IGetter g in gs) {
            Console.Write(g.GetName() + ": ");
            Console.Write(g.GetValue(o) + ", ");
        }
        Console.WriteLine("}");
    }

    public void ReadFields(){
        Type t = this.GetType();
        configuration.Add(t.GetMethod("InitFields"));
    }
    public void ReadMethods(){
        Type t = this.GetType();
        configuration.Add(t.GetMethod("InitMethods"));
    }
    public void ReadProperties(){
        Type t = this.GetType();
        configuration.Add(t.GetMethod("InitProperties"));
    }
}