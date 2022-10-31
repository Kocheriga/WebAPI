using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProdajaForCreationDto
    {
        public DateTime Date { get; set; }
        public string Tovar { get; set; }
        public int Money { get; set; }
    }
}
