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
                Id = 1,
                KlientName = "Дубинин",
                City = "Москва",
            },
            new Klient
            {
                Id = 2,
                KlientName = "Иванов",
                City = "Брянск",
            },
            new Klient
            {
                Id = 3,
                KlientName = "Александров",
                City = "Самара",
            },
            new Klient
            {
                Id = 4,
                KlientName = "Кузнецов",
                City = "Калуга",
            },
            new Klient
            {
                Id = 5,
                KlientName = "Пушкин",
                City = "Рязань",
            },
            new Klient
            {
                Id = 6,
                KlientName = "Васькин",
                City = "Ульяновск",
            },
            new Klient
            {
                Id = 7,
                KlientName = "Бурлаков",
                City = "Ярославль",
            },
            new Klient
            {
                Id = 8,
                KlientName = "Вертолеткин",
                City = "Архангельск",
            },
            new Klient
            {
                Id = 9,
                KlientName = "Гаспарян",
                City = "Вологда",
            }
            );
        }
    }
}
