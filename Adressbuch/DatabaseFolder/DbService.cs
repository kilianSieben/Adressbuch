using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AddressBook.Model;

namespace Addressbook.DatabaseFolder {
    public class DbService
    {
        private ItemContext context;

        public DbService() {
            Context.Database.CreateIfNotExists();
            Context.Table.Load();
        }

        public ItemContext Context {
            get { return context ?? (context = new ItemContext()); }

        }

        public void AddItem(Item newItem) {
            Context.Table.Add(newItem);
            Context.SaveChanges();
        }

        public void DeleteItem(int itemId) {
                var deleteItem = Context.Table.First(x => x.ItemId == itemId);
                Context.Table.Remove(deleteItem);
                Context.SaveChanges();    
        }


        public void UpdateItem(Item item,int itemId) {
            var result = Context.Table.SingleOrDefault(x => x.ItemId == itemId);
            if (result != null) {
                result.FirstName = item.FirstName;
                result.Name = item.Name;
                result.PhoneNumber = item.PhoneNumber;
                result.Address = item.Address;              
            }           
            Context.SaveChanges();
        }


        public List<BusinessObject> GetAllItems() {
            return Context.Table.ToList().ConvertToBusinesObjectList();
        }
        public int GetLastItemId()
        {
            return Context.Table.ToList().ConvertToBusinesObjectList().Last().ItemId;
        }
    }
}