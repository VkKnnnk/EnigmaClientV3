using System;
using System.Collections.Generic;

#nullable disable

namespace EnigmaClientV3.Models.DB
{
    public partial class Mouse
    {
        public Mouse()
        {
            Computers = new HashSet<Computer>();
        }

        public int IdMouse { get; set; }
        public string Model { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
