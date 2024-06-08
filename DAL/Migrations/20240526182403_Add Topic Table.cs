using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa01e13b-ad39-4bf1-9283-3c27be9e4be3", "649ad09e-30cb-4490-a3a0-bd955e5bb820", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc97153-b884-4b2a-80bc-57c0eca293ec", "8090840f-ad69-40a0-9593-9f7b2fbcb8e7", "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9018a39-783b-4b76-b4f3-39f46cdf2bdb", "4fdfb91f-d830-4668-97f5-32e61c5939a4", "Student", "STUDENT" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicId",
                table: "Courses",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Topics_TopicId",
                table: "Courses",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Topics_TopicId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TopicId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa01e13b-ad39-4bf1-9283-3c27be9e4be3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc97153-b884-4b2a-80bc-57c0eca293ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9018a39-783b-4b76-b4f3-39f46cdf2bdb");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Courses");

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
        }
    }
}
