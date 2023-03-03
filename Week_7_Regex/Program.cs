using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
/*
 * Clark Comstock
 * 3/03/2023
 * Week 7 File Reading and Regex Program
 */

namespace Week_7_Regex
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //beginning of program, asks for user input
            Console.WriteLine("Please enter a file pathway:");
            //explains the preset text file that comes with this project folder
            Console.WriteLine("(For an example, there is a file labeled 'test.txt' in this project, find it and use that pathway)");

            //gets the literal string from the user
            string input = @"" + Console.ReadLine();
            //checks the regex, designed specifically for an extention of '(uppercase letter):\(words and certain characters)\(blank).txt
            var check = new Regex(@"[A-Z]\:(\\[A-Za-z0-9 _&]+)+\.[t][x][t]");
            if (check.IsMatch(input))
            {
                Console.WriteLine("Valid pathway");
                //tries to open the file
                try
                {
                    string path = input;
                    StreamReader sr = new StreamReader(path);
                    //opens the file and reads it
                    Console.WriteLine("Opening file...");
                    string line;
                    do
                    {
                        //displays each line of the file to the user
                        line = sr.ReadLine();
                        Console.WriteLine("- " + line);
                    }while (line != null);

                    //-------------------------------------------------------------
                    //used the web for these lines of code, trying to count the words was a pain
                    int count = 0;
                    //puts the file into reader mode. I don't know if it's entirely neccesary but I'm too afraid to delete it
                    System.IO.StreamReader file = new System.IO.StreamReader(input);

                    //Gets each line till end of file is reached  
                    while ((line = file.ReadLine()) != null)
                    {
                        //Splits each line into words  
                        String[] words = line.Split(' ');
                        //Counts each word  
                        count = count + words.Length;
                    }
                    //end of web usage
                    //---------------------------------------------------------------
                    //word count
                    Console.WriteLine("The total number of words in the file are: " + count);

                    sr.Close();
                }
                //if the try fails, tells the user the entered pathway has no file
                catch
                {
                    Console.WriteLine("That file does not exist");
                }
            }
            //if the pathway entered is incorrect, displays this message
            else
            {
                Console.WriteLine("Invalid Pathway");
            }
        }
    }
}