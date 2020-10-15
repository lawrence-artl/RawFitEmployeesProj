using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Xml.Linq;


namespace employees
{
    class Program
    {
        public static Employee[] employee = new Employee[100];     //make array of employees
        public static int empIndex;                                //amount of employees in the array
        //static string[] employeesLines = new string[100];   //string of employee information

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                employee[i] = new Employee();               //must initialize all employees to set values
                //employeesLines[i] = employee[i].Name;       //put all employee names into string array
            }
            empIndex = openFile();
            Console.Clear();
            Console.WriteLine("Welcome to Raw Fitness St. George employee listing ver 1.0");
            drawLine();
            drawMenu();

        }

        static int openFile()
        {
            int empIndex;
            try
            {
                
                string[] input = File.ReadAllLines(@"C:\Users\dayar\Desktop\New folder\SaveFile.txt");
                
                int indexes = input.Length;
                indexes--;
                for (int i = 0; i < indexes; i++)
                {
                    employee[i].Fname = outputemp(input[i + 1], 1);
                    employee[i].Lname = outputemp(input[i + 1], 2);
                    employee[i].Empid = outputid(input[i + 1]);
                    //employee[i].Payrate = outputhours(input[i + 1], 1);
                    //employee[i].Hoursworked = outputhours(input[i + 1], 2);
                    
                }
                Int32.TryParse(input[0], out empIndex);
                Console.WriteLine(empIndex + " employees loaded.");
                Console.WriteLine("File Loaded"); Console.ReadLine();
                return empIndex;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found... Creating file.");
                string[] lines = new string[101];           //string must have 101 indexes for 1 number and 100 employees (0 - 101)
                lines[0] = "0";                             //index 0
                for (int i = 0; i < 100; i++)
                {
                    lines[i + 1] = employee[i].Fname + "!" + employee[i].Lname + "@" + employee[i].Empid + "#" + employee[i].Payrate + "$" +
                        employee[i].Hoursworked;    //indexes 1 - 101
                }
                System.IO.File.WriteAllLines(@"C:\Users\dayar\Desktop\New folder\SaveFile.txt", lines);
                Console.WriteLine("File Created"); Console.ReadLine();
                empIndex = 0;
                return empIndex;
            }
        }
        static void drawLine()
        {
            int window_width = Console.WindowWidth - 1;
            for (int i = 0; i < window_width; i++)
            {   Console.Write("-"); }
        }
        static void refreshPage()
        {
            Console.SetCursorPosition(0, Console.WindowTop + 10);
            //int currentLineCursor = Console.CursorTop;
            for (int i = Console.CursorTop; i < Console.WindowHeight; i++)
            {   Console.Write(new string(' ', Console.WindowWidth));    }
            Console.SetCursorPosition(0, Console.WindowTop + 10);
        }
        static void drawMenu()
        {
            Console.WriteLine("\nSelect an item below\n1: View employees\n2: Add an employee\n3: Edit an employee" +
                "\n4: Time clock calculator\n5: Save\n6: Exit");
            drawLine();
            itemSelect();
        }
        static void itemSelect()
        {
            refreshPage();
            int run = 1;
            do
            {
                string item = Console.ReadLine();
                int selection;
                if (!int.TryParse(item, out selection))
                {
                    refreshPage();
                    Console.WriteLine("That is not a valid selection");     Console.ReadLine();     run = 0;    //check for an integer
                    drawMenu();
                }
                else
                {
                    if (selection <= 0 || selection > 6)    //check for an integer within range
                    {
                        refreshPage();
                        Console.WriteLine("That is not a valid selection");
                        Console.ReadLine();
                        run = 0;
                        drawMenu();
                    }
                    else if (selection == 6)        //exit
                    {
                        refreshPage();
                        Console.WriteLine("Exiting... done. Press 'Enter' to close.");
                        run = 0;

                    }
                    else if (selection > 0 && selection < 6)    //check for the selection
                    {
                        switch (selection)
                        {
                            case 1: viewEmployees(); break;
                            case 2: addEmployee(); break;
                            case 3: deleteEmployee(); break;
                            case 4: timeClock(); break;
                            case 5: saveFile(); break;
                            default: break;
                        }
                        run = 0;
                        drawMenu();
                    }
                }

            } while (run == 1);
        }

        static string outputemp(string input, int b)
        {
            string output = "None";
            switch (b)
            {
                case 1:     //first name
                    {
                        int h = input.IndexOf("!");         //find index of ! in string
                        output = input.Substring(0, h); //create substring starting at zero, for length of 1 to index of !
                        break;
                    }
                case 2:     //last name
                    {
                        int h = input.IndexOf("!");         //find index of !
                        int j = input.IndexOf("@") - 1;     //find index of @, subtract 1 to get index of char immediately before @
                        output = input.Substring(h + 1, j - h);     //create substring from after !, for length of @ location minus ! location
                        
                        break;
                    }
                default:
                    break;
            }    




            return output;
        }

        static int outputid(string input)
        {
            int empid = 0;
            int h = input.IndexOf("@");
            string id = input.Substring(h + 1, 6);
            Int32.TryParse(id, out empid);
            return empid;
        }

        static double outputhours(string input, int b)
        {
            double hours = 0.0;

            switch (b)
            {
                case 1:
                    {

                        break;
                    }
                case 2:
                    {

                        break;
                    }
                default:
                    break;
            }

            return hours;
        }

        static void viewEmployees()
        {
            refreshPage();
            int empIndex;
            Console.WriteLine("View Employees...");

            string[] input = File.ReadAllLines(@"C:\Users\dayar\Desktop\New folder\SaveFile.txt");
            Int32.TryParse(input[0], out empIndex);
            Console.WriteLine("Number of Employees: " + empIndex);
            for (int i = 0; i < empIndex; i++)
                {
                Console.WriteLine(employee[i].Fname + " " + employee[i].Lname + " ID: " + employee[i].Empid);
                
                }
            
            
            Console.ReadLine(); refreshPage(); return;

        }
        static void addEmployee()
        {
            refreshPage();
            Console.WriteLine(empIndex);
            bool add = true;
            bool b = true;
            string[] lines = new string[101];        //string must have 101 indexes for 1 number and 100 employees (0 - 101)
            lines = File.ReadAllLines(@"C:\Users\dayar\Desktop\New folder\SaveFile.txt");
            Int32.TryParse(lines[0], out empIndex);
            int intid;

            do
            {
                Console.Write("Enter the employee's first name: "); string fname = Console.ReadLine();
                Console.Write("Enter the employee's last name: "); string lname = Console.ReadLine();

                do
                {
                    Console.Write("Enter a 6 digit ID number for the employee: ");
                    string empid = Console.ReadLine();
                    
                    
                    if (!Int32.TryParse(empid, out intid))
                        {
                        Console.WriteLine("That is not a valid selection, please enter a 6 digit integer.");
                        Console.ReadLine();
                        refreshPage();

                    }

                    else
                    {
                        if (intid < 100000 || intid > 999999)
                        {
                            Console.WriteLine("That is not a valid ID number, please enter a 6 digit integer.");
                            Console.ReadLine();
                            b = true;
                            refreshPage();
                        }
                        else if (intid >= 100000 && intid <= 999999)
                        {
                            employee[empIndex].Empid = intid;
                            b = false;
                        }
                        
                    }

                } while (b);
                

                empIndex++;
                employee[empIndex] = new Employee();
                employee[empIndex].Fname = fname;   Console.WriteLine(employee[empIndex].Fname);
                employee[empIndex].Lname = lname;   Console.WriteLine(employee[empIndex].Lname);
                employee[empIndex].Empid = intid;
                lines[0] = empIndex.ToString();
                lines[empIndex] = employee[empIndex].Fname + "!" + employee[empIndex].Lname + "@" + employee[empIndex].Empid + "#";
                Console.WriteLine("Would you like to add another employee? (y/n)");
                string response = Console.ReadLine();
                if (response.Equals("y") || response.Equals("Y"))
                {
                    refreshPage();
                }
                else
                {
                    add = false;
                }
                    
            } while (add);
            Console.WriteLine("Writing file..." + empIndex + " " + employee[empIndex].Fname + " " + employee[empIndex].Lname);


            System.IO.File.WriteAllLines(@"C:\Users\dayar\Desktop\New folder\SaveFile.txt", lines);
            Console.ReadLine();
            refreshPage();
            for (int i = 0; i < empIndex; i++)
            {
                Console.WriteLine(employee[i].Fname + " i =" + i + " empIndex = " + empIndex + " " + employee[i].Lname + " ID: " + employee[i].Empid);

            }
            
            Console.ReadLine();
            return;
        }
        static void deleteEmployee()
        {
            refreshPage();
            Console.WriteLine("Delete Employees..."); Console.ReadLine(); return;
        }
        static void timeClock()
        {
            refreshPage();
            Console.WriteLine("Time Clock Calculator..."); Console.ReadLine(); return;
        }
        static void saveFile()
        {
            refreshPage();
            Console.WriteLine("Saving... done."); Console.ReadLine(); return;
        }
    }
}
