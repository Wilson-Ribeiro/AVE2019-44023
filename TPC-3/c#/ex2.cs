using System;

public class ex2{
    public static void Main(){
        Console.Write(Foo("ababc"));
    }

    public static bool Foo(String msg){
        if (msg.Length!=1){
            if(msg[0]==msg[msg.Length-1]){
                if(msg.Length!=2){
                    Foo(msg.Substring(1,msg.Length-2));
                } else return true;
            }else return false;
        }
        return true;

    }
}