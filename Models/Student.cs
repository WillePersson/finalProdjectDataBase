using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int PersonalIdentityNumber { get; set; }
        public int ZipCode { get; set; }
        public string Street { get; set; } = null!;
        public int Housenumber { get; set; }
        public int? FkClassId { get; set; }

        public virtual Class? FkClass { get; set; }
    }
}
