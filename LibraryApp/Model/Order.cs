using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Order
    {

        public int Id { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int OrderStatusId { get; set; }
        public int ClientId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Client Client { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderOfBook> OrderOfBooks { get; set; }
    }
}
