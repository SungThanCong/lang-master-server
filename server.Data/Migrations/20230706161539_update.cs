using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillInfo_Course_IdCourse",
                table: "BillInfo");

            migrationBuilder.RenameColumn(
                name: "IdCourse",
                table: "BillInfo",
                newName: "IdClass");

            migrationBuilder.RenameIndex(
                name: "IX_BillInfo_IdCourse",
                table: "BillInfo",
                newName: "IX_BillInfo_IdClass");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 941, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 749, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 933, DateTimeKind.Local).AddTicks(5939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 741, DateTimeKind.Local).AddTicks(8820));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Bill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "b12da3cf-1a4b-4774-873f-15788dbab92d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "46dd09e7-dba3-4e7b-9168-fa15ec29246d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ad2882a3-5a4c-4b0e-92cf-2753641989d9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a3d6033-1361-4a10-9e78-ca8b9cd32629", "AQAAAAEAACcQAAAAEBVT9jZ8tcoCKXobh6tun5QikuGTPA/L12V/l+mPmkngjZzwqP7r8oDfPVaBfnRvkA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillInfo_Class_IdClass",
                table: "BillInfo",
                column: "IdClass",
                principalTable: "Class",
                principalColumn: "IdClass",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillInfo_Class_IdClass",
                table: "BillInfo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "IdClass",
                table: "BillInfo",
                newName: "IdCourse");

            migrationBuilder.RenameIndex(
                name: "IX_BillInfo_IdClass",
                table: "BillInfo",
                newName: "IX_BillInfo_IdCourse");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 755, DateTimeKind.Local).AddTicks(7583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 749, DateTimeKind.Local).AddTicks(7664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 941, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 2, 16, 55, 741, DateTimeKind.Local).AddTicks(8820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 933, DateTimeKind.Local).AddTicks(5939));

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

            migrationBuilder.AddForeignKey(
                name: "FK_BillInfo_Course_IdCourse",
                table: "BillInfo",
                column: "IdCourse",
                principalTable: "Course",
                principalColumn: "IdCourse",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
