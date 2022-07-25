using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Song> Songs { get; set; }
    }
}
