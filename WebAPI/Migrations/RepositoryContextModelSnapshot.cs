﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                            Country = "USA",
                            Name = "IT_Solutions Ltd"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "312 Forest Avenue, BF 923",
                            Country = "USA",
                            Name = "Admin_Solutions Ltd"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Age = 26,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Sam Raiden",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Age = 30,
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Name = "Jana McLeaf",
                            Position = "Software developer"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Age = 35,
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Name = "Kane Miller",
                            Position = "Administrator"
                        });
                });

            modelBuilder.Entity("Entities.Models.Table1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KlientID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("KlientName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Table1s");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Москва",
                            KlientName = "Дубинин"
                        },
                        new
                        {
                            Id = 2,
                            City = "Брянск",
                            KlientName = "Иванов"
                        },
                        new
                        {
                            Id = 3,
                            City = "Самара",
                            KlientName = "Александров"
                        },
                        new
                        {
                            Id = 4,
                            City = "Калуга",
                            KlientName = "Кузнецов"
                        },
                        new
                        {
                            Id = 5,
                            City = "Рязань",
                            KlientName = "Пушкин"
                        },
                        new
                        {
                            Id = 6,
                            City = "Ульяновск",
                            KlientName = "Васькин"
                        },
                        new
                        {
                            Id = 7,
                            City = "Ярославль",
                            KlientName = "Бурлаков"
                        },
                        new
                        {
                            Id = 8,
                            City = "Архангельск",
                            KlientName = "Вертолеткин"
                        },
                        new
                        {
                            Id = 9,
                            City = "Вологда",
                            KlientName = "Гаспарян"
                        });
                });

            modelBuilder.Entity("Entities.Models.Table2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("KlientID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Tovar")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.ToTable("Table2s");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 7,
                            Money = 84,
                            Tovar = "Картофель"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2016, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 1,
                            Money = 2520,
                            Tovar = "Нектарин"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 4,
                            Money = 1620,
                            Tovar = "Нектарин"
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 2,
                            Money = 1786,
                            Tovar = "Лук"
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2016, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 6,
                            Money = 14400,
                            Tovar = "Персик"
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2016, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 9,
                            Money = 57,
                            Tovar = "Лук"
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 3,
                            Money = 3068,
                            Tovar = "Морковь"
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 5,
                            Money = 448,
                            Tovar = "Картофель"
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2016, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KlientId = 8,
                            Money = 2590,
                            Tovar = "Картофель"
                        });
                });

            modelBuilder.Entity("Entities.Models.Employee", b =>
                {
                    b.HasOne("Entities.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Table2", b =>
                {
                    b.HasOne("Entities.Models.Table1", "Table1s")
                        .WithMany("Table2s")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
