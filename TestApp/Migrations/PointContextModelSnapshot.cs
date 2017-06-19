using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Migrations
{
    [DbContext(typeof(PointContext))]
    partial class PointContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestApp.Models.Point", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("TestApp.Models.PointHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<DateTime>("ChangedOn");

                    b.Property<DateTime>("NewDate");

                    b.Property<double>("NewLatitude");

                    b.Property<double>("NewLongitude");

                    b.Property<string>("NewNotes");

                    b.Property<DateTime>("OldDate");

                    b.Property<double>("OldLatitude");

                    b.Property<double>("OldLongitude");

                    b.Property<string>("OldNotes");

                    b.Property<Guid>("PointId");

                    b.HasKey("Id");

                    b.ToTable("PointsHistory");
                });
        }
    }
}
