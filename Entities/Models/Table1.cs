using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Table1
    {
        [Column("GroupID")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Starosra's name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string Starosta { get; set; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string Fakultet { get; set; }
        [Required(ErrorMessage = "Kurator's name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for rhe Address is 100 characte")]
        public string Kurator { get; set; }
        public ICollection<Table2> Table1s { get; set; }
    }
}
