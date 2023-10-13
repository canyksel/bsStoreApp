using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14edf266-e5c3-42a1-bd6f-0ee5ad8f45c6", "635021c1-ed87-4ff4-b359-ff032a5783c4", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0fab7e2-87f4-4062-8201-36fb77cb0864", "30831088-7b6c-47ce-82a5-5a9bdef9466a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f642f7c8-a422-4665-897b-ed16b87f62c5", "1dffc99e-57b0-46a3-a76d-91010769bc48", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14edf266-e5c3-42a1-bd6f-0ee5ad8f45c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0fab7e2-87f4-4062-8201-36fb77cb0864");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f642f7c8-a422-4665-897b-ed16b87f62c5");
        }
    }
}
