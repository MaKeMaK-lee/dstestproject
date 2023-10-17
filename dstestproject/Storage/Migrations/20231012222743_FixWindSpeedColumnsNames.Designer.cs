﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dstestproject.Storage;

namespace dstestproject.Storage.Migrations
{
    [DbContext(typeof(DsTestDataContext))]
    [Migration("20231012222743_FixWindSpeedColumnsNames")]
    partial class FixWindSpeedColumnsNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dstestproject.Storage.Entity.WeatherElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("gId");

                    b.Property<short>("CloudHeight")
                        .HasColumnType("smallint")
                        .HasColumnName("sintCloudHeight");

                    b.Property<byte>("Cloudy")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintСloudy");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("dtDate");

                    b.Property<byte>("DewPointFractional")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintDewPointFractional");

                    b.Property<byte>("DewPointInteger")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintDewPointInteger");

                    b.Property<byte>("HorizontalVisibilityFractional")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintHorizontalVisibilityFractional");

                    b.Property<byte>("HorizontalVisibilityInteger")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintHorizontalVisibilityInteger");

                    b.Property<byte>("HumidityFractional")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintHumidityFractional");

                    b.Property<byte>("HumidityInteger")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintHumidityInteger");

                    b.Property<short>("Pressure")
                        .HasColumnType("smallint")
                        .HasColumnName("sintPressure");

                    b.Property<byte>("TemperatureFractional")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintTemperatureFractional");

                    b.Property<byte>("TemperatureInteger")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintTemperatureInteger");

                    b.Property<string>("WeatherPhenomenon")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasColumnName("szWeatherPhenomenon");

                    b.Property<string>("WindDirections")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasColumnName("szWindDirection");

                    b.Property<byte>("WindSpeedFractional")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintWindSpeedFractional");

                    b.Property<byte>("WindSpeedInteger")
                        .HasColumnType("tinyint")
                        .HasColumnName("tintWindSpeedInteger");

                    b.HasKey("Id");

                    b.ToTable("tblWeatherElements");
                });
#pragma warning restore 612, 618
        }
    }
}
