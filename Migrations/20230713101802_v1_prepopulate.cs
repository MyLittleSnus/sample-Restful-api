using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodsApi.Migrations
{
    /// <inheritdoc />
    public partial class v1_prepopulate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "goods",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.InsertData(
                table: "goods",
                columns: new[] { "Id", "Category", "Cost", "Name" },
                values: new object[,]
                {
                    { "17493c23-5f61-4fef-8157-1fb98e3d3b42", 0, 18000.0, "IPhone 11" },
                    { "46c1ef37-7fc8-4aa0-8d45-a587818021b4", 0, 20000.0, "TV LG 520" },
                    { "4c72a1a0-7628-4de0-af15-15359a5dcddd", 0, 25000.0, "Samsumg S20 Ultra" },
                    { "662a46d3-dd54-4eee-a85e-4f203d7a6375", 0, 30000.0, "MacBook Air M1" },
                    { "ff0de1a4-0ebc-43c4-860d-d4e3cf0f91d6", 0, 45000.0, "MacBook Air M2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "goods",
                keyColumn: "Id",
                keyValue: "17493c23-5f61-4fef-8157-1fb98e3d3b42");

            migrationBuilder.DeleteData(
                table: "goods",
                keyColumn: "Id",
                keyValue: "46c1ef37-7fc8-4aa0-8d45-a587818021b4");

            migrationBuilder.DeleteData(
                table: "goods",
                keyColumn: "Id",
                keyValue: "4c72a1a0-7628-4de0-af15-15359a5dcddd");

            migrationBuilder.DeleteData(
                table: "goods",
                keyColumn: "Id",
                keyValue: "662a46d3-dd54-4eee-a85e-4f203d7a6375");

            migrationBuilder.DeleteData(
                table: "goods",
                keyColumn: "Id",
                keyValue: "ff0de1a4-0ebc-43c4-860d-d4e3cf0f91d6");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "goods",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
