using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Department
    {
        public Department()
        {
            Personals = new HashSet<Personal>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
        public virtual ICollection<Teacher> Teachers => Personals.OfType<Teacher>().ToList();
    }
}
