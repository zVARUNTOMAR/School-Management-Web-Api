using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagementWebApi.DataLayer.Models
{
    public class SchoolModel
    {
        [Key]
        public int SchoolId { get; set; }

        [MaxLength(255, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Invalid Address")]
        public string Address { get; set; }
    }
}
