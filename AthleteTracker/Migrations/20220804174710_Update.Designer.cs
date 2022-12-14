// <auto-generated />
using System;
using AthleteTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AthleteTracker.Migrations
{
    [DbContext(typeof(AthleteTrackerContext))]
    [Migration("20220804174710_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AthleteTracker.Models.Athlete", b =>
                {
                    b.Property<int>("AthleteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AthleteId");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("AthleteTracker.Models.AthleteSponsor", b =>
                {
                    b.Property<int>("AthleteSponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<int>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("AthleteSponsorId");

                    b.HasIndex("AthleteId");

                    b.HasIndex("SponsorId");

                    b.ToTable("AthleteSponsor");
                });

            modelBuilder.Entity("AthleteTracker.Models.Sponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SponsorId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("AthleteTracker.Models.AthleteSponsor", b =>
                {
                    b.HasOne("AthleteTracker.Models.Athlete", "Athlete")
                        .WithMany("JoinEntities")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AthleteTracker.Models.Sponsor", "Sponsor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("AthleteTracker.Models.Athlete", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("AthleteTracker.Models.Sponsor", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
