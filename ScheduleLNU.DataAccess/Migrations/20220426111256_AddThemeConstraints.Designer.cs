﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScheduleLNU.DataAccess;

namespace ScheduleLNU.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220426111256_AddThemeConstraints")]
    partial class AddThemeConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(4096)
                        .HasColumnType("character varying(4096)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Place")
                        .HasColumnType("text");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("StyleId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("StyleId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.EventStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BackColor")
                        .HasColumnType("text");

                    b.Property<string>("ForeColor")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("EventsStyles");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<bool>("IsNotifiable")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("SelectedThemeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SelectedThemeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BackColor")
                        .HasColumnType("text");

                    b.Property<string>("Font")
                        .HasColumnType("text");

                    b.Property<int>("FontSize")
                        .HasColumnType("integer");

                    b.Property<string>("ForeColor")
                        .HasColumnType("text");

                    b.Property<int?>("StudentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Event", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Schedule", null)
                        .WithMany("Events")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("ScheduleLNU.DataAccess.Entities.EventStyle", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.EventStyle", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Student", null)
                        .WithMany("EventStyles")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Link", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Event", null)
                        .WithMany("Links")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Schedule", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Student", "Student")
                        .WithMany("Schedules")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Student", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Theme", "SelectedTheme")
                        .WithMany()
                        .HasForeignKey("SelectedThemeId");

                    b.Navigation("SelectedTheme");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Theme", b =>
                {
                    b.HasOne("ScheduleLNU.DataAccess.Entities.Student", null)
                        .WithMany("Themes")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Event", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Schedule", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ScheduleLNU.DataAccess.Entities.Student", b =>
                {
                    b.Navigation("EventStyles");

                    b.Navigation("Schedules");

                    b.Navigation("Themes");
                });
#pragma warning restore 612, 618
        }
    }
}
