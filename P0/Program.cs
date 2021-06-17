using System;
using System.Linq;
using P0DbContext;
// using P0_BusinessLayer;
using P0_UI;

namespace P0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Menus menu = new Menus();
            // BusinessLayer biz = new BusinessLayer();
            // int x = menu.MainMenu();
            // Menu logic here
            bool runProgram = true;
            do
            {    
                switch (menu.MainMenu())
                {
                    case 1:
                        // Orders menu
                        switch (menu.OrdersMenu())
                        {
                            case 1:
                                // Create Order
                            case 2:
                                // Serach Orders
                            case 3:
                                // Exit
                            default:
                                // do something
                                break;
                        }
                        break;

                    case 2:
                        // Customers Menu
                        switch (menu.CustomersMenu())
                        {
                            case 1:
                                // Add Customer
                                // biz.AddCustomer();
                                // menu.GetNewCustomer();
                                NewCustomer();
                                break;
                            case 2:
                                // Serach Customers
                                // biz.SearchCustomers();
                                SearchCustomers();
                                break;
                            case 3:
                                // Exit
                            default:
                                // do something
                                break;
                        }
                        break;
                    case 3:
                        // Stores Menu
                        switch (menu.StoresMenu())
                        {
                            case 1:
                                // Add Store
                            case 2:
                                // Search Stores
                            case 3:
                                // Exit
                            default:
                                // do something
                                break;
                        }
                        break;
                    case 4:
                        // Exit
                        runProgram = false;
                        break;
                    default:
                        // do something
                        break;
                }
            }while(runProgram);
        }

        /*
        Functionality below should be moved to a 
        business layer.
        */
        static void SearchCustomers()
        {
            using (var db = new P0Context()) {

            // var query = from b in db.Customers
            //    orderby b.FirstName select b;

            var query = db.Customers.OrderBy (b => b.FirstName);
            

            Console.WriteLine(" All studecustomersnt in the database:");

            foreach (var item in query) {
               Console.WriteLine(item.FirstName +" "+ item.LastName);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void NewCustomer()
        {
            System.Console.WriteLine("Enter the Last Name:");
            String LastName = Console.ReadLine();
            
            System.Console.WriteLine("Enter the First Name:");
            String FirstName = Console.ReadLine();

            System.Console.WriteLine("Enter the Age:");
            Menus menu = new Menus();
            int age = menu.getMenuSelection(18, 100);

            System.Console.WriteLine(FirstName);
            System.Console.WriteLine(LastName);
            System.Console.WriteLine(age);
            // BusinessLayer biz = new BusinessLayer();
            // biz.AddCustomer(FirstName, LastName, age);  
            using (var db = new P0Context()) {

            // BusinessLayer biz = new BusinessLayer();
            Customer customer = new Customer();
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.Age = age;    
            db.Customers.Add(customer);
            db.SaveChanges();        
            }

            System.Console.ReadLine();
        }
    }

}
