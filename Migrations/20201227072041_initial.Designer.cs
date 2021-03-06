﻿// <auto-generated />
using System;
using HumanResource.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IThong.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201227072041_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.Law", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Chuong")
                        .HasColumnType("int");

                    b.Property<string>("Diem")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("DieuLuat")
                        .HasColumnType("int");

                    b.Property<int>("Khoan")
                        .HasColumnType("int");

                    b.Property<int>("Muc")
                        .HasColumnType("int");

                    b.Property<string>("NoiDungChuong")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NoiDungDieuLuat")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NoiDungKhoan")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NoiDungMuc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Laws");
                });

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Invalidated")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("JwtId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Used")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Token");

                    b.HasIndex("UserID");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreateNewPassword")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IThong.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameBank")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("IThong.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MoneyTotal")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("IThong.Entities.CitizenShipProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Addresses")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IDNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("CitizenShipProfiles");
                });

            modelBuilder.Entity("IThong.Entities.DetailViolation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("ViolationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("ViolationId");

                    b.ToTable("DetailViolations");
                });

            modelBuilder.Entity("IThong.Entities.DriversLicense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CitizenShipProfileId")
                        .HasColumnType("int");

                    b.Property<int>("DriversLicensesTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GrantedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("VehicleTypeDriversLicenseTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitizenShipProfileId");

                    b.HasIndex("DriversLicensesTypeId");

                    b.HasIndex("VehicleTypeDriversLicenseTypeId");

                    b.ToTable("DriversLicenses");
                });

            modelBuilder.Entity("IThong.Entities.DriversLicensesType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("DriversLicensesTypes");
                });

            modelBuilder.Entity("IThong.Entities.MarginalSanctionsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttachmentUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Filed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TimeViolation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TotalMoney")
                        .HasColumnType("int");

                    b.Property<int>("UserHandleerId")
                        .HasColumnType("int");

                    b.Property<float>("VAT")
                        .HasColumnType("float");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("ViolatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserHandleerId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("ViolatorId");

                    b.ToTable("MarginalSanctionsTables");
                });

            modelBuilder.Entity("IThong.Entities.PenaltyVoucher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MoneyNumber")
                        .HasColumnType("int");

                    b.Property<int>("PayerUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("PayerUserId");

                    b.ToTable("PenaltyVouchers");
                });

            modelBuilder.Entity("IThong.Entities.RecordProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UpdatedUserId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("VehicleOwnerId");

                    b.ToTable("RecordProfiles");
                });

            modelBuilder.Entity("IThong.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Color")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FrameNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("IThong.Entities.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Fees")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("IThong.Entities.VehicleTypeDriversLicenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DriversLicensesTypeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriversLicensesTypeId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("VehicleTypeDriversLicenseTypes");
                });

            modelBuilder.Entity("IThong.Entities.Violation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AttachmentUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.RefreshToken", b =>
                {
                    b.HasOne("HumanResource.ApplicationCore.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HumanResource.ApplicationCore.Entities.User", b =>
                {
                    b.HasOne("IThong.Entities.CitizenShipProfile", "CitizenShipProfile")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResource.ApplicationCore.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("IThong.Entities.Bill", b =>
                {
                    b.HasOne("IThong.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResource.ApplicationCore.Entities.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.DetailViolation", b =>
                {
                    b.HasOne("IThong.Entities.MarginalSanctionsTable", "GetMarginalSanctionsTable")
                        .WithMany("DetailViolations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.Violation", "Violation")
                        .WithMany("DetailViolations")
                        .HasForeignKey("ViolationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.DriversLicense", b =>
                {
                    b.HasOne("IThong.Entities.CitizenShipProfile", "CitizenShipProfile")
                        .WithMany("DriversLicenses")
                        .HasForeignKey("CitizenShipProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.DriversLicensesType", "DriversLicensesType")
                        .WithMany("DriversLicenses")
                        .HasForeignKey("DriversLicensesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.VehicleTypeDriversLicenseType", null)
                        .WithMany("DriversLicenses")
                        .HasForeignKey("VehicleTypeDriversLicenseTypeId");
                });

            modelBuilder.Entity("IThong.Entities.MarginalSanctionsTable", b =>
                {
                    b.HasOne("HumanResource.ApplicationCore.Entities.User", "UserHandleer")
                        .WithMany()
                        .HasForeignKey("UserHandleerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.CitizenShipProfile", "ViolatorProfile")
                        .WithMany("MarginalSanctionsTables")
                        .HasForeignKey("ViolatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.PenaltyVoucher", b =>
                {
                    b.HasOne("IThong.Entities.Bank", "Bank")
                        .WithMany("PenaltyVouchers")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.MarginalSanctionsTable", "MarginalSanctionsTable")
                        .WithMany("PenaltyVouchers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HumanResource.ApplicationCore.Entities.User", "PayerUser")
                        .WithMany()
                        .HasForeignKey("PayerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.RecordProfile", b =>
                {
                    b.HasOne("HumanResource.ApplicationCore.Entities.User", "UpdatedUser")
                        .WithMany()
                        .HasForeignKey("UpdatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.CitizenShipProfile", "VehicleOwner")
                        .WithMany("RecordProfiles")
                        .HasForeignKey("VehicleOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.Vehicle", b =>
                {
                    b.HasOne("IThong.Entities.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IThong.Entities.VehicleTypeDriversLicenseType", b =>
                {
                    b.HasOne("IThong.Entities.DriversLicensesType", "DriversLicensesType")
                        .WithMany("VehicleTypeDriversLicenseTypes")
                        .HasForeignKey("DriversLicensesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IThong.Entities.VehicleType", "GetVehicleType")
                        .WithMany("VehicleTypeDriversLicenseTypes")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
