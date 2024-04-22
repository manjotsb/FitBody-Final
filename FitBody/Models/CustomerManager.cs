using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitBody.Models
{
    public class CustomerManager
    {
        private SQLiteConnection _database;
        public CustomerManager()
        {
            _database = new SQLiteConnection(Constants.DbPath);

            _database.CreateTable<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            _database.Insert(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _database.Table<Customer>().ToList();
        }

        public void DropAllCustomers()
        {
            _database.DropTable<Customer>();
        }

        public bool IsCustomer(string customerUsername, string customerPassword)
        {
            var customer = _database.Table<Customer>().FirstOrDefault(c => c.Username == customerUsername);


            if (customer == null)
            {
                Debug.WriteLine("Customer doesn't exist");
                return false;
            }

            else if (customer.Password == customerPassword)
            {
                Debug.WriteLine("Found");
                return true;
            }
            else
            {
                Debug.WriteLine("Incorrect Password");
                return false;
            }
        }

        public Customer GetCustomer(string customerUsername)
        {
            Customer customer = _database.Table<Customer>().FirstOrDefault(c => c.Username == customerUsername);
            
            return customer;
        }

        public void UpdateCustomer (Customer customer)
        {
            _database.Update(customer);
        }
    }
}
