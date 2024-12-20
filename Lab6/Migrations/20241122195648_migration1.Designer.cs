﻿// <auto-generated />
using System;
using Lab6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab6.Migrations
{
    [DbContext(typeof(CallCenterDbContext))]
    [Migration("20241122195648_migration1")]
    partial class migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab6.Models.CallCenter", b =>
                {
                    b.Property<int>("CallCenter_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallCenter_Id"), 1L, 1);

                    b.Property<string>("CallCenterAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallCenterOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallCenter_Id");

                    b.ToTable("CallCenters");
                });

            modelBuilder.Entity("Lab6.Models.CommonProblem", b =>
                {
                    b.Property<int>("Problem_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Problem_Id"), 1L, 1);

                    b.Property<string>("OtherProblemDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Problem_Id");

                    b.ToTable("CommonProblems");
                });

            modelBuilder.Entity("Lab6.Models.CommonSolution", b =>
                {
                    b.Property<int>("Solution_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Solution_Id"), 1L, 1);

                    b.Property<string>("OtherSolutionDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Solution_Id");

                    b.ToTable("CommonSolutions");
                });

            modelBuilder.Entity("Lab6.Models.Contract", b =>
                {
                    b.Property<int>("Contract_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Contract_Id"), 1L, 1);

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Contract_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Customer_Id"), 1L, 1);

                    b.Property<string>("CustomerAddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddressLine3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TownCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Customer_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Lab6.Models.CustomerCall", b =>
                {
                    b.Property<int>("Call_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Call_Id"), 1L, 1);

                    b.Property<int>("CallCenter_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CallDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CallDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallOtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CallOutcomeCode")
                        .HasColumnType("int");

                    b.Property<int>("CallStatusCode")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<int>("RecommendedSolution_Id")
                        .HasColumnType("int");

                    b.Property<int>("Staff_Id")
                        .HasColumnType("int");

                    b.Property<string>("TailoredSolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Call_Id");

                    b.HasIndex("CallCenter_Id");

                    b.HasIndex("CallOutcomeCode");

                    b.HasIndex("CallStatusCode");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("RecommendedSolution_Id");

                    b.HasIndex("Staff_Id");

                    b.ToTable("CustomerCalls");
                });

            modelBuilder.Entity("Lab6.Models.RefCallOutcome", b =>
                {
                    b.Property<int>("CallOutcomeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallOutcomeCode"), 1L, 1);

                    b.Property<string>("CallOutcomeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherCallOutcomeDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallOutcomeCode");

                    b.ToTable("RefCallOutcomes");
                });

            modelBuilder.Entity("Lab6.Models.RefCallStatusCode", b =>
                {
                    b.Property<int>("CallStatusCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallStatusCode"), 1L, 1);

                    b.Property<string>("CallStatusComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallStatusDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CallStatusCode");

                    b.ToTable("RefCallStatusCodes");
                });

            modelBuilder.Entity("Lab6.Models.SolutionsForCommonProblem", b =>
                {
                    b.Property<int>("Problem_Id")
                        .HasColumnType("int");

                    b.Property<int>("Solution_Id")
                        .HasColumnType("int");

                    b.HasKey("Problem_Id", "Solution_Id");

                    b.HasIndex("Solution_Id");

                    b.ToTable("SolutionsForCommonProblems");
                });

            modelBuilder.Entity("Lab6.Models.Staff", b =>
                {
                    b.Property<int>("Staff_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Staff_Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Staff_Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Lab6.Models.Contract", b =>
                {
                    b.HasOne("Lab6.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Lab6.Models.CustomerCall", b =>
                {
                    b.HasOne("Lab6.Models.CallCenter", "CallCenter")
                        .WithMany()
                        .HasForeignKey("CallCenter_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.RefCallOutcome", "RefCallOutcome")
                        .WithMany()
                        .HasForeignKey("CallOutcomeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.RefCallStatusCode", "RefCallStatusCode")
                        .WithMany()
                        .HasForeignKey("CallStatusCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.CommonSolution", "CommonSolution")
                        .WithMany()
                        .HasForeignKey("RecommendedSolution_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("Staff_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CallCenter");

                    b.Navigation("CommonSolution");

                    b.Navigation("Customer");

                    b.Navigation("RefCallOutcome");

                    b.Navigation("RefCallStatusCode");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Lab6.Models.SolutionsForCommonProblem", b =>
                {
                    b.HasOne("Lab6.Models.CommonProblem", "CommonProblem")
                        .WithMany()
                        .HasForeignKey("Problem_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.CommonSolution", "CommonSolution")
                        .WithMany()
                        .HasForeignKey("Solution_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommonProblem");

                    b.Navigation("CommonSolution");
                });
#pragma warning restore 612, 618
        }
    }
}
