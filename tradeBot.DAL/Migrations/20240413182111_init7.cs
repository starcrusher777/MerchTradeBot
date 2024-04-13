using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Password",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TelegramCacheId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TelegramId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TelegramCacheEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousMenu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramCacheEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TelegramCacheId",
                table: "User",
                column: "TelegramCacheId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_TelegramCacheEntity_TelegramCacheId",
                table: "User",
                column: "TelegramCacheId",
                principalTable: "TelegramCacheEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_TelegramCacheEntity_TelegramCacheId",
                table: "User");

            migrationBuilder.DropTable(
                name: "TelegramCacheEntity");

            migrationBuilder.DropIndex(
                name: "IX_User_TelegramCacheId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TelegramCacheId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "User");
        }
    }
}
