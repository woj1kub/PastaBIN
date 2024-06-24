using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
