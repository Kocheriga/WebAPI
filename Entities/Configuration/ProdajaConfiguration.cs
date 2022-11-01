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
                Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Date = DateTime.Parse("05.09.2016"),
                Tovar="Картофель",
                Money=84,
                KlientsId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Prodaja
            {
                Id = new Guid("022ca3c1-0deb-4afd-ae94-2159a8479811"),
                Date = DateTime.Parse("04.09.2016"),
                Tovar = "Нектарин",
                Money =2520,
                KlientsId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Prodaja
            {
                Id = new Guid("023ca3c1-0deb-4afd-ae94-2159a8479811"),
                Date = DateTime.Parse("01.09.2016"),
                Tovar = "Нектарин",
                Money =1620,
                KlientsId = new Guid("c3d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Prodaja
            {
                Id = new Guid("024ca3c1-0deb-4afd-ae94-2159a8479811"),
                Date = DateTime.Parse("02.09.2016"),
                Tovar = "Лук",
                Money =1786,
                KlientsId = new Guid("c2d4c053-49b6-410c-bc78-2d54a9991870"),
            },
            new Prodaja
            {
                Id = new Guid("025ca3c1-0deb-4afd-ae94-2159a8479811"),
                Date = DateTime.Parse("02.09.2016"),
                Tovar = "Персик",
                Money =14400,
                KlientsId = new Guid("c1d4c053-49b6-410c-bc78-2d54a9991870"),
            }
            );
        }
    }
}