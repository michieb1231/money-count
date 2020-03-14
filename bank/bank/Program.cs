using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bank
{
    class Program
    {
        // inital vars

        static double num;
        static double balance;
       // declaring a new stream writer
        static StreamWriter Input;
       // string contaning balance path
        static string fileName = @"balance.txt";
   
        static string lines;
        static bool requested = false;
        
        
       
    // methods
        public static  void addBalance()
        {
           // declares the stream writer
            Input = new StreamWriter(fileName);
           // converts the user input to an int 
            num = Convert.ToDouble(Console.ReadLine());
           // adds number to balance 
            balance = num + balance;
            Console.Clear();
          // writes the new balance to the file
            Input.WriteLine(string.Format("{0}",balance));
            Input.Close();
           
            Console.WriteLine("added " + num);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }

        public static void subtractBalance()
        {
            // same as "addBalance"
            Input = new StreamWriter(fileName);
            num = Convert.ToDouble(Console.ReadLine());
           //checks if there is enough money 
            if (num > balance)
            {
                Console.WriteLine("not enough funds");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            } else if (num <= balance) {
                balance = balance - num;
                Console.Clear();

                Input.WriteLine(string.Format("{0}", balance));
                Input.Close();
                Console.WriteLine("took out " + num);
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
            }
            Input.Close();
            Console.Clear();

        }





        public static void readBalance()
        {
            // makes a new stream reader
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            // reads the txt file for number
            lines = file.ReadLine();
            // checks if the user requested the method or the program
            if (requested == true)
            {
               //displays the value found in the txt file
                Console.Clear();
                Console.WriteLine("$"+lines);
                Console.WriteLine("\n press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            // intialises the text document as "balance"
            balance = Convert.ToDouble(lines);
            file.Close();
        }

        static void Main(string[] args)
        {
            // intialises balance
            readBalance();
           //main loop
            while (true)
            {
                Console.WriteLine("please input a command, for a list of commands type help");
               // user interaction in the form of commands
                string command = Console.ReadLine();
                // code that runs everything when its supposed to be ran 
                if (command.Equals("add-money"))
                {
                    Console.WriteLine("enter the amount of money you are putting in");
                    addBalance();
                    continue;
                }
                else if (command.Equals("take-money"))
                {
                    Console.WriteLine("enter the amount of money you are taking out");
                    subtractBalance();
                    continue;
                }
                else if (command.Equals("Balance"))
                {
                    requested = true;
                    readBalance();
                    continue;
                }else if (command.Equals("clear"))
                {
                    Console.Clear();

                }else if (command.Equals("exit"))
                {
                    Console.WriteLine("closing...");
                    System.Environment.Exit(1);
                    

                }
                
                else if (command.Equals("help"))
                {
                    Console.WriteLine("1. add-money \n2. take-money \n3. Balance - reads your balance \n4. clear - clears console \n5. exit - closes the program");

                }
                else
                {
                    Console.WriteLine("command not found, type 'help' for a list of commands");
                    continue;

                }

            }

        }
    }
}
