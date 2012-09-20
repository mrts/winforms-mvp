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
                createCustomerXmlRepositoryStub();

            _customers = new Lazy<List<Customer>>(() =>
            {
                using (var reader = new StreamReader(_xmlFilePath))
                {
                    return (List<Customer>)_serializer.Deserialize(reader);
                }
            });
        }

        private void createCustomerXmlRepositoryStub()
        {
            using (var writer = new StreamWriter(_xmlFilePath, false))
            {
                var stubCustomerList = new List<Customer> {
                    new Customer {Name = "Joe", Address = "Nowhere, TX 1023", Phone = "123-456"},
                    new Customer {Name = "Jane", Address = "Nowhere, AZ 1026", Phone = "124-456"},
                    new Customer {Name = "Steve", Address = "Nowhere, UT 1005", Phone = "125-456"}
                };
                _serializer.Serialize(writer, stubCustomerList);
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.Value;
        }

        public Customer GetCustomer(int p)
        {
            return _customers.Value[p];
        }
    }
}