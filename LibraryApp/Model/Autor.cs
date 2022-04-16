using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Autor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<AutorOfBook> AutorOfBooks { get; set; }
    }
}
