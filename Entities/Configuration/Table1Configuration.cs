using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class Table1Configuration : IEntityTypeConfiguration<Table1>
    {
        public void Configure(EntityTypeBuilder<Table1> builder)
        {
            builder.HasData
            (
            new Table1
            {
                Id = 1,
                KlientName = "Дубинин",
                City = "Москва",
            },
            new Table1
            {
                Id = 2,
                KlientName = "Иванов",
                City = "Брянск",
            },
            new Table1
            {
                Id = 3,
                KlientName = "Александров",
                City = "Самара",
            },
            new Table1
            {
                Id = 4,
                KlientName = "Кузнецов",
                City = "Калуга",
            },
            new Table1
            {
                Id = 5,
                KlientName = "Пушкин",
                City = "Рязань",
            },
            new Table1
            {
                Id = 6,
                KlientName = "Васькин",
                City = "Ульяновск",
            },
            new Table1
            {
                Id = 7,
                KlientName = "Бурлаков",
                City = "Ярославль",
            },
            new Table1
            {
                Id = 8,
                KlientName = "Вертолеткин",
                City = "Архангельск",
            },
            new Table1
            {
                Id = 9,
                KlientName = "Гаспарян",
                City = "Вологда",
            }
            );
        }
    }
}
