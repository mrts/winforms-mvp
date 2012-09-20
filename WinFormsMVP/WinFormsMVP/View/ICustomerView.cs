using System.Collections.Generic;

namespace WinFormsMVP.View
{
    public interface ICustomerView
    {
        IList<string> CustomerList { get; set; }

        string CustomerName { set; }

        string Address { set; }

        string Phone { set; }

        Presenter.CustomerPresenter Presenter { set; }
    }
}