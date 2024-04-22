using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Models
{
    public class CustomerService
    {
        private static CustomerService _instance;
        private Customer _currentCustomer;

        private CustomerService() { }

        public static CustomerService Instance => _instance ??= new CustomerService();

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set => _currentCustomer = value;
        }
    }
}
