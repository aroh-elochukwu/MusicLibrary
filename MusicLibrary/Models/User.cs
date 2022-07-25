using System;
using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CollectionId { get; set; }

        public virtual Collection? Collection { get; set; }
    }
}
