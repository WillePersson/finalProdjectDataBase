using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int FkClassId { get; set; }
        public int FkTeacherId { get; set; }
    }
}
