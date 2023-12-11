using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcf802f5-380c-4b4c-880b-dba13b52619a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e07e0990-49cf-4a53-83ff-fa69e7e5ffc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3aee5c0-fed6-498a-afe3-2eb612d0ed40");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fec5c4a-c4ad-4224-b5f8-1c1bf1f74982", "f5e86c2a-645f-4a5c-b0ba-4de7e6afb201", "Admin", "ADMIN" },
                    { "68237de3-e856-4410-87f4-e70e3c733a5a", "c416f6d8-cb95-4774-bbd5-1eddacff013d", "Editor", "EDITOR" },
                    { "7a900870-a350-40c9-bbb1-e855bb8ed148", "24c94dbf-7870-4f3a-b857-7e60aff40821", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Network" },
                    { 3, "Database Management Systems" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fec5c4a-c4ad-4224-b5f8-1c1bf1f74982");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68237de3-e856-4410-87f4-e70e3c733a5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a900870-a350-40c9-bbb1-e855bb8ed148");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcf802f5-380c-4b4c-880b-dba13b52619a", "b8eb6f35-9d3d-4a15-be05-fd177fe12ee4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e07e0990-49cf-4a53-83ff-fa69e7e5ffc2", "3563a6c8-62c8-4480-8e63-9060ef3dbd79", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3aee5c0-fed6-498a-afe3-2eb612d0ed40", "8a2b30f0-0b79-413a-9c0e-22faf7a2edde", "Editor", "EDITOR" });
        }
    }
}
