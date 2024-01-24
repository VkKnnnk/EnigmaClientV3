using System;
using System.Collections.Generic;

#nullable disable

namespace EnigmaClientV3.Models.DB
{
    public partial class VideoCard
    {
        public VideoCard()
        {
            Computers = new HashSet<Computer>();
        }

        public int IdVideoCard { get; set; }
        public string Model { get; set; }
        public int Memory { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
