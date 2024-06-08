using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class removerelationsfromCoursetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_users_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_users_StudentId",
                table: "Courses");

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

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c277aee-d8ef-4ef7-8374-3b41df2adc9d", "23df1aef-a36a-4a05-9ecb-c700e9096e43", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1407083b-b1c6-4ad2-a1ff-24ec86b84c1d", "1aeb1006-cd20-472d-a01e-448a17575c37", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ed7bf45-264b-42f0-a3fd-423df541c4be", "c92ea999-6729-4ac8-901f-7e277e6c6541", "Instructor", "INSTRUCTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_users_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_users_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_users_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_users_StudentId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c277aee-d8ef-4ef7-8374-3b41df2adc9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1407083b-b1c6-4ad2-a1ff-24ec86b84c1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ed7bf45-264b-42f0-a3fd-423df541c4be");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InstructorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_users_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_users_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
