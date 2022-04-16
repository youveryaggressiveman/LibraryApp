using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class City
    {

        public int Id { get; set; }
        public string Value { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
