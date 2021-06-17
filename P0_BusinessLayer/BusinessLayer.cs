using System;
using System.Linq;
using P0DbContext;

namespace P0
{
    public class BusinessLayer
    {
        BusinessLayer biz = new BusinessLayer();

        public void SearchCustomers()
        {
            using (var db = new P0Context()) {

            var query = db.Customers.OrderBy (b => b.FirstName);
            
            Console.WriteLine(" All customers in the database:");

            foreach (var item in query) {
               Console.WriteLine(item.FirstName +" "+ item.LastName);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void AddCustomer(String firstName, String lastName, int age)
        {
            using (var db = new P0Context()) {

            // BusinessLayer biz = new BusinessLayer();
            Customer customer = new Customer();
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Age = age;    
            db.Customers.Add(customer);
            db.SaveChanges();        
            }
        }
    }

}