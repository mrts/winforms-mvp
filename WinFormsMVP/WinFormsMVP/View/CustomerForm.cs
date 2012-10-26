using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsMVP.View
{
    internal partial class CustomerForm : Form, ICustomerView
    {
        private bool _isEditMode = false;

        public CustomerForm()
        {
            InitializeComponent();
        }

        public IList<string> CustomerList
        {
            get { return (IList<string>)this.customerListBox.DataSource; }
            set { this.customerListBox.DataSource = value; }
        }

        public int SelectedCustomer
        {
            get { return this.customerListBox.SelectedIndex; }
            set { this.customerListBox.SelectedIndex = value; }
        }

        public string Address
        {
            get { return this.addressTextBox.Text; }
            set { this.addressTextBox.Text = value; }
        }

        public string CustomerName
        {
            get { return this.nameTextBox.Text; }
            set { this.nameTextBox.Text = value; }
        }

        public string Phone
        {
            get { return this.phoneTextBox.Text; }
            set { this.phoneTextBox.Text = value; }
        }

        public Presenter.CustomerPresenter Presenter
        { private get; set; }

        private void customerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FIXME: try/catch
            Presenter.UpdateCustomerView(customerListBox.SelectedIndex);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.addressTextBox.ReadOnly = _isEditMode;
            this.nameTextBox.ReadOnly = _isEditMode;
            this.phoneTextBox.ReadOnly = _isEditMode;

            _isEditMode = !_isEditMode;

            this.editButton.Text = _isEditMode ? "Save" : "Edit";
            // TODO: add cancel button

            if (!_isEditMode)
            {
                // TODO: validation
                // FIXME: try/catch
                Presenter.SaveCustomer();
            }
        }
    }
}