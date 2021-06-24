using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        static int SelectCustomer()
        {
            using (var db = new P0Context()) {

            var query = db.Customers.OrderBy (b => b.LastName);
            
            Console.WriteLine(" Select a customer: ");

            int menuItem = 1;
            List<int> custIDs = new List<int>();

            foreach (var item in query) {
               Console.WriteLine(menuItem + ") " + item.FirstName +" "+ item.LastName);
               menuItem++;
               custIDs.Add(item.CustomerId);
                }

            Console.WriteLine("Enter the number of the customer you want to use:");
            Menus menu = new Menus();
            int customerSelected = menu.getMenuSelection(1, 20); // need to use length for max
                                                    // pagination will be required too.
            System.Console.WriteLine("You selected " + customerSelected);
            System.Console.WriteLine("Which is UserID: " + custIDs[customerSelected-1]);
            // System.Console.WriteLine(query.);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            // return customerSelected;
            return custIDs[customerSelected-1];
            }
        }
        static int SelectStore()
        {
            using (var db = new P0Context()) {

            var query = db.Stores.OrderBy (b => b.StoreName);
            
            Console.WriteLine(" Select a store: ");

            int menuItem = 1;
            List<int> storeIDs = new List<int>();

            foreach (var item in query) {
               Console.WriteLine(menuItem + ") " + item.StoreName);
               menuItem++;
               storeIDs.Add(item.StoreId);
                }

            Console.WriteLine("Enter the number of the store you want to use:");
            Menus menu = new Menus();
            int storeSelected = menu.getMenuSelection(1, 20); // need to use length for max
                                                    // pagination will be required too.
            System.Console.WriteLine("You selected " + storeSelected);
            System.Console.WriteLine("Which is StoreID: " + storeIDs[storeSelected-1]);
            // System.Console.WriteLine(query.);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            // return customerSelected;
            return storeIDs[storeSelected-1];
            }
        }
        static int SelectStoreInventory(int storeID)
        {
            using (var db = new P0Context()) {
            /*
            select Products.ProductName, StoreInventory.Quantity from Products
            INNER JOIN StoreInventory ON Products.ProductID=StoreInventory.ProductID
            WHERE StoreInventory.StoreID=1;
            */

            // var query = db.StoreInventories.OrderBy (b => b.StoreId);
            // select id,title,description from articles inner join users on users.id = articles.id where users.id=10
            var innerJoinQuery =
                from pduct in db.Products
                join storeInv in db.StoreInventories on pduct.ProductId equals storeInv.ProductId
                // where storeInv.StoreId = storeID
                select new { 
                    ProductID = pduct.ProductId,
                    ProductName = pduct.ProductName, 
                    StoreID = storeInv.StoreId, 
                    StoreQuantity = storeInv.Quantity,
                    StorePrice = storeInv.Price
                    };

            // IEnumerable<Product> results = db.ExecuteQuery<Product>
            // IEnumerable<Product> results = db.FromSqlRaw<Product>
            // ("select Products.ProductName, StoreInventory.Quantity from Products INNER JOIN StoreInventory ON Products.ProductID=StoreInventory.ProductID WHERE StoreInventory.StoreID = {0}",
            // 1);

                // where storeInv.StoreID == storeID
                // // where storeInv.StoreID == 1
                // select new { ProductName = pduct.ProductName }; 
                // //produces flat sequence

            Console.WriteLine(" Select a product (0 to exit): ");

            int menuItem = 1;
            List<int> storeProductIDs = new List<int>();

            foreach (var item in innerJoinQuery) {
                if (item.StoreID == storeID)
                {
                    // Console.WriteLine(menuItem + ") " + item.ProductName + " (store: " + item.StoreID + "  Inventory: " + item.StoreQuantity + " Product ID: " + item.ProductID + " Price: " + item.StorePrice + ")");
                    // Console.WriteLine(menuItem + ") " + item.ProductName + " (store: " + item.StoreID + "  Inventory: " + item.StoreQuantity + " Product ID: " + item.ProductID + " Price: " + item.StorePrice.ToString() + ")");
                    Console.WriteLine(menuItem + ") " + item.ProductName + " (store: " + item.StoreID + "  Inventory: " + item.StoreQuantity + " Product ID: " + item.ProductID + ") ");
                    storeProductIDs.Add(item.ProductID);
                    System.Console.WriteLine(item.StorePrice);
                    menuItem++;
                }
                // Console.WriteLine(menuItem + ") " + item.ProductName + " store: " + item.StoreID);
                // menuItem++;
            //    storeIDs.Add(item.StoreId);
                }

            Console.WriteLine("Enter the number of the product you want:");
            Menus menu = new Menus();
            int productSelected = menu.getMenuSelection(1, 20); // need to use length for max
                                                    // pagination will be required too.
            System.Console.WriteLine("You selected " + productSelected);
            System.Console.WriteLine("Which is ProductID: " + storeProductIDs[productSelected-1]);
            // System.Console.WriteLine(query.);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            // return customerSelected;
            // return storeIDs[storeSelected-1];
            return storeProductIDs[productSelected-1];
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
        // static void AddOrderItem(int OrderID, int ProductID, decimal StorePrice)
        static void AddOrderItem(int OrderID, int ProductID)
        {



            using (var db = new P0Context()) {

            OrdersItem orderItem = new OrdersItem();
            orderItem.OrderId = OrderID;
            orderItem.ProductId = ProductID;
            // orderItem.Price = StorePrice;
            orderItem.Price = 0;
            orderItem.Quantity = 1;

            db.OrdersItems.Add(orderItem);
            db.SaveChanges();        
            }
        }
        static void NewOrder()
        {
            // select a customer
            int customerID = SelectCustomer();
            // select a store
            int storeID = SelectStore();
            // create header record
            int OrderID;
            using (var db = new P0Context()) {

            Order order = new Order();
            order.CustomerId = customerID;
            order.StoreId = storeID;
            // store.StoreName = StoreName;
            // store.StoreAddr1 = StreetAddress;
            // store.StoreCity = City;
            // store.StoreZip = Zipcode;
            db.Orders.Add(order);
            db.SaveChanges();    
            System.Console.WriteLine("OrderID: " + order.OrderId);  
            OrderID = order.OrderId;  
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            }
            
            // Now select products for order
            int pId = 0;
            do {
                pId = SelectStoreInventory(storeID);
                System.Console.WriteLine("Order ID: " + OrderID);
                System.Console.WriteLine("Store ID: " + storeID);
                System.Console.WriteLine("Product ID: " + pId);
                AddOrderItem(OrderID, storeID);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }while(true);

        }
    }

}
