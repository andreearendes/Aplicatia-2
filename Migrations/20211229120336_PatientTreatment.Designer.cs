﻿// <auto-generated />
using Aplicatia_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplicatia_2.Migrations
{
    [DbContext(typeof(Aplicatia_2Context))]
    [Migration("20211229120336_PatientTreatment")]
    partial class PatientTreatment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aplicatia_2.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DoctorFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Disease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("PatientFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Aplicatia_2.Models.PatientTreatment", b =>
                {
                    b.Property<int>("PatientTreatmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentID")
                        .HasColumnType("int");

                    b.HasKey("PatientTreatmentID");

                    b.HasIndex("PatientID");

                    b.HasIndex("TreatmentID");

                    b.ToTable("PatientTreatment");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Treatment", b =>
                {
                    b.Property<int>("TreatmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TreatmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TreatmentID");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Patient", b =>
                {
                    b.HasOne("Aplicatia_2.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Aplicatia_2.Models.PatientTreatment", b =>
                {
                    b.HasOne("Aplicatia_2.Models.Patient", "Patient")
                        .WithMany("PatientTreatments")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplicatia_2.Models.Treatment", "Treatment")
                        .WithMany("PatientTreatments")
                        .HasForeignKey("TreatmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Doctor", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Patient", b =>
                {
                    b.Navigation("PatientTreatments");
                });

            modelBuilder.Entity("Aplicatia_2.Models.Treatment", b =>
                {
                    b.Navigation("PatientTreatments");
                });
#pragma warning restore 612, 618
        }
    }
}