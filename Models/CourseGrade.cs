using System;
using System.Collections.Generic;

namespace finalProdjectDataBase.Models
{
    public partial class CourseGrade
    {
        public int FkStudentId { get; set; }
        public int FkCourseId { get; set; }
        public int FkTeacherId { get; set; }
        public string CourseGrade1 { get; set; } = null!;
        public DateTime CourseDate { get; set; }

        public virtual Course FkCourse { get; set; } = null!;
        public virtual Student FkStudent { get; set; } = null!;
        public virtual Teacher FkTeacher { get; set; } = null!;
    }
}
