using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AddressBook.Model {
    public static class ConvertBusinessObjectToItem {
        public static Item ConvertToItem( this BusinessObject bObject) {
            Item Item = new Item {
                ItemId = bObject.ItemId,
                Name = bObject.Name,
                FirstName = bObject.FirstName,
                PhoneNumber = bObject.PhoneNumber,
                Address = bObject.Address
            };
            return Item;
        }
        public static BusinessObject ConvertToBusinessObject(this Item item) {
            BusinessObject bObject = new BusinessObject {
                ItemId = item.ItemId,
                Name = item.Name,
                FirstName = item.FirstName,
                PhoneNumber = item.PhoneNumber,
                Address = item.Address
            };
            return bObject;
        }
        public static List<BusinessObject> ConvertToBusinesObjectList( this List<Item> Items) {
            var bObjects = new List<BusinessObject>();
            foreach (var item in Items) {
                bObjects.Add(item.ConvertToBusinessObject());
            }
            return bObjects;
        }
        public static List<Item> ConvertToItemList(this ObservableCollection<BusinessObject> bObjects) {
            var items = new List<Item>();
            foreach (var item in bObjects) {
                items.Add(item.ConvertToItem());
            }
            return items;
        }
    }
}