using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class ProdajaConfiguration : IEntityTypeConfiguration<Prodaja>
    {
        public void Configure(EntityTypeBuilder<Prodaja> builder)
        {
            builder.HasData
            (
            new Prodaja
            {
                Id = 1,
                Date = DateTime.Parse("05.09.2016"),
                Tovar="Картофель",
                Money=84,
                KlientsId = 7,
            },
            new Prodaja
            {
                Id = 2,
                Date = DateTime.Parse("04.09.2016"),
                Tovar = "Нектарин",
                Money =2520,
                KlientsId = 1,
            },
            new Prodaja
            {
                Id = 3,
                Date = DateTime.Parse("01.09.2016"),
                Tovar = "Нектарин",
                Money =1620,
                KlientsId = 4,
            },
            new Prodaja
            {
                Id = 4,
                Date = DateTime.Parse("02.09.2016"),
                Tovar = "Лук",
                Money =1786,
                KlientsId = 2,
            },
            new Prodaja
            {
                Id = 5,
                Date = DateTime.Parse("02.09.2016"),
                Tovar = "Персик",
                Money =14400,
                KlientsId = 6,
            },
            new Prodaja
            {
                Id = 6,
                Date = DateTime.Parse("03.09.2016"),
                Tovar = "Лук",
                Money =57,
                KlientsId = 9,
            },
            new Prodaja
            {
                Id = 7,
                Date = DateTime.Parse("01.09.2016"),
                Tovar = "Морковь",
                Money =3068,
                KlientsId = 3,
            },
            new Prodaja
            {
                Id = 8,
                Date = DateTime.Parse("05.09.2016"),
                Tovar = "Картофель",
                Money =448,
                KlientsId = 5,
            },
            new Prodaja
            {
                Id = 9,
                Date = DateTime.Parse("04.09.2016"),
                Tovar = "Картофель",
                Money =2590,
                KlientsId = 8,
            }
            );
        }
    }
}