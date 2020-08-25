using System.ComponentModel.DataAnnotations;

namespace AddressBook.Model {
    public class Item {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
