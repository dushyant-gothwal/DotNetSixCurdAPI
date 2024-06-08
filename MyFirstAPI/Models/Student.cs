using System;
using System.Collections.Generic;

namespace MyFirstAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public int Standard { get; set; }
        public string FatherName { get; set; } = null!;
    }
}
