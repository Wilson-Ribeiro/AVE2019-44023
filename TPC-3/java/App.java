
import java.lang.reflect.*;

class A{}
class B extends A{}
class C extends B{
    public int x, y;
    public void Foo(){};
}

public class App{
    public static void main(String[] args){
        printBaseTypes("Ola");
        printBaseTypes(19);
        printBaseTypes(new C());
        //printBaseTypes(new System.IO.DirectoryInfo("."));

        printMembers(new C());
        printMethods(new C());
        printFields(new C());
    }
    public static void printMembers(Object obj){
        Class cls = obj.getClass();
        Method[] methods = cls.getMethods();
        Field[] flds = cls.getFields();

        System.out.print("Members: ");

        for(Method mtd : methods){
            System.out.print(mtd.getName() + " ");
        }
        for(Field fld : flds){
            System.out.print(fld.getName() + " ");
        }

        System.out.println();
    }
    public static void  printMethods(Object obj){
        Class cls = obj.getClass();
        Method[] methods = cls.getMethods();

        System.out.print("Methods: ");

        for(Method mtd : methods){
            System.out.print(mtd.getName() + " ");
        }
        System.out.println();
    }
    public static void printFields(Object obj){
        Class cls = obj.getClass();
        Field[] flds = cls.getFields();

        System.out.print("Fields: ");

        for(Field fld : flds){
            System.out.print(fld.getName() + " ");
        }

    
        System.out.println();
    }

    public static void printBaseTypes(Object obj){
        Class cls = obj.getClass();
        Object newObj = new Object();
        do{
            System.out.print(cls.getName() + " ");
            //PrintInterfaces(cls)
            cls = cls.getSuperclass();
        }while(cls != Object.class);
        System.out.println();
    }

}