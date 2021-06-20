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
            // int currentUserID = StoreLogin();
            StoreLogin();
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
                                NewOrder();
                                break;
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
                                NewStore();
                                break;
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
        public static int StoreLogin()
        {
            bool notLoggedIn = true;
            System.Console.WriteLine("Please Login.");

            do{
                // get the username & password
                System.Console.WriteLine("Enter your user Name:");
                String userName = Console.ReadLine();
                System.Console.WriteLine("Enter username password:");
                String userPassword = Console.ReadLine();
                //check the database
                using (var db = new P0Context()) {
                
                // var query = db.Users.Where (b => b.FirstName);
                var query = from r in db.Users
                where r.UserName == userName
                select new {
                    dbUserID = r.UserId, 
                    dbUserName = r.UserName,
                    dbUserPassword = r.UserPassword
                    };

                foreach (var item in query) {
                    Console.WriteLine(item.dbUserID +" " + item.dbUserName +" "+ item.dbUserPassword);
                    if (userPassword == item.dbUserPassword)
                    {
                        System.Console.WriteLine("Logged In");
                        notLoggedIn = false;
                        return item.dbUserID;
                    } 
                    else
                    {
                        System.Console.WriteLine("username or password not recognized");
                    }
                }
                
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Console.Clear();
                }

            }while(notLoggedIn);
            return  0;
            
        }
        static void SearchCustomers()
        {
            using (var db = new P0Context()) {

            // var query = from b in db.Customers
            //    orderby b.FirstName select b;

            var query = db.Customers.OrderBy (b => b.FirstName);
            

            Console.WriteLine(" All customers in the database: ");

            foreach (var item in query) {
               Console.WriteLine(item.FirstName +" "+ item.LastName);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void SelectCustomer()
        {
            using (var db = new P0Context()) {

            var query = db.Customers.OrderBy (b => b.LastName);
            
            Console.WriteLine(" Select a customer: ");

            int menuItem = 1;
            foreach (var item in query) {
               Console.WriteLine(menuItem + ") " + item.FirstName +" "+ item.LastName);
               menuItem++;
                }

            Console.WriteLine("Enter the number of the customer you want to use:");
            Menus menu = new Menus();
            int customerSelected = menu.getMenuSelection(1, 20); // need to use length for max
                                                    // pagination will be required too.
            System.Console.WriteLine("You selected " + customerSelected);
            // System.Console.WriteLine(query.);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            // return customerSelected;
            }

            
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

            // System.Console.WriteLine(FirstName);
            // System.Console.WriteLine(LastName);
            // System.Console.WriteLine(age);
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
        static void NewStore()
        {
            System.Console.WriteLine("Enter the Store Name:");
            String StoreName = Console.ReadLine();
            
            System.Console.WriteLine("Enter the Street Address:");
            String StreetAddress = Console.ReadLine();

            System.Console.WriteLine("Enter the City:");
            String City = Console.ReadLine();

            System.Console.WriteLine("Enter the Zipcode");
            String Zipcode = Console.ReadLine();


            using (var db = new P0Context()) {

            Store store = new Store();
            store.StoreName = StoreName;
            store.StoreAddr1 = StreetAddress;
            store.StoreCity = City;
            store.StoreZip = Zipcode;
            db.Stores.Add(store);
            db.SaveChanges();        
            }

            System.Console.ReadLine();
        }
        static void NewOrder()
        {
            // int customer = SelectCustomer();
            
            SelectCustomer();
            // System.Console.WriteLine(customer);
        }
    }

}
