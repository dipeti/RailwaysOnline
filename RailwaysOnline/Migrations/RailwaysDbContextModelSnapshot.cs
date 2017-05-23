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
    partial class RailwaysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
