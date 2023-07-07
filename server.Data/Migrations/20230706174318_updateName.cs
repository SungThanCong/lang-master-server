using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TimeFrame");

            migrationBuilder.AddColumn<bool>(
                name: "Activate",
                table: "TimeFrame",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 429, DateTimeKind.Local).AddTicks(977),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 429, DateTimeKind.Local).AddTicks(828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 423, DateTimeKind.Local).AddTicks(389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 941, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 414, DateTimeKind.Local).AddTicks(8421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 933, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "78242784-7da4-4551-81b9-3701814f26dd");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "5320d495-2cfc-479b-9419-5f43669cb9e8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c4c8681a-ed77-47af-b780-e4303f560478");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b00bfc7-b0c7-4f2d-8ae3-b773a31fbb3a", "AQAAAAEAACcQAAAAEI594sOx6W/Ci88yINNMOaYqQh3VABHgxomlgs/N4JeVsLKvZP3KePlOP5Uy87VY3Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activate",
                table: "TimeFrame");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TimeFrame",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 429, DateTimeKind.Local).AddTicks(977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 947, DateTimeKind.Local).AddTicks(3156),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 429, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 941, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 423, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 6, 23, 15, 38, 933, DateTimeKind.Local).AddTicks(5939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 7, 0, 43, 18, 414, DateTimeKind.Local).AddTicks(8421));

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
        }
    }
}
