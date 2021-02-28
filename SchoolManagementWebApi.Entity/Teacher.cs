using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolManagementWebApi.Entity
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        public Subject subject { get; set; }

        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }

        public School school { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
    }
}
