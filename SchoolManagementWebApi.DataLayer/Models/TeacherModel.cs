using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolManagementWebApi.DataLayer.Models
{
    public class TeacherModel
    {
        [Key]
        public int TeacherId { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        public SubjectModel subject { get; set; }

        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }

        public SchoolModel school { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
    }
}
