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
        private readonly List<Customer> stubCustomerList = new List<Customer> {
                new Customer {Name = "Jack", Address = "Nowhere, TX 1023", Phone = "123-456"},
                new Customer {Name = "Jill", Address = "Nowhere, AZ 1026", Phone = "124-456"},
                new Customer {Name = "Sam", Address = "Nowhere, UT 1005", Phone = "125-456"}
        };

        private readonly ICustomerView mockCustomerView;
        private readonly ICustomerRepository mockCustomerRepository;
        private readonly CustomerPresenter presenter;

        public PresenterTests()
        {
            mockCustomerView = Mock.Of<ICustomerView>(view =>
                view.CustomerList == new List<string>());
            mockCustomerRepository = Mock.Of<ICustomerRepository>(repository =>
                repository.GetAllCustomers() == stubCustomerList);

            presenter = new CustomerPresenter(mockCustomerView, mockCustomerRepository);
        }

        [Fact]
        public void Presenter_constructor_ShouldFillViewCustomerList()
        {
            var customerNames = from customer in stubCustomerList select customer.Name;

            Assert.Equal<IList<string>>(mockCustomerView.CustomerList, customerNames.ToList());
        }

        [Fact]
        public void Presenter_UpdateCustomerView_ShouldPopulateViewWithRightCustomer()
        {
            var mockRepo = Mock.Get(mockCustomerRepository);
            mockRepo.Setup(repository => repository.GetCustomer(1)).Returns(stubCustomerList[1]);

            presenter.UpdateCustomerView(1);

            var mockView = Mock.Get(mockCustomerView);
            mockView.VerifySet(view => view.CustomerName = stubCustomerList[1].Name);
            mockView.VerifySet(view => view.Address = stubCustomerList[1].Address);
            mockView.VerifySet(view => view.Phone = stubCustomerList[1].Phone);
            // or just Assert.True(mockCustomerView.CustomerName == stubCustomerList[1].Name && ...);
        }

        [Fact]
        public void Presenter_SaveCustomer_ShouldSaveSelectedCustomerToRepository()
        {
            var mockView = Mock.Get(mockCustomerView);
            mockView.Setup(view => view.SelectedCustomer).Returns(2);
            mockView.Setup(view => view.CustomerName).Returns(stubCustomerList[2].Name);
            mockView.Setup(view => view.Address).Returns(stubCustomerList[2].Address);
            mockView.Setup(view => view.Phone).Returns(stubCustomerList[2].Phone);

            presenter.SaveCustomer();

            var mockRepo = Mock.Get(mockCustomerRepository);
            mockRepo.Verify(repository => repository.SaveCustomer(2, stubCustomerList[2]));
        }
    }
}
