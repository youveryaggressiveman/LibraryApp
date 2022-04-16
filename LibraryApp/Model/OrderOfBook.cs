using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class OrderOfBook
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
