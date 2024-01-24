using System;
using System.Collections.Generic;

#nullable disable

namespace EnigmaClientV3.Models.DB
{
    public partial class Monitor
    {
        public Monitor()
        {
            Computers = new HashSet<Computer>();
        }

        public int IdMonitor { get; set; }
        public string Model { get; set; }
        public int Frequency { get; set; }
        public string Resolution { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
