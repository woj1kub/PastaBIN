using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaImage_PastaBinds_PastaBindID",
                table: "PastaImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaImage_PastaBinds_PastaBindID",
                table: "PastaImage",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaImage_PastaBinds_PastaBindID",
                table: "PastaImage");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaImage_PastaBinds_PastaBindID",
                table: "PastaImage",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
