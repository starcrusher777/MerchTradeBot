using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initital6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Offer");

            migrationBuilder.AddColumn<string>(
                name: "OfferType",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserEntityId",
                table: "Offer",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_UserEntityId",
                table: "Offer",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_User_UserEntityId",
                table: "Offer",
                column: "UserEntityId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_User_UserEntityId",
                table: "Offer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Offer_UserEntityId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "OfferType",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Offer");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
