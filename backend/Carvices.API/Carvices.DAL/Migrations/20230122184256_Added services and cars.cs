using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carvices.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addedservicesandcars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PayRate",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longtitude = table.Column<double>(type: "float", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HourEstimation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceActions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceWorkDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    FromHour = table.Column<int>(type: "int", nullable: true),
                    ToHour = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceWorkDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceWorkDays_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceActionWorkers",
                columns: table => new
                {
                    ServiceActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceActionWorkers", x => new { x.ServiceActionId, x.WorkerId });
                    table.ForeignKey(
                        name: "FK_ServiceActionWorkers_AspNetUsers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceActionWorkers_ServiceActions_ServiceActionId",
                        column: x => x.ServiceActionId,
                        principalTable: "ServiceActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobId",
                table: "AspNetUsers",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActions_ServiceId",
                table: "ServiceActions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActionWorkers_WorkerId",
                table: "ServiceActionWorkers",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWorkDays_ServiceId",
                table: "ServiceWorkDays",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Services_JobId",
                table: "AspNetUsers",
                column: "JobId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Services_JobId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ServiceActionWorkers");

            migrationBuilder.DropTable(
                name: "ServiceWorkDays");

            migrationBuilder.DropTable(
                name: "ServiceActions");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PayRate",
                table: "AspNetUsers");
        }
    }
}
