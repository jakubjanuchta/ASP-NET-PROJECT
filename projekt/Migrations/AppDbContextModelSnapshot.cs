﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt.Models;

#nullable disable

namespace projekt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("projekt.Models.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Furnitures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1830),
                            Label = "ASP.NET 6.0.0",
                            ProductionDate = new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1879),
                            Label = "C# 10.0",
                            ProductionDate = new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1889),
                            Label = "Java 19",
                            ProductionDate = new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1897),
                            Label = "JavaScript",
                            ProductionDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2022, 12, 31, 16, 49, 40, 688, DateTimeKind.Local).AddTicks(1904),
                            Label = "Node.js",
                            ProductionDate = new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
