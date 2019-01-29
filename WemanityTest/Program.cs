using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WemanityTest.DAL;
using WemanityTest.Model;

namespace WemanityTest
{
    class Program
    {
        private  const string Title = "******* Wemanity Quiz: Find out the position of your colleages *************";
        private const string Question = "Do you want to read the notes before beginning the quiz?";
        private const string FilePath = "\\Resources\\ReadMe.txt";
        private const string Choice = "Find the postion of: ";
        private const string Warning = "Please choose a value between 1 and 3";

        static void Main(string[] args)
        {
            Console.WriteLine(Title);
            Console.WriteLine(string.Empty);
            var confirmation = Question;
            PromptReadNotes(confirmation);


            Repository repository = new Repository();
            Dictionary<string, string> directory = repository.Directory;
            var  points =0;

             foreach(var item in directory)
             {
                PromptQuestion(item.Key);
                var answer = Console.ReadLine();
                while (!checkAnswer(answer) )  {

                    Console.WriteLine(Warning);
                    PromptQuestion(item.Key);
                    answer = Console.ReadLine();
                }
                               
               FindPosition(item.Key, Int32.Parse(answer), directory, ref points);
               Console.WriteLine("Total points: " + points);
               Console.ReadLine();
                
               
            }
            Console.WriteLine("Your total score is: "+points+" /"+ directory.Count);
            Console.ReadLine();
        }


        private static void FindPosition(string employeename,int supposedposition ,Dictionary<string, string> directory,ref int points)
        {
            var nammedrealposition = directory.Where(u => u.Key == employeename).FirstOrDefault().Value;
            var intrealposition = (int)((Employee.Position)Enum.Parse(typeof(Employee.Position), nammedrealposition));       

            if (intrealposition == supposedposition)
            {
                UpdateGain(ref  points);
                Console.WriteLine("Correct!");
            }              
            else
                Console.WriteLine("Wrong.");

        }

        private static bool  checkAnswer(string answer)
        {

            return answer != "1" && answer != "2" && answer != "3" ? false : true ;
        }


        private static void UpdateGain(ref int points)
        {
            points++;
        }

        private static void PromptQuestion(string name)
        {
            Console.Write($"{ Choice + name} [1] " + Employee.Position.Agile + "/[2]" + Employee.Position.Dev + "/[3]" + Employee.Position.Facilitator);
        }


        private static void PromptReadNotes(string title)
        {
            Console.Write($"{ title } [y/n] ");
            var response = Console.ReadLine();
            if (response == "y")
                ReadRules();                     
        }

        private static void ReadRules()
        {
            var FileFullPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + FilePath;
            var output= string.Empty;
            try
            {
                output  = File.ReadAllText(FileFullPath);
            }
            catch(Exception e)
            {
                output = "Sorry, the File is not avalaible for the moment " + e.Message;
            }                   
            Console.WriteLine(output);            
        }
    }
}
