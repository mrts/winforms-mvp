using WinFormsMVP.View;
using WinFormsMVP.Model;
using System.Linq;

namespace WinFormsMVP.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;
        private readonly ICustomerRepository _repository;

        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;

            initialize();
        }

        private void initialize()
        {
            var customerNames = from customer in _repository.GetAllCustomers() select customer.Name;
            _view.CustomerList = customerNames.ToList();
        }

        internal void FillCustomerForm(int p)
        {
            Customer customer = _repository.GetCustomer(p);
            _view.CustomerName = customer.Name;
            _view.Address = customer.Address;
            _view.Phone = customer.Phone;
        }
    }
}