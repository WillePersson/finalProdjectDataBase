using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Admins = new HashSet<Admin>();
            Janitors = new HashSet<Janitor>();
            Principals = new HashSet<Principal>();
            Teachers = new HashSet<Teacher>();
        }

        public int PersonalId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? FkDepartmentId { get; set; }

        public virtual Department? FkDepartment { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Janitor> Janitors { get; set; }
        public virtual ICollection<Principal> Principals { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
