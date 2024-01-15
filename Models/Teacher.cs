using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int TeacherId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int FkClassId { get; set; }
        public int FkPersonalId { get; set; }

        public virtual Class FkClass { get; set; } = null!;
        public virtual Personal FkPersonal { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
