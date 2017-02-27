using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammar_LL1
{
    class Program
    {   
        Stack<string> stack = new Stack<string>();
        string[] input = new string[30];
        string get_input = "";
        string TS = "";
        string NTS = "";
        string[,] symbol_tbl = new string[,] 
        { 
           {" ","(",")",";","x","$"},

           {"S","a"," "," "," ", " "},

           {"A","b"," "," ","b", " "},
        
           {"B"," ","d","c"," ", " "},

           {"C","f"," "," ","e", " "},
     }; 
//////////////////////////////////////////////
        public bool ISterminal(string str)
        {
            for (int i = 1; i < 5; i++)
            {
                if (str == symbol_tbl[i,0])
                { return true; }
            }return false;
        }
        //////////////////////////////////////////////
        public int IndexTS(string str)
        {
            for (int i = 1; i < 5; i++)
            {
                if (str == symbol_tbl[i, 0])
                { return i; }

            } return 0;
        }

        //////////////////////////////////////////////
        public int IndexNTS(string str)
        {
            for (int i = 1; i < 6; i++)
            {
                if (str == symbol_tbl[0, i])
                { return i; }

            } return 0;
        
        }
        //////////////////////////////////////////////
        public void display()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 6; y++)
                { Console.Write(symbol_tbl[x, y]); }
                Console.WriteLine();
            }
        }
        //////////////////////////////////////////////
public void read()
        {
            get_input = Console.ReadLine();
            get_input += " ";
            get_input += "$";
            
            
            input =get_input.Split(' ');
        }
//////////////////////////////////////////////
public void P_algo()
        {
            int counter = 0;
            int i = 0;
            int ii= 0;
            string choice = "";

            stack.Push("S");
            while (stack.Count >0)
            {
                TS = stack.Pop();
                NTS = input[counter];
                if (ISterminal(TS))
                {
                    i = IndexTS(TS);
                    ii = IndexNTS(NTS);
                    choice = symbol_tbl[i, ii];

                    switch (choice)
                    {
                        case "a":
                            {
                                stack.Push(")");
                                stack.Push("A");
                                stack.Push("(");
                                break;
                            }
                        case "b":
                            {
                                stack.Push("B");
                                stack.Push("C");
                                break;
                            }
                        case "c":
                            {
                                stack.Push("A");
                                stack.Push(";");
                                break;
                            }
                        case "d":
                            {

                                break;
                            }
                        case "e":
                            {
                                stack.Push("x");
                                break;
                            }
                        case "f":
                            {
                                stack.Push("S");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("══════════════");
                                Console.WriteLine("Input Rejected");
                                return;
                            }
                    }
                }
                else if (NTS==TS && NTS!="$")
                {
                   
                    counter++;
                }
                else if (TS == "$" && NTS == "$")
                {
                    Console.WriteLine("═══════════════════════");
                    Console.WriteLine("Input Sequence accepted");
                    Console.WriteLine("═══════════════════════");
                }
                else
                {
                    Console.WriteLine("══════════════");
                    Console.WriteLine("Input Rejected"); }
            }
        }
//////////////////////////////////////////////        
 static void Main()
        {
            char chr = '0'; 
    do
    {
            Program obj = new Program();
            obj.stack.Push("$");
            int choice;
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("    ┌═══════════════════════════════════════════════════╖");
            Console.WriteLine("    │---------------------------------------------------║");
            Console.WriteLine("    │MAIN MENU FOR LL(1) PARSER IN COMPILER CONSTRUCTION║");
            Console.WriteLine("    │---------------------------------------------------║");
            Console.WriteLine("    ╘═══════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("Enter 1 to INPUT SEQUENCE");
            Console.WriteLine("ENTER 2 TO EXIT PROGRAM");
            Console.WriteLine("═══════════════════════");
try
  {  choice = int.Parse(Console.ReadLine());
  if (choice == 1)
  {
      Console.WriteLine("Enter input each separated by a space");
      obj.read();
      obj.P_algo();
  } if (choice == 2)
{ Environment.Exit(0); }
                        
                       
                        Console.Write("\nDo you want to continue: Enter y or n\n");
                        chr = char.Parse(Console.ReadLine());}
                        catch (Exception)
                                {  }
 } while (chr != 'n' && chr != 'N');
}       } 
    }
