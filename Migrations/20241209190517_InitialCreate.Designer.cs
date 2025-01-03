﻿// <auto-generated />
using CIDM_3312_Final_Project_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CIDM_3312_Final_Project_1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241209190517_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("CIDM_3312_Final_Project_1.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AVG")
                        .HasColumnType("REAL");

                    b.Property<double>("ERA")
                        .HasColumnType("REAL");

                    b.Property<double>("Inn")
                        .HasColumnType("REAL");

                    b.Property<int>("K")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RBI")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SLG")
                        .HasColumnType("REAL");

                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("player_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("team")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project_1.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Losses")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamID1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wins")
                        .HasColumnType("INTEGER");

                    b.Property<string>("team_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.HasIndex("TeamID1");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project_1.Models.Player", b =>
                {
                    b.HasOne("CIDM_3312_Final_Project_1.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project_1.Models.Team", b =>
                {
                    b.HasOne("CIDM_3312_Final_Project_1.Models.Team", null)
                        .WithMany("Teams")
                        .HasForeignKey("TeamID1");
                });

            modelBuilder.Entity("CIDM_3312_Final_Project_1.Models.Team", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
