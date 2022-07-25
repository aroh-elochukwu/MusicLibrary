using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public partial class Collection
    {
        public Collection()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? SongId { get; set; }

        public virtual Song? Song { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
