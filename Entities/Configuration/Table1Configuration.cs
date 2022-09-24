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
                Id = "101",
                Starosta = "Гузнова Анастасия",
                Kurator = "Хохлова Наталья Николавена ",
                Fakultet = "ФДП"
            },
            new Table1
            {
                Id = "201",
                Starosta = "Шашкин Сергей Дмитриевич",
                Kurator = "Бородулин Никита Дмитриевич",
                Fakultet = "ФДП"
            },
            new Table1
            {
                Id = "301",
                Starosta = "Юров Данила Алексеевич",
                Kurator = "Шумкин Александр Николаевич",
                Fakultet = "ФДП"
            }
            );
        }
    }
}
