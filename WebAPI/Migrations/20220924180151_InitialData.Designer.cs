﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220924180151_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<string>("Id")
                        .HasColumnName("GroupID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fakultet")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Kurator")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Starosta")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Table1s");

                    b.HasData(
                        new
                        {
                            Id = "101",
                            Fakultet = "ФДП",
                            Kurator = "Хохлова Наталья Николавена ",
                            Starosta = "Гузнова Анастасия"
                        },
                        new
                        {
                            Id = "201",
                            Fakultet = "ФДП",
                            Kurator = "Бородулин Никита Дмитриевич",
                            Starosta = "Шашкин Сергей Дмитриевич"
                        },
                        new
                        {
                            Id = "301",
                            Fakultet = "ФДП",
                            Kurator = "Шумкин Александр Николаевич",
                            Starosta = "Юров Данила Алексеевич"
                        });
                });

            modelBuilder.Entity("Entities.Models.Table2", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("GroupID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Table1Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("Table1sId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Table1Id");

                    b.HasIndex("Table1sId");

                    b.ToTable("Table2s");

                    b.HasData(
                        new
                        {
                            Id = "101_1",
                            FamilyName = "Фиксина",
                            GroupID = "101",
                            Name = "Кристина"
                        },
                        new
                        {
                            Id = "101_2",
                            FamilyName = "Котова",
                            GroupID = "101",
                            Name = "Евгения"
                        },
                        new
                        {
                            Id = "201_1",
                            FamilyName = "Кто-тов",
                            GroupID = "201",
                            Name = "Кто-то"
                        },
                        new
                        {
                            Id = "201_2",
                            FamilyName = "Зузин",
                            GroupID = "201",
                            Name = "Михаил"
                        },
                        new
                        {
                            Id = "301_1",
                            FamilyName = "Крюкин",
                            GroupID = "301",
                            Name = "Евгений"
                        },
                        new
                        {
                            Id = "301_2",
                            FamilyName = "Данилов",
                            GroupID = "301",
                            Name = "Алексей"
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
                    b.HasOne("Entities.Models.Table1", null)
                        .WithMany("Table1s")
                        .HasForeignKey("Table1Id");

                    b.HasOne("Entities.Models.Company", "Table1s")
                        .WithMany()
                        .HasForeignKey("Table1sId");
                });
#pragma warning restore 612, 618
        }
    }
}
