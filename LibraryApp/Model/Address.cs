using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Address
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string AddressNumber { get; set; }
        public int CityId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
