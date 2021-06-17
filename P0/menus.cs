using System;
using P0DbContext;


namespace P0
{
    public class Menus
    {
        public int MainMenu()
        // public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Orders");
            Console.WriteLine("2) Customers");
            Console.WriteLine("3) Stores");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            return getMenuSelection(1, 4);
        }
        public int OrdersMenu()
        // public static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Create Order");
            Console.WriteLine("2) Search Orders");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            return getMenuSelection(1, 3);
        
 
        }
        public int CustomersMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a Customer");
            Console.WriteLine("2) Search Customers");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            return getMenuSelection(1, 3);
        }
        public int StoresMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a Store");
            Console.WriteLine("2) Search Stores");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            return getMenuSelection(1, 3);
        }
        public int getMenuSelection(int min, int max)
        {
            //prompt for choice
            bool successfulConversion = false;
            int playerChoiceInt;

            do{
                    // Console.WriteLine("Enter the number of your choice\n1. Rock\n2. Paper\n3.Scissors");
                    string playerChoice = Console.ReadLine();

                    successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                    if (!successfulConversion)
                    {
                        Console.WriteLine($" {playerChoice} is not a valid choice.");
                        Console.WriteLine($" Please anter a number between {min} and {max}");
                    } else if (playerChoiceInt > max || playerChoiceInt < min)
                    {
                        Console.WriteLine($" {playerChoice} is not a valid choice. Number out of range");
                        Console.WriteLine($" Please anter a number between {min} and {max}");
                    } else
                    {
                        return playerChoiceInt;
                    }

            }while(true);        
        }
        public void GetNewCustomer()
        {
            System.Console.WriteLine("Enter the Last Name:");
            String LastName = Console.ReadLine();
            
            System.Console.WriteLine("Enter the First Name:");
            String FirstName = Console.ReadLine();

            System.Console.WriteLine("Enter the Age:");
            int age = getMenuSelection(18, 100);

            System.Console.WriteLine(FirstName);
            System.Console.WriteLine(LastName);
            System.Console.WriteLine(age);
            // BusinessLayer biz = new BusinessLayer();
            // biz.AddCustomer(FirstName, LastName, age);            
            System.Console.ReadLine();


        }
    }
}