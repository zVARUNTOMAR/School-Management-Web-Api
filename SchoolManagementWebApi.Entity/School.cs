using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SchoolManagementWebApi.Entity
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }

        [MaxLength(255, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Invalid Address")]
        public string Address { get; set; }
    }
}