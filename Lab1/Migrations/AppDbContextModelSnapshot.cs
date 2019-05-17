﻿// <auto-generated />
using System;
using Lab1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab1.Models.CurrencyPurchase", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.Property<int>("Income");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("UdId");

                    b.ToTable("CurrencyPurchases");
                });

            modelBuilder.Entity("Lab1.Models.FirstGameLaunch", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.Property<string>("Gender");

                    b.HasKey("UdId");

                    b.ToTable("FirstGameLaunches");
                });

            modelBuilder.Entity("Lab1.Models.GameLaunch", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.HasKey("UdId");

                    b.ToTable("GameLaunches");
                });

            modelBuilder.Entity("Lab1.Models.IngamePurchase", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.Property<string>("Item");

                    b.Property<double>("Price");

                    b.HasKey("UdId");

                    b.ToTable("IngamePurchases");
                });

            modelBuilder.Entity("Lab1.Models.StageEnd", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.Property<int>("Income");

                    b.Property<int>("Stage");

                    b.Property<int>("Time");

                    b.Property<bool>("Win");

                    b.HasKey("UdId");

                    b.ToTable("StageEnds");
                });

            modelBuilder.Entity("Lab1.Models.StageStart", b =>
                {
                    b.Property<string>("UdId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventId");

                    b.Property<int>("Stage");

                    b.HasKey("UdId");

                    b.ToTable("StageStarts");
                });
#pragma warning restore 612, 618
        }
    }
}
