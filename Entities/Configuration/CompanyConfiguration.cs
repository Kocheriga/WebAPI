using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
            new Company
            {
                Id = "101",
                Starosta = "Гузнова Анастасия",
                Kurator = "Хохлова Наталья Николавена ",
                Fakultet = "ФДП"
            },
            new Company
            {
                Id = "201",
                Starosta = "Шашкин Сергей Дмитриевич",
                Kurator = "Бородулин Никита Дмитриевич",
                Fakultet = "ФДП"
            },
            new Company
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
