using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class KlientDto
    {
        public Guid Id { get; set; }
        public string KlientName { get; set; }
        public string City { get; set; }
    }
}
