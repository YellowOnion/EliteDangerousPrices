using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Project7.Model;

namespace Model.Migrations
{
    [DbContext(typeof(TraderContext))]
    [Migration("20170801013734_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Project7.Model.Commodity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Buy");

                    b.Property<string>("CName");

                    b.Property<int>("Sell");

                    b.Property<int?>("StationId");

                    b.Property<int>("Stock");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Commodity");
                });

            modelBuilder.Entity("Project7.Model.Item", b =>
                {
                    b.Property<string>("IName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PlayerPName");

                    b.Property<int>("Units");

                    b.HasKey("IName");

                    b.HasIndex("PlayerPName");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Project7.Model.Player", b =>
                {
                    b.Property<string>("PName")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Credit");

                    b.Property<int?>("LocationStationId");

                    b.HasKey("PName");

                    b.HasIndex("LocationStationId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Project7.Model.StarSystem", b =>
                {
                    b.Property<string>("StarName")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("X");

                    b.Property<double>("Y");

                    b.Property<double>("Z");

                    b.HasKey("StarName");

                    b.ToTable("StarSystems");
                });

            modelBuilder.Entity("Project7.Model.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StarSystemStarName");

                    b.Property<string>("StationName");

                    b.HasKey("StationId");

                    b.HasIndex("StarSystemStarName");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("Project7.Model.Commodity", b =>
                {
                    b.HasOne("Project7.Model.Station")
                        .WithMany("Commodities")
                        .HasForeignKey("StationId");
                });

            modelBuilder.Entity("Project7.Model.Item", b =>
                {
                    b.HasOne("Project7.Model.Player")
                        .WithMany("Cargo")
                        .HasForeignKey("PlayerPName");
                });

            modelBuilder.Entity("Project7.Model.Player", b =>
                {
                    b.HasOne("Project7.Model.Station", "Location")
                        .WithMany()
                        .HasForeignKey("LocationStationId");
                });

            modelBuilder.Entity("Project7.Model.Station", b =>
                {
                    b.HasOne("Project7.Model.StarSystem", "StarSystem")
                        .WithMany("Stations")
                        .HasForeignKey("StarSystemStarName");
                });
        }
    }
}
