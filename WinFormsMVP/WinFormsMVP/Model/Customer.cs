namespace WinFormsMVP.Model
{
    public class Customer
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            Customer other = obj as Customer;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode()
                ^ Address.GetHashCode()
                ^ Phone.GetHashCode();
        }

        public bool Equals(Customer other)
        {
            if (other == null)
                return false;

            return this.Name == other.Name
                && this.Address == other.Address
                && this.Phone == other.Phone;
        }
    }
}