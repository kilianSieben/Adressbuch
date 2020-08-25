using AddressBook.Utilities;

namespace AddressBook.Model {
    public class BusinessObject : PropertyChange {
        private string name;
        private string firstName;
        private string phoneNumber;
        private string address;

        public int ItemId { get; set; }
        public string Name {
            get { return name; }
            set {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public string FirstName {
            get { return firstName; }
            set {
                firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }
        public string PhoneNumber {
            get { return phoneNumber; }
            set {
                phoneNumber = value;
                NotifyPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Address {
            get { return address; }
            set {
                address = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }
    }
}