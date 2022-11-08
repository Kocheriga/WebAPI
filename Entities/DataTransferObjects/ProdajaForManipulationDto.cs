using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public abstract class ProdajaForManipulationDto
    {
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Prodaja name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Tovar { get; set; }
        [Required(ErrorMessage = "Money is a required field.")]
        public int Money { get; set; }
    }
}
