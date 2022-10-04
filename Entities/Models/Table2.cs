﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Table2
    {
        [Column("ProdajaID")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Tovar { get; set; }
        public int Money { get; set; }
        public int KlientsId { get; set; }
        [ForeignKey("Id")]
        public Table1 Table1s { get; set; }
    }
}
