using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public int? FkTeacherId { get; set; }

        public virtual Teacher? FkTeacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
