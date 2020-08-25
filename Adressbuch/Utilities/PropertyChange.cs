using System.ComponentModel;

namespace AddressBook.Utilities {
    public class PropertyChange : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string info) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
