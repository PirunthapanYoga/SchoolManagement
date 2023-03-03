﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230302193232_subjectModified")]
    partial class subjectModified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("API.Entities.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("API.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("API.Entities.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("API.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ClassRoomTeacher", b =>
                {
                    b.Property<int>("ClassRoomsClassRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClassRoomsClassRoomId", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("ClassRoomTeacher");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeachersTeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectsID", "TeachersTeacherId");

                    b.HasIndex("TeachersTeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("API.Entities.Student", b =>
                {
                    b.HasOne("API.Entities.ClassRoom", null)
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassRoomTeacher", b =>
                {
                    b.HasOne("API.Entities.ClassRoom", null)
                        .WithMany()
                        .HasForeignKey("ClassRoomsClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("API.Entities.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.ClassRoom", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
