using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
