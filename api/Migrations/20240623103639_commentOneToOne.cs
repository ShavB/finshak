using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class commentOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "253c77f2-400b-45d7-beb1-0ce3ce12716f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d423d3ba-94b6-4851-9bc6-4ff0bb1ffa2a");

            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "319cfcea-8320-45f6-a98a-96fe359cbcce", null, "Admin", "ADMIN" },
                    { "7dbddd0d-007d-4d7e-afd1-5ab1c824db79", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppuserId",
                table: "Comments",
                column: "AppuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppuserId",
                table: "Comments",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppuserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppuserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "319cfcea-8320-45f6-a98a-96fe359cbcce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dbddd0d-007d-4d7e-afd1-5ab1c824db79");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "253c77f2-400b-45d7-beb1-0ce3ce12716f", null, "User", "USER" },
                    { "d423d3ba-94b6-4851-9bc6-4ff0bb1ffa2a", null, "Admin", "ADMIN" }
                });
        }
    }
}
