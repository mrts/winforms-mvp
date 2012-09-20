using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsMVP.Model
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomer(int p);
    }
}
