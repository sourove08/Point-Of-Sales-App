using System.Linq;
using POS.Models;
using POS.Models.Database;

namespace POS.DAL
{
    public class CustomerRepository
    {
       public PosDbContext db;
        public bool Insert(Customer customer)
        {
            db=new PosDbContext();
            db.Customers.Add(customer);
           return db.SaveChanges() > 0;
        }
        
        
        public Customer GetCustomerByEmail(string email)
        {
             db = new PosDbContext();
             var student = db.Customers.FirstOrDefault(std => std.Email==email);
            return student;

        }
    }
}