using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID");
        }
    }
}
