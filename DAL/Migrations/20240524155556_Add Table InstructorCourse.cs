using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddTableInstructorCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11900804-cdf6-419f-84f2-1e11698bfd5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fb760e3-3c82-4f41-a16a-bec4b0832a9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ffaea8a-03d0-4450-860d-4690b4fdb8f3");

            migrationBuilder.CreateTable(
                name: "InstructorCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_users_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f5c45e8-5f09-471e-8b22-9e8b69ab8b20", "25c4f040-d5ac-40a4-9661-77837a5550cf", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b377d98-8130-4a28-9643-da4f5ad2d0cf", "05f13a3e-c1c9-4a03-9f68-da0cac0d89ec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1835271-f89e-49dd-8af3-45f8b6e81711", "1ae552c3-e84d-40a4-b413-21bbc4159653", "Instructor", "INSTRUCTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_CourseId",
                table: "InstructorCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_InstructorId",
                table: "InstructorCourse",
                column: "InstructorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorCourse");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f5c45e8-5f09-471e-8b22-9e8b69ab8b20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b377d98-8130-4a28-9643-da4f5ad2d0cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1835271-f89e-49dd-8af3-45f8b6e81711");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11900804-cdf6-419f-84f2-1e11698bfd5e", "ae193ac2-b260-492a-ae9a-32879eed9870", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2fb760e3-3c82-4f41-a16a-bec4b0832a9f", "61120971-ea3d-4206-ba7b-675ecad84207", "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ffaea8a-03d0-4450-860d-4690b4fdb8f3", "6fb86a14-13b5-4887-b1c9-c9fdde09def2", "Student", "STUDENT" });
        }
    }
}
