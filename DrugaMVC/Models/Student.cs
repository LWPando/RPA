using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrugaMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Ime")]
        [Required]
        public string StudentName { get; set; }
        [Display(Name = "Starost")]
        [Range(5,50)]
        public int Age { get; set; }
    }
}