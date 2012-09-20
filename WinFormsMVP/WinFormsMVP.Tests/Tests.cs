using System.Collections.Generic;
using System.Linq;
using Moq;
using WinFormsMVP.Model;
using WinFormsMVP.Presenter;
using WinFormsMVP.View;
using Xunit;

namespace WinFormsMVP.Tests
{
    public class PresenterTests
    {
        [Fact]
        public void Presenter_constructor_ShouldFillViewCustomerList()
        {
            var stubCustomerList = new List<Customer> {
                new Customer {Name = "Jack", Address = "Nowhere, TX 1023", Phone = "123-456"},
                new Customer {Name = "Jill", Address = "Nowhere, AZ 1026", Phone = "124-456"},
                new Customer {Name = "Sam", Address = "Nowhere, UT 1005", Phone = "125-456"}
            };

            var customerNames = from customer in stubCustomerList select customer.Name;

            var mockCustomerView = Mock.Of<ICustomerView>(view => view.CustomerList == new List<string>());
            var mockCustomerRepository = Mock.Of<ICustomerRepository>(repository => repository.GetAllCustomers() == stubCustomerList);

            var presenter = new CustomerPresenter(mockCustomerView, mockCustomerRepository);

            Assert.Equal<IList<string>>(mockCustomerView.CustomerList, customerNames.ToList());
        }
    }
}