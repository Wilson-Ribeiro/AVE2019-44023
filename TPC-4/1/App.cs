using System;

public class Student {
    int nr;
    string name;
    int group;
    string githubId;

    public Student(int nr, string name, int group, string githubId)
    {
        this.nr = nr;
        this.name = name;
        this.group = group;
        this.githubId = githubId;
    }
    
    public int Nr { get {return nr; } }
    public string Name { get {return name; } }
    public int Group { get {return group; } }
    public string GithubId { get {return githubId; } }

}

class Point{
    public readonly int x, y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public double Module{
        get{
            return Math.Sqrt(x*x + y*y);
        }
    }
    
}

class Account {
    public static readonly int CODE = 4342;
    public long balance;
    public Account(long b) { balance = b; }
}

class App {
    static void Main(){
        Point pt = new Point(7, 9);
        Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
        Student s2 = new Student(765864, "Maria El", 4677, "ma");
        
        Student[] classroom = {
            new Student(154134, "Ze Manel", 5243, "ze"),
            new Student(765864, "Maria El", 4677, "ma"),
            new Student(456757, "Antonias", 3153, "an"),
        };
        
        Account a = new Account(1300);
        Console.WriteLine(pt);
        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(a);

        
        Logger.Log(pt);
        Logger.Log(s1);
        Logger.Log(a);
        
        /* 
        ConfigurableLogger loggerFm = new ConfigurableLogger();
        loggerFm.ReadFields();
        loggerFm.ReadMethods();
        loggerFm.Log(s1);
        loggerFm.Log(s2);
        loggerFm.Log(pt);
        ConfigurableLogger loggerP = new ConfigurableLogger();
        loggerP.ReadProperties();
        loggerP.Log(s1);
        loggerP.Log(a);
        loggerP.Log(pt);
        */
    }
}







