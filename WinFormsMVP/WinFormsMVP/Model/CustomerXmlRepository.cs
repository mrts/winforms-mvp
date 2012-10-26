using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WinFormsMVP.Model
{
    internal class CustomerXmlRepository : ICustomerRepository
    {
        private readonly string _xmlFilePath;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<Customer>));
        private readonly Lazy<List<Customer>> _customers;

        public CustomerXmlRepository(string fullPath)
        {
            _xmlFilePath = fullPath + @"\customers.xml";

            if (!File.Exists(_xmlFilePath))
                CreateCustomerXmlStub();

            _customers = new Lazy<List<Customer>>(() =>
            {
                using (var reader = new StreamReader(_xmlFilePath))
                {
                    return (List<Customer>)_serializer.Deserialize(reader);
                }
            });
        }

        private void CreateCustomerXmlStub()
        {
            var stubCustomerList = new List<Customer> {
                new Customer {Name = "Joe", Address = "Nowhere, TX 1023", Phone = "123-456"},
                new Customer {Name = "Jane", Address = "Nowhere, AZ 1026", Phone = "124-456"},
                new Customer {Name = "Steve", Address = "Nowhere, UT 1005", Phone = "125-456"}
            };
            SaveCustomerList(stubCustomerList);
        }

        private void SaveCustomerList(List<Customer> customers)
        {
            using (var writer = new StreamWriter(_xmlFilePath, false))
            {
                _serializer.Serialize(writer, customers);
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.Value;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.Value[id];
        }

        public void SaveCustomer(int id, Customer customer)
        {
            _customers.Value[id] = customer;
            SaveCustomerList(_customers.Value);
        }
    }
}