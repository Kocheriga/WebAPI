using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class KlientForUpdateDto
    {
        public string KlientName { get; set; }
        public string City { get; set; }
        public IEnumerable<ProdajaForCreationDto> Prodajas { get; set; }
    }
}
