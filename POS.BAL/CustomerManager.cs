using System;
using POS.DAL;
using POS.Models;

namespace POS.BAL
{
    public class CustomerManager
    {
        private CustomerRepository _repository;
        public bool Insert(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Name))
            {
                throw new Exception("Name is not provide");
            }
            if (string.IsNullOrEmpty(customer.Email))
            {
                throw new Exception("Email not provided");
            }
            if (string.IsNullOrEmpty(customer.Address))
            {
                throw new Exception("Address not provided");
            }
            if (!EmailIsUnique(customer.Email)) 
            {
                throw new Exception("Email already exist");
            }
           return _repository.Insert(customer);
        }

        private bool EmailIsUnique(string email)
        {
          _repository =new CustomerRepository();
            if (_repository.GetCustomerByEmail(email)==null)
            {
                return true;
            }
            return false;
        }


    }
}