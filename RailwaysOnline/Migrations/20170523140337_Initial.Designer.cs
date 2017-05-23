using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline.Migrations
{
    [DbContext(typeof(RailwaysDbContext))]
    [Migration("20170523140337_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RailwaysOnline.Models.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<int>("BusinessSeats");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<int>("EconomySeats");

                    b.Property<int>("FromCity");

                    b.Property<int>("ToCity");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });
        }
    }
}
