using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_datatype_timeframe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaching",
                table: "Teaching");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "TimeFrame");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "TimeFrame");

            migrationBuilder.AddColumn<string>(
                name: "EndingTime",
                table: "TimeFrame",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartingTime",
                table: "TimeFrame",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTeaching",
                table: "Teaching",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 435, DateTimeKind.Local).AddTicks(7434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 435, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 749, DateTimeKind.Local).AddTicks(7664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 430, DateTimeKind.Local).AddTicks(3243));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 741, DateTimeKind.Local).AddTicks(8820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 423, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaching",
                table: "Teaching",
                column: "IdTeaching");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "402d8e17-df3f-40bf-8edb-0cc1e40e5f93");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "4627d6bd-bfb7-4556-991b-c1d0a6ba9207");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "845b27b0-bebb-4330-9a65-ae0b1266c75d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93cae98f-8289-4caf-8ad1-1387b38c0ce5", "AQAAAAEAACcQAAAAEOt3EXWAmGJwDSVW/bVc91VARPvY2rS8+YDve4iMR29sxUecGbt2K2S4wcIf2SZFRw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_IdLecturer",
                table: "Teaching",
                column: "IdLecturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teaching",
                table: "Teaching");

            migrationBuilder.DropIndex(
                name: "IX_Teaching_IdLecturer",
                table: "Teaching");

            migrationBuilder.DropColumn(
                name: "EndingTime",
                table: "TimeFrame");

            migrationBuilder.DropColumn(
                name: "StartingTime",
                table: "TimeFrame");

            migrationBuilder.DropColumn(
                name: "IdTeaching",
                table: "Teaching");

            migrationBuilder.AddColumn<int>(
                name: "EndTime",
                table: "TimeFrame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartTime",
                table: "TimeFrame",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 435, DateTimeKind.Local).AddTicks(7434),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 435, DateTimeKind.Local).AddTicks(7292),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 430, DateTimeKind.Local).AddTicks(3243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 749, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 16, 15, 15, 423, DateTimeKind.Local).AddTicks(3388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 741, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teaching",
                table: "Teaching",
                columns: new[] { "IdLecturer", "IdClass" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "711c00d7-9c54-4ce2-bbe7-ac998e933f6e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "797435df-843a-4efc-942c-b50bde2e1ec8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ea92f41f-3685-4c8d-b85c-c229f35d90a7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2e477f34-22e2-422c-b257-c24e761ea9a9", "AQAAAAEAACcQAAAAEGyXjtBUAedqw3i/eXcpEaodwz1aqXJJxSd1tKgWFhWe3PrrnRhP/DFvD09IkkSu/g==" });
        }
    }
}
