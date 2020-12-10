﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Permissions.DAL.Context;

namespace Permissions.Api.Migrations
{
    [DbContext(typeof(PermissionsContext))]
    partial class PermissionsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Permissions.DAL.Entities.Permit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PermitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermitTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermitTypeId");

                    b.ToTable("Permits");
                });

            modelBuilder.Entity("Permissions.DAL.Entities.PermitType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermitsTypes");
                });

            modelBuilder.Entity("Permissions.DAL.Entities.Permit", b =>
                {
                    b.HasOne("Permissions.DAL.Entities.PermitType", "PermitType")
                        .WithMany()
                        .HasForeignKey("PermitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermitType");
                });
#pragma warning restore 612, 618
        }
    }
}