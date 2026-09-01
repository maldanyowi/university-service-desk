using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityServiceDesk.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ServiceRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_UserId",
                table: "ServiceRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_AspNetUsers_UserId",
                table: "ServiceRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_AspNetUsers_UserId",
                table: "ServiceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRequests_UserId",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceRequests");
        }
    }
}
