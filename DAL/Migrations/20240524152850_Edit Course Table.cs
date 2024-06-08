using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class EditCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32fdba1e-0e14-4259-b6ad-67b2d130d82b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d5d1328-f8b3-41e4-8686-ef3b742a8e10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e27b69db-62aa-49c6-b3a5-7529e64734b0");

            migrationBuilder.AlterColumn<string>(
                name: "Videos",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Videos",
                table: "Courses",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32fdba1e-0e14-4259-b6ad-67b2d130d82b", "f11142d8-ecb5-4e89-98e1-36ef7919ff3a", "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d5d1328-f8b3-41e4-8686-ef3b742a8e10", "d5b4ea27-10ff-403d-b833-0a1a04bc5531", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e27b69db-62aa-49c6-b3a5-7529e64734b0", "c2287af5-f437-4f77-ad7f-2e65ccc50475", "Admin", "ADMIN" });
        }
    }
}
