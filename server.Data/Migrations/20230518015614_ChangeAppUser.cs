using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AppUsers",
                newName: "DisplayName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3591),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 102, DateTimeKind.Local).AddTicks(1899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 578, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 95, DateTimeKind.Local).AddTicks(3657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 567, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AppUsers",
                newName: "LastName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 588, DateTimeKind.Local).AddTicks(1372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 578, DateTimeKind.Local).AddTicks(7182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 102, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 5, 11, 18, 52, 567, DateTimeKind.Local).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 95, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
