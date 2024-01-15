using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Janitor
    {
        public int JanitorId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int FkPersonalId { get; set; }

        public virtual Personal FkPersonal { get; set; } = null!;
    }
}
