using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagementWebApi.Entity
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [MaxLength(50,ErrorMessage ="Invalid Subject Name")]
        public string SubjectName { get; set; }

    }
}
