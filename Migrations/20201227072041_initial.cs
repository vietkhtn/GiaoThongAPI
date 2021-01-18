using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IThong.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenShipProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IDNo = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Addresses = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    AvatarUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenShipProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriversLicensesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicensesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laws",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Chuong = table.Column<int>(nullable: false),
                    NoiDungChuong = table.Column<string>(nullable: true),
                    Muc = table.Column<int>(nullable: false),
                    NoiDungMuc = table.Column<string>(nullable: true),
                    DieuLuat = table.Column<int>(nullable: false),
                    NoiDungDieuLuat = table.Column<string>(nullable: true),
                    Khoan = table.Column<int>(nullable: false),
                    NoiDungKhoan = table.Column<string>(nullable: true),
                    Diem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Fees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    AttachmentUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateCreateNewPassword = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CitizenShipProfiles_Id",
                        column: x => x.Id,
                        principalTable: "CitizenShipProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FrameNumber = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NumberPlate = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypeDriversLicenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    DriversLicensesTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypeDriversLicenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTypeDriversLicenseTypes_DriversLicensesTypes_DriversL~",
                        column: x => x.DriversLicensesTypeId,
                        principalTable: "DriversLicensesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleTypeDriversLicenseTypes_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(nullable: false),
                    JwtId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Invalidated = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MoneyTotal = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Vehicles_Id",
                        column: x => x.Id,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarginalSanctionsTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeViolation = table.Column<string>(nullable: true),
                    ViolatorId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AttachmentUrl = table.Column<string>(nullable: true),
                    VAT = table.Column<float>(nullable: false),
                    TotalMoney = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    UserHandleerId = table.Column<int>(nullable: false),
                    Filed = table.Column<bool>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarginalSanctionsTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarginalSanctionsTables_Users_UserHandleerId",
                        column: x => x.UserHandleerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarginalSanctionsTables_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarginalSanctionsTables_CitizenShipProfiles_ViolatorId",
                        column: x => x.ViolatorId,
                        principalTable: "CitizenShipProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    VehicleOwnerId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedUserId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordProfiles_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordProfiles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordProfiles_CitizenShipProfiles_VehicleOwnerId",
                        column: x => x.VehicleOwnerId,
                        principalTable: "CitizenShipProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CitizenShipProfileId = table.Column<int>(nullable: false),
                    DriversLicensesTypeId = table.Column<int>(nullable: false),
                    GrantedDate = table.Column<DateTime>(nullable: false),
                    VehicleTypeDriversLicenseTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenses_CitizenShipProfiles_CitizenShipProfileId",
                        column: x => x.CitizenShipProfileId,
                        principalTable: "CitizenShipProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversLicenses_DriversLicensesTypes_DriversLicensesTypeId",
                        column: x => x.DriversLicensesTypeId,
                        principalTable: "DriversLicensesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversLicenses_VehicleTypeDriversLicenseTypes_VehicleTypeDr~",
                        column: x => x.VehicleTypeDriversLicenseTypeId,
                        principalTable: "VehicleTypeDriversLicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailViolations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableId = table.Column<int>(nullable: false),
                    ViolationId = table.Column<int>(nullable: false),
                    Money = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailViolations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailViolations_MarginalSanctionsTables_TableId",
                        column: x => x.TableId,
                        principalTable: "MarginalSanctionsTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailViolations_Violations_ViolationId",
                        column: x => x.ViolationId,
                        principalTable: "Violations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PenaltyVouchers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    PayerUserId = table.Column<int>(nullable: false),
                    MoneyNumber = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyVouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PenaltyVouchers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PenaltyVouchers_MarginalSanctionsTables_Id",
                        column: x => x.Id,
                        principalTable: "MarginalSanctionsTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PenaltyVouchers_Users_PayerUserId",
                        column: x => x.PayerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_userId",
                table: "Bills",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailViolations_TableId",
                table: "DetailViolations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailViolations_ViolationId",
                table: "DetailViolations",
                column: "ViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenses_CitizenShipProfileId",
                table: "DriversLicenses",
                column: "CitizenShipProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenses_DriversLicensesTypeId",
                table: "DriversLicenses",
                column: "DriversLicensesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenses_VehicleTypeDriversLicenseTypeId",
                table: "DriversLicenses",
                column: "VehicleTypeDriversLicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarginalSanctionsTables_UserHandleerId",
                table: "MarginalSanctionsTables",
                column: "UserHandleerId");

            migrationBuilder.CreateIndex(
                name: "IX_MarginalSanctionsTables_VehicleId",
                table: "MarginalSanctionsTables",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MarginalSanctionsTables_ViolatorId",
                table: "MarginalSanctionsTables",
                column: "ViolatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyVouchers_BankId",
                table: "PenaltyVouchers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyVouchers_PayerUserId",
                table: "PenaltyVouchers",
                column: "PayerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordProfiles_UpdatedUserId",
                table: "RecordProfiles",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordProfiles_VehicleId",
                table: "RecordProfiles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordProfiles_VehicleOwnerId",
                table: "RecordProfiles",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserID",
                table: "RefreshTokens",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypeDriversLicenseTypes_DriversLicensesTypeId",
                table: "VehicleTypeDriversLicenseTypes",
                column: "DriversLicensesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypeDriversLicenseTypes_VehicleTypeId",
                table: "VehicleTypeDriversLicenseTypes",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "DetailViolations");

            migrationBuilder.DropTable(
                name: "DriversLicenses");

            migrationBuilder.DropTable(
                name: "Laws");

            migrationBuilder.DropTable(
                name: "PenaltyVouchers");

            migrationBuilder.DropTable(
                name: "RecordProfiles");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "VehicleTypeDriversLicenseTypes");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "MarginalSanctionsTables");

            migrationBuilder.DropTable(
                name: "DriversLicensesTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "CitizenShipProfiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
