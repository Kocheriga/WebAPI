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
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Tovar { get; set; }
        public int Money { get; set; }
        public int KlientsId { get; set; }
        [ForeignKey("Id")]
        public Klient Table1s { get; set; }
    }
}
