using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaImage_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_Cooks_CookID",
                table: "PastaSharingSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaImage_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaImage",
                principalColumn: "ImageID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaTxt",
                principalColumn: "PastaTxtID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_Cooks_CookID",
                table: "PastaSharingSettings",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaImage_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_Cooks_CookID",
                table: "PastaSharingSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaImage_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaImage",
                principalColumn: "ImageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaTxt",
                principalColumn: "PastaTxtID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_Cooks_CookID",
                table: "PastaHistory",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaHistory_PastaBinds_PastaBindID",
                table: "PastaHistory",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_Cooks_CookID",
                table: "PastaSharingSettings",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
