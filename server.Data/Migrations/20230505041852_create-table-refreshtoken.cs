using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class createtablerefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 578, DateTimeKind.Local).AddTicks(7182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 559, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 567, DateTimeKind.Local).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 552, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1372)),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1649)),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_IdUser",
                table: "RefreshTokens",
                column: "IdUser",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 559, DateTimeKind.Local).AddTicks(4217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 578, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 552, DateTimeKind.Local).AddTicks(6459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 567, DateTimeKind.Local).AddTicks(6516));
        }
    }
}
