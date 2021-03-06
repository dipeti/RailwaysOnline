﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RailwaysOnline.Data;
using RailwaysOnline.Models;

namespace RailwaysOnline.Migrations
{
    [DbContext(typeof(RailwaysDbContext))]
    [Migration("20170527160758_JourneyWithPrice")]
    partial class JourneyWithPrice
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

                    b.Property<decimal>("Price");

                    b.Property<int>("ToCity");

                    b.HasKey("Id");

                    b.ToTable("Journeys");
                });
        }
    }
}
