using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class GenreOfBook
    {
        public int GenreId { get; set; }
        public int BookId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
