using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tran_Thanh_991515427_Exam.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Dictionary<int, string> Skills = new Dictionary<int, string>();
        [Column(TypeName = "decimal(8,2)")]
        public double Salary { get; set; }
        public DateTime Date { get; set; }
    }
}
