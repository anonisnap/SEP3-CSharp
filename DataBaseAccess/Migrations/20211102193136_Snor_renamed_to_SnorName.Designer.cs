﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebDBserverAPI.DataAccess;

namespace SEP3_DB_Server.Migrations
{
    [DbContext(typeof(SEP_DBContext))]
    [Migration("20211102193136_Snor_renamed_to_SnorName")]
    partial class Snor_renamed_to_SnorName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WebDBserverAPI.Models.Spike", b =>
                {
                    b.Property<string>("SnorName")
                        .HasColumnType("TEXT");

                    b.HasKey("SnorName");

                    b.ToTable("Spikes");
                });
#pragma warning restore 612, 618
        }
    }
}