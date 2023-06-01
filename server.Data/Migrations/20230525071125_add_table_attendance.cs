using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_table_attendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 447, DateTimeKind.Local).AddTicks(8230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 447, DateTimeKind.Local).AddTicks(7991),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 438, DateTimeKind.Local).AddTicks(2646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 549, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 425, DateTimeKind.Local).AddTicks(7275),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 531, DateTimeKind.Local).AddTicks(2108));

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClassTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => new { x.IdStudent, x.IdClassTime });
                    table.ForeignKey(
                        name: "FK_Attendance_ClassTime_IdClassTime",
                        column: x => x.IdClassTime,
                        principalTable: "ClassTime",
                        principalColumn: "IdClassTime",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("09480504-4c27-4af7-a492-adcdbbe6c097"),
                column: "ConcurrencyStamp",
                value: "2c6177a0-5992-49c6-bea5-afbedf3df253");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fcbb353-ae6b-4936-9fdd-950efeb452a6"),
                column: "ConcurrencyStamp",
                value: "2ae877f3-85de-429f-978d-ecfd1bb98e90");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "aba2ea72-15ac-4e4b-bbac-cef9163da088");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c25bd868-d81c-4d3f-83ee-c31469395096", "AQAAAAEAACcQAAAAEAprutCvPMyJ15wCWHwgHQa1Kn+yQbRRmijSOW/cw2GxU+5pM5K1h6h0Nh/8sHgNNw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_IdClassTime",
                table: "Attendance",
                column: "IdClassTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 447, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 556, DateTimeKind.Local).AddTicks(34),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 447, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedDate",
                table: "Exam",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 549, DateTimeKind.Local).AddTicks(5826),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 438, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 24, 15, 19, 59, 531, DateTimeKind.Local).AddTicks(2108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 25, 14, 11, 25, 425, DateTimeKind.Local).AddTicks(7275));

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
    }
}
