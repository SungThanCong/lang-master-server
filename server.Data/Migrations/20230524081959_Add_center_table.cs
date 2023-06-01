using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_center_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(34),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 549, DateTimeKind.Local).AddTicks(5826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 85, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 531, DateTimeKind.Local).AddTicks(2108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 78, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    IdCenter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.IdCenter);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "38dc0758-4186-4c5a-b392-bc75c144cea9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "4d62a0bf-9130-45e0-ab7c-b256299c44d9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "98496d8b-a063-47bc-9a61-2694779d4309");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb4e4cb3-4165-422a-bf54-672bf44b63ae", "AQAAAAEAACcQAAAAEM/RRN90Wel5cnLsEu4zRTyhNz8tLL57hAqh8WxgMlaGC6gQAyMPaVjgkSbZ7G4Ztg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 97, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 85, DateTimeKind.Local).AddTicks(3815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 549, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 18, 9, 56, 42, 78, DateTimeKind.Local).AddTicks(746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 531, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "06cf407c-35f5-4437-abc6-361f27025b0a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "8f50c2e2-d931-4b0b-bc73-5e72c937e92f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bd41efe8-d821-419f-b66b-edd445085db7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b3eb902-d49a-41e4-b637-72d2a529fe77", "AQAAAAEAACcQAAAAENLyOuMIA3q4eaVQnnAQZZnoHVsYoBdqLurV9vySql8ea6LLAcINyLBTDmwnc44orA==" });
        }
    }
}
