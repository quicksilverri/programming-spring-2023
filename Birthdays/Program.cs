using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayManager("birthdays.txt");
        }

        public static Dictionary<string, Dictionary<string, int>> ReadBirthdaysFile(string path)
        {
            using(StreamReader file = new StreamReader(path)) 
            {
                var namesDict = new Dictionary<string, Dictionary<string, int>>(); 
                string ln; 

                while ((ln = file.ReadLine()) != null) 
                {
                    string[] words = ln.Split('	');
                    string name = words[1]; 
                    string bday = words[0]; 

                    string[] date = bday.Split('.'); 
                    string month = date[1]; 

                    var monthCodes = new string[] 
                    {
                        "01", "02", "03", "04", "05", "06", 
                        "07", "08", "09", "10", "11", "12"
                    }; 
                    
                    if(!(namesDict.ContainsKey(name)))
                    {
                        var months = new Dictionary<string, int>();
                        
                        foreach(string monthCode in monthCodes)
                        {
                            months.Add(monthCode, 0);
                        }
                        
                        namesDict.Add(name, months);
                    }
                    
                    namesDict[name][month] += 1;
                }
                
                file.Close(); 
                return namesDict;
            }
            
        }

        public static void PrintList(Dictionary<string, int> dict) 
        {
            Console.WriteLine("People with such a name were born in: "); 
            int counter = 0;

            foreach(var kv in dict) 
            {
                Console.WriteLine($"Month {kv.Key}: {kv.Value}");
                counter += kv.Value;
            }

            Console.WriteLine($"Total of {counter} people.");
            
        }

        public static void BirthdayManager(string path)
        {
            var namesDict = ReadBirthdaysFile(path);

            while(true)
            {
                Console.WriteLine("Please, input a name (if you want to exit, input 0): ");
                var name = Console.ReadLine();
                if(name == "0") break; 
                else 
                {
                    if(namesDict.ContainsKey(name)) PrintList(namesDict[name]); 
                    else Console.WriteLine("There are no people with such bday");
                }
            }
        }
    }
}
