using System;
using System.Collections.Generic;
using System.IO;
namespace Task_1
{
    class Program
    {
        static string path = "../../../t.txt";
        static void Main()
        {
        Dictionary<string, string> control = new Dictionary<string, string>();
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            else
            {
                        string enter = "enter";
                        string exit = "exit";
                    string line;
                using(StreamReader reader=new StreamReader(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(enter))
                        {
                            int index = line.Length - enter.Length-1;
                           line= line.Remove(index);
                            control.Add(line, enter);
                        }
                        if(line.Contains(exit))
                        {
                            int index = line.Length - exit.Length-1;
                            line=line.Remove(index);
                            control.Remove(line);
                        }
                    }
                }
            }
            string a;
            do
            {
                Console.WriteLine("For enter - type \"enter\"");
                Console.WriteLine("for exit -type\"exit\"");
                Console.WriteLine("For end -type \"end\"");
                a = Console.ReadLine().ToLower();
                a=a.Trim();
                {
                    if (a == "enter")
                    {
                        Console.WriteLine("Enter your ID number");
                        string ID = Console.ReadLine();
                        ID = ID.Trim();
                        if (control.ContainsKey(ID))
                        {
                            Console.WriteLine("You are already inside!?");
                        }
                        else
                        {
                            control.Add(ID, a);
                            File.AppendAllText(path, $"{ID} {a}\n");
                        }
                    }
                    if (a == "exit")
                    {
                        Console.WriteLine("Enter your ID number");
                        string ID = Console.ReadLine();
                        ID = ID.Trim();
                        if (!control.ContainsKey(ID))
                        {
                            Console.WriteLine("You are already outside!?");
                        }
                        else
                        {
                            File.AppendAllText(path, $"{ID} {a}\n");
                            control.Remove(ID);

                        }
                    }

                }
            }
            while (a != "end");
           



        }
    }
}
