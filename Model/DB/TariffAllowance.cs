using System;
using System.Collections.Generic;

#nullable disable

namespace EnigmaClientV3.Model.DB
{
    public partial class TariffAllowance
    {
        public int IdAllowance { get; set; }
        public string Name { get; set; }
        public int AllowancePercent { get; set; }
    }
}
