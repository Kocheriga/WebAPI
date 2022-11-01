using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Klient
    {
        [Column("KlientID")]
        public Guid Id { get; set; }
        public string KlientName { get; set; }
        public string City { get; set; }
        public ICollection<Prodaja> Prodajas { get; set; }
    }
}
