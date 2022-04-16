using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Genre
    {

        public int Id { get; set; }
        public string Value { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<GenreOfBook> GenreOfBooks { get; set; }
    }
}
