using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Prodaja
    {
        [Column("ProdajaID")]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Tovar { get; set; }
        public int Money { get; set; }
        [ForeignKey(nameof(Klient))]
        public Guid KlientsId { get; set; }
        public Klient Klient { get; set; }
    }
}
