using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Employee
    {
        [Column("StudentID")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")] 
        public string FamilyName { get; set; }
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }
        [ForeignKey(nameof(Company))]
        public string GroupID { get; set; }
        public Company Company { get; set; }
    }
}
