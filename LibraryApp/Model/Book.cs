using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool? IsAvailability { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<AutorOfBook> AutorOfBooks { get; set; }
        public virtual ICollection<GenreOfBook> GenreOfBooks { get; set; }
        public virtual ICollection<OrderOfBook> OrderOfBooks { get; set; }
    }
}
