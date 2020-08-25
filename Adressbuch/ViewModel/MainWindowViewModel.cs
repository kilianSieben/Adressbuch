using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using AddressBook.Model;
using AddressBook.Utilities;
using Addressbook.DatabaseFolder;
using System.Windows;

namespace Addressbook.ViewModel {
    public class MainWindowViewModel :PropertyChange {
        private string visibilityTextBox = Constants.Collapsed;
        private string labelVisibility = Constants.Collapsed;
        private string addButtonVisibility = Constants.Visible;
        private string saveButtonVisibility = Constants.Collapsed;
        private string saveEditItemButtonVisibility = Constants.Collapsed;
        private string editButtonVisibility = Constants.Collapsed;
        private string delButtonVisibility = Constants.Collapsed;
        private string searchedItemListVisibility = Constants.Collapsed;
        private string allItemListVisibility = Constants.Visible;
        private string searchText = "";
        private string selectedItemName;
        private string selectedItemFirstName;
        private string selectedItemPhoneNumber;
        private string selectedItemAddress;
        private bool isVisible = false;
        
        private BusinessObject selectedItem;

        private ICommand selectItem;
        private ICommand addItemButtonCommand;
        private ICommand saveAddItemButtonCommand;
        private ICommand editItemButtonCommand;
        private ICommand saveEditItemButtonCommand;
        private ICommand deleteItemButtonCommand;
        private ICommand searchItemCommand;

        public MainWindowViewModel(){
            Items = new ObservableCollection<BusinessObject>(DbService.GetAllItems());
            TempItems = new ObservableCollection<BusinessObject>();
            //MyGlobalEvent.MyEvent += (s, e) => { PopUpWindowViewModel_OnParameterChange(s); };
            foreach (var item in Items) {
                TempItems.Add(item);
            }
        }
        
        public string VisibilityTextBox{
            get { return visibilityTextBox; }
            set {
                visibilityTextBox = value;
                NotifyPropertyChanged(nameof(VisibilityTextBox));
            }
        }
        public string LabelVisibility {
            get { return labelVisibility; }
            set {
                labelVisibility = value;
                NotifyPropertyChanged(nameof(LabelVisibility));
            }
        }
        public string AddButtonVisibility {
            get { return addButtonVisibility; }
            set {
                addButtonVisibility = value;
                NotifyPropertyChanged(nameof(addButtonVisibility));
            }
        }
        public string SaveButtonVisibility {
            get { return saveButtonVisibility; }
            set {
                saveButtonVisibility = value;
                NotifyPropertyChanged(nameof(saveButtonVisibility));
            }
        }
        public string SaveEditItemButtonVisibility {
            get { return saveEditItemButtonVisibility; }
            set {
                saveEditItemButtonVisibility = value;
                NotifyPropertyChanged(nameof(SaveEditItemButtonVisibility));
            }
        }
        public string EditButtonVisibility {
            get { return editButtonVisibility; }
            set {
                editButtonVisibility = value;
                NotifyPropertyChanged(nameof(EditButtonVisibility));
            }
        }
        public string DelButtonVisibility
        {
            get { return delButtonVisibility; }
            set {
                delButtonVisibility = value;
                NotifyPropertyChanged(nameof(DelButtonVisibility));
            }
        }
        public string SearchedItemListVisibility{
            get { return searchedItemListVisibility; }
            set {
                searchedItemListVisibility = value;
                NotifyPropertyChanged(nameof(SearchedItemListVisibility));
            }
        }
        public string AllItemListVisibility {
            get { return allItemListVisibility; }
            set {
                allItemListVisibility = value;
                NotifyPropertyChanged(nameof(AllItemListVisibility));
            }
        }
        public string SearchText {
            get { return searchText; }
            set {
                searchText = value;
                NotifyPropertyChanged(nameof(SearchText));
            }
        }
        public string SelectedItemName {
            get { return selectedItemName; }
            set {
                selectedItemName = value;
                NotifyPropertyChanged(nameof(SelectedItemName));             
            }
        }
        public string SelectedItemFirstName {
            get { return selectedItemFirstName; }
            set {
                selectedItemFirstName = value;
                NotifyPropertyChanged(nameof(SelectedItemFirstName));
            }
        }
        public string SelectedItemPhoneNumber {
            get { return selectedItemPhoneNumber; }
            set {
                selectedItemPhoneNumber = value;
                NotifyPropertyChanged(nameof(SelectedItemPhoneNumber));
            }
        }
        public string SelectedItemAddress {
            get { return selectedItemAddress; }
            set {
                selectedItemAddress = value;
                NotifyPropertyChanged(nameof(SelectedItemAddress));
            }
        }
        public bool IsVisible {
            get { return isVisible; }
            set {
                isVisible = value;
                NotifyPropertyChanged(nameof(IsVisible));
            }
        }

        public BusinessObject SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                NotifyPropertyChanged(nameof(SelectedItem));
            }
        }
        public ObservableCollection<BusinessObject> TempItems { get; set; }
        public ObservableCollection<BusinessObject> Items { get; set; }

        public ICommand SelectItem {
            get {
                return selectItem ?? (selectItem = new RelayCommand(x => {
                    ShowSelectedItem(x as BusinessObject);
                }));
            }
        }
        public ICommand AddItemButtonCommand {
            get {
                return addItemButtonCommand ?? (addItemButtonCommand = new RelayCommand(x =>
                {
                    AddItem();
                }));
            }
        }
        public ICommand SaveAddItemButtonCommand {
            get {
                return saveAddItemButtonCommand ?? (saveAddItemButtonCommand = new RelayCommand(x =>
                {
                    SaveItem();
                }));
            }
        }
        public ICommand EditItemButtonCommand {
            get
            {
                return editItemButtonCommand ?? (editItemButtonCommand = new RelayCommand(x =>
                {
                    EditItem();
                }));
            }
        }
        public ICommand SaveEditItemButtonCommand {
            get {
                return saveEditItemButtonCommand ?? (saveAddItemButtonCommand = new RelayCommand(x =>
                {
                    SaveEditItem();
                }));
            }
        }
        public ICommand DeleteItemButtonCommand {
            get
            {
                return deleteItemButtonCommand ?? (deleteItemButtonCommand = new RelayCommand(x =>
                {
                    DeleteItem();
                }));
            }
        }
        public ICommand SearchItemButtonCommand {
            get { return searchItemCommand ?? (searchItemCommand = new RelayCommand(x => SearchEnter())); }
        }
        public DbService DbService = new DbService();

        private void ShowSelectedItem(BusinessObject item) {
            if (item != null) {
                IsVisible = true;
                EditButtonVisibility = Constants.Visible;
                DelButtonVisibility = Constants.Visible;
                LabelVisibility = Constants.Visible;
                VisibilityTextBox = Constants.Collapsed;
                SaveButtonVisibility = Constants.Collapsed;
                SaveEditItemButtonVisibility = Constants.Collapsed;
                AddButtonVisibility = Constants.Visible;
                SelectedItemName = SelectedItem.Name;
                SelectedItemFirstName = SelectedItem.FirstName;
                SelectedItemAddress = SelectedItem.Address;
                SelectedItemPhoneNumber = SelectedItem.PhoneNumber;
            }
        }
        private void AddItem() {
            EditButtonVisibility = Constants.Collapsed;
            DelButtonVisibility = Constants.Collapsed;
            VisibilityTextBox = Constants.Visible;
            LabelVisibility = Constants.Visible;
            IsVisible = false;
            AddButtonVisibility = Constants.Collapsed;
            SaveButtonVisibility = Constants.Visible;

            SelectedItemName = "";
            SelectedItemFirstName = "";
            SelectedItemAddress = "";
            SelectedItemPhoneNumber = "";

        }
        private void SaveItem()
        {
            var newItem = new BusinessObject {
                Name = SelectedItemName,
                FirstName = SelectedItemFirstName,
                Address = SelectedItemAddress,
                PhoneNumber = SelectedItemPhoneNumber
            };
            DbService.AddItem(newItem.ConvertToItem());
            newItem.ItemId = DbService.GetLastItemId();

            Items.Add(newItem);
            AddButtonVisibility = Constants.Visible;
            SaveButtonVisibility = Constants.Collapsed;
            LabelVisibility = Constants.Collapsed;
            VisibilityTextBox = Constants.Collapsed;
        }
        private void EditItem() {
            VisibilityTextBox = Constants.Visible;
            IsVisible = false;
            SaveEditItemButtonVisibility = Constants.Visible;
            EditButtonVisibility = Constants.Collapsed;
        }
        private void SaveEditItem() {
            SelectedItem.Name = SelectedItemName;
            SelectedItem.FirstName = SelectedItemFirstName;
            SelectedItem.Address = SelectedItemAddress;
            SelectedItem.PhoneNumber = SelectedItemPhoneNumber;
            DbService.UpdateItem(SelectedItem.ConvertToItem(), SelectedItem.ItemId);

            VisibilityTextBox = Constants.Collapsed;
            IsVisible = true;
            SaveEditItemButtonVisibility = Constants.Collapsed;
            EditButtonVisibility = Constants.Visible;
        }
        private void DeleteItem() { 
            var item = SelectedItem.ConvertToItem();
            MessageBoxResult result = MessageBox.Show("Möchten Sie diesen Eintrag löschen","Eintrag löschen",MessageBoxButton.YesNo);
            switch (result) {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Person " + SelectedItem.Name + ", " + SelectedItem.FirstName + " wurde aus dem Adressbuch gelöscht.");
                    DbService.DeleteItem(SelectedItem.ItemId);
                    Items.Remove(SelectedItem);
                    if (AllItemListVisibility == "Collapsed") {
                        SearchEnter();
                    }                  
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Eintrag wird nicht gelöscht.");
                    break;
            }
        }
        private void SearchEnter() {
            if (SearchText == "") {
                AllItemListVisibility = Constants.Visible;
                SearchedItemListVisibility = Constants.Collapsed;
                foreach (var item in Items) {
                    TempItems.Add(item);
                }
            }
            else {
                AllItemListVisibility = Constants.Collapsed;
                SearchedItemListVisibility = Constants.Visible;
                
                var query = Items.Where(x => x.Name.StartsWith(SearchText)).OrderBy(x=>x.Name);

                TempItems.Clear();
                
                foreach(var item in query) {
                    TempItems.Add(item);
                }
            }
        }
    }
}