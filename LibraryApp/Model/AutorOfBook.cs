using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class AutorOfBook
    {
        public int AutorId { get; set; }
        public int BookId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Book Book { get; set; }
    }
}
