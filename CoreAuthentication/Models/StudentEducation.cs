using System;
using System.Collections.Generic;

namespace CoreAuthentication.Models
{
    public partial class StudentEducation
    {
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string ClassId { get; set; }
        public string SchoolId { get; set; }
        public string SyllabusId { get; set; }
        public string BoardId { get; set; }
        public DateTime? ForAcademicYearFrom { get; set; }
        public DateTime? ForAcademicYearTo { get; set; }
    }
}
