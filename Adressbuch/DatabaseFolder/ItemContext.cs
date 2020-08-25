using System.Data.Entity;
using AddressBook.Model;

namespace Addressbook.DatabaseFolder {
    public class ItemContext : DbContext {
        public DbSet<Item> Table { get; set; }

        public ItemContext() : base() {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            Database.SetInitializer<ItemContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}