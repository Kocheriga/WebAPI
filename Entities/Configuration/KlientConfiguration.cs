using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class KlientConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            builder.HasData
            (
            new Klient
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                KlientName = "Дубинин",
                City = "Москва",
            },
            new Klient
            {
                Id = new Guid("c3d4c053-49b6-410c-bc78-2d54a9991870"),
                KlientName = "Иванов",
                City = "Брянск",
            },
            new Klient
            {
                Id = new Guid("c2d4c053-49b6-410c-bc78-2d54a9991870"),
                KlientName = "Александров",
                City = "Самара",
            },
            new Klient
            {
                Id = new Guid("c1d4c053-49b6-410c-bc78-2d54a9991870"),
                KlientName = "Кузнецов",
                City = "Калуга",
            }
            );
        }
    }
}
