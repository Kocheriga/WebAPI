using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class KlientForCreationDto
    {
        [Required(ErrorMessage = "Klient name is a required field.")]
        public string KlientName { get; set; }
        [Required(ErrorMessage = "Klient city is a required field.")]
        public string City { get; set; }
        public IEnumerable<ProdajaForCreationDto> Prodajas { get; set; }
    }
}
