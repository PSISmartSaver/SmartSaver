﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSaver.EntityFrameworkCore;

namespace SmartSaver.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserFinancesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserFinancesId");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserFinancesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserFinancesId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserFinancesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserFinancesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.UserFinances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Goal")
                        .HasColumnType("REAL");

                    b.Property<double>("MonthlyExpenses")
                        .HasColumnType("REAL");

                    b.Property<double>("Revenue")
                        .HasColumnType("REAL");

                    b.Property<int>("TimeMonths")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserFinances");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.Category", b =>
                {
                    b.HasOne("SmartSaver.EntityFrameworkCore.Models.UserFinances", null)
                        .WithMany("Priorities")
                        .HasForeignKey("UserFinancesId");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.Transaction", b =>
                {
                    b.HasOne("SmartSaver.EntityFrameworkCore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSaver.EntityFrameworkCore.Models.UserFinances", null)
                        .WithMany("Transactions")
                        .HasForeignKey("UserFinancesId");
                });

            modelBuilder.Entity("SmartSaver.EntityFrameworkCore.Models.User", b =>
                {
                    b.HasOne("SmartSaver.EntityFrameworkCore.Models.UserFinances", "UserFinances")
                        .WithMany()
                        .HasForeignKey("UserFinancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}