using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 85, DateTimeKind.Local).AddTicks(3815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 102, DateTimeKind.Local).AddTicks(1899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 78, DateTimeKind.Local).AddTicks(746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 95, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"), "06cf407c-35f5-4437-abc6-361f27025b0a", "Employee role", "employee", "employee" },
                    { new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"), "8f50c2e2-d931-4b0b-bc73-5e72c937e92f", "Lecturer role", "lecturer", "lecturer" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "bd41efe8-d821-419f-b66b-edd445085db7", "Administrator role", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DisplayName", "Dob", "Email", "EmailConfirmed", "Gender", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "Quang Nam", "3b3eb902-d49a-41e4-b637-72d2a529fe77", "Luu Le Ba Chinh", new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "chinh.admin@gmail.com", true, 0, null, false, null, "chinh.admin@gmail.com", "admin", "AQAAAAEAACcQAAAAENLyOuMIA3q4eaVQnnAQZZnoHVsYoBdqLurV9vySql8ea6LLAcINyLBTDmwnc44orA==", null, false, "", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3591),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 107, DateTimeKind.Local).AddTicks(3456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 102, DateTimeKind.Local).AddTicks(1899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 85, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 8, 56, 14, 95, DateTimeKind.Local).AddTicks(3657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 78, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
