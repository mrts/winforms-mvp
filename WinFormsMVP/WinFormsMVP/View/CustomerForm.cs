using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsMVP.View
{
    internal partial class CustomerForm : Form, ICustomerView
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public IList<string> CustomerList
        {
            get { return (IList<string>)this.customerListBox.DataSource; }
            set { this.customerListBox.DataSource = value; }
        }

        public string Address
        {
            set { this.addressTextBox.Text = value; }
        }

        public string CustomerName
        {
            set { this.nameTextBox.Text = value; }
        }

        public string Phone
        {
            set { this.phoneTextBox.Text = value; }
        }

        public Presenter.CustomerPresenter Presenter
        { private get; set; }

        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillCustomerForm(customerListBox.SelectedIndex);
        }
    }
}