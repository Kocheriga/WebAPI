using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
            (
            new Employee
            {
                Id = "101_1",
                Name = "Кристина",
                FamilyName = "Фиксина",
                GroupID = "101"
            },
            new Employee
            {
                Id = "101_2",
                Name = "Евгения",
                FamilyName = "Котова",
                GroupID = "101"
            },
            new Employee
            {
                Id = "201_1",
                Name = "Кто-то",
                FamilyName = "Кто-тов",
                GroupID = "201"
            }, 
            new Employee
            {
                Id = "201_2",
                Name = "Михаил",
                FamilyName = "Зузин",
                GroupID = "201"
            }, 
            new Employee
            {
                Id = "301_1",
                Name = "Евгений",
                FamilyName = "Крюкин",
                GroupID = "301"
            }, 
            new Employee
            {
                Id = "301_2",
                Name = "Алексей",
                FamilyName = "Данилов",
                GroupID = "301"
            }
            );
        }
    }
}
