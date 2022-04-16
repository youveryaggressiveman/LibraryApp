using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class RoleOfUser
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
