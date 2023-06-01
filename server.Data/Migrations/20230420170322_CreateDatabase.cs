using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ColumnTranscript",
                columns: table => new
                {
                    IdColumn = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnTranscript", x => x.IdColumn);
                });

            migrationBuilder.CreateTable(
                name: "CourseType",
                columns: table => new
                {
                    IdCourseType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseType", x => x.IdCourseType);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    IdLevel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Language = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.IdLevel);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    IdParameter = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.IdParameter);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    IdTestType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.IdTestType);
                });

            migrationBuilder.CreateTable(
                name: "TimeFrame",
                columns: table => new
                {
                    IdTimeFrame = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFrame", x => x.IdTimeFrame);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employee_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    IdLecturer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.IdLecturer);
                    table.ForeignKey(
                        name: "FK_Lecturer_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Student_AppUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    IdCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Fee = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLevel = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCourseType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.IdCourse);
                    table.ForeignKey(
                        name: "FK_Course_CourseType_IdCourseType",
                        column: x => x.IdCourseType,
                        principalTable: "CourseType",
                        principalColumn: "IdCourseType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Level_IdLevel",
                        column: x => x.IdLevel,
                        principalTable: "Level",
                        principalColumn: "IdLevel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmployee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 552, DateTimeKind.Local).AddTicks(6459)),
                    TotalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.IdBill);
                    table.ForeignKey(
                        name: "FK_Bill_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    IdClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IdCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_Class_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnCourse",
                columns: table => new
                {
                    IdColumn = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnCourse", x => new { x.IdCourse, x.IdColumn });
                    table.ForeignKey(
                        name: "FK_ColumnCourse_ColumnTranscript_IdColumn",
                        column: x => x.IdColumn,
                        principalTable: "ColumnTranscript",
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnCourse_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillInfo",
                columns: table => new
                {
                    IdBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillInfo", x => new { x.IdBill, x.IdCourse });
                    table.ForeignKey(
                        name: "FK_BillInfo_Bill_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bill",
                        principalColumn: "IdBill",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillInfo_Course_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassTime",
                columns: table => new
                {
                    IdClassTime = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTimeFrame = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTime", x => x.IdClassTime);
                    table.ForeignKey(
                        name: "FK_ClassTime_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTime_TimeFrame_IdTimeFrame",
                        column: x => x.IdTimeFrame,
                        principalTable: "TimeFrame",
                        principalColumn: "IdTimeFrame",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    IdExam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 4, 21, 0, 3, 22, 559, DateTimeKind.Local).AddTicks(4217)),
                    IdClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTestType = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdColumn = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestTime = table.Column<int>(type: "int", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.IdExam);
                    table.ForeignKey(
                        name: "FK_Exam_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_ColumnTranscript_IdColumn",
                        column: x => x.IdColumn,
                        principalTable: "ColumnTranscript",
                        principalColumn: "IdColumn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_TestType_IdTestType",
                        column: x => x.IdTestType,
                        principalTable: "TestType",
                        principalColumn: "IdTestType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learning",
                columns: table => new
                {
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learning", x => new { x.IdStudent, x.IdClass });
                    table.ForeignKey(
                        name: "FK_Learning_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Learning_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teaching",
                columns: table => new
                {
                    IdLecturer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClass = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaching", x => new { x.IdLecturer, x.IdClass });
                    table.ForeignKey(
                        name: "FK_Teaching_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teaching_Lecturer_IdLecturer",
                        column: x => x.IdLecturer,
                        principalTable: "Lecturer",
                        principalColumn: "IdLecturer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testing",
                columns: table => new
                {
                    IdStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdExam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false, defaultValue: 0f)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testing", x => new { x.IdStudent, x.IdExam });
                    table.ForeignKey(
                        name: "FK_Testing_Exam_IdExam",
                        column: x => x.IdExam,
                        principalTable: "Exam",
                        principalColumn: "IdExam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Testing_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdEmployee",
                table: "Bill",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IdStudent",
                table: "Bill",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_BillInfo_IdCourse",
                table: "BillInfo",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Class_IdCourse",
                table: "Class",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTime_IdClass",
                table: "ClassTime",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTime_IdTimeFrame",
                table: "ClassTime",
                column: "IdTimeFrame");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnCourse_IdColumn",
                table: "ColumnCourse",
                column: "IdColumn");

            migrationBuilder.CreateIndex(
                name: "IX_Course_IdCourseType",
                table: "Course",
                column: "IdCourseType");

            migrationBuilder.CreateIndex(
                name: "IX_Course_IdLevel",
                table: "Course",
                column: "IdLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdUser",
                table: "Employee",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_IdClass",
                table: "Exam",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_IdColumn",
                table: "Exam",
                column: "IdColumn");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_IdTestType",
                table: "Exam",
                column: "IdTestType");

            migrationBuilder.CreateIndex(
                name: "IX_Learning_IdClass",
                table: "Learning",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_IdUser",
                table: "Lecturer",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdUser",
                table: "Student",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teaching_IdClass",
                table: "Teaching",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Testing_IdExam",
                table: "Testing",
                column: "IdExam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "BillInfo");

            migrationBuilder.DropTable(
                name: "ClassTime");

            migrationBuilder.DropTable(
                name: "ColumnCourse");

            migrationBuilder.DropTable(
                name: "Learning");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Teaching");

            migrationBuilder.DropTable(
                name: "Testing");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "TimeFrame");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "ColumnTranscript");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseType");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
