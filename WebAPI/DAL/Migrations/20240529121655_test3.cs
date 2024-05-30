using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GlobalKey",
                table: "PastaTxt");

            migrationBuilder.DropColumn(
                name: "GlobalKey",
                table: "PastaImage");

            migrationBuilder.AddColumn<string>(
                name: "GlobalKey",
                table: "PastaBinds",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Cooks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PastaBinds_GlobalKey",
                table: "PastaBinds",
                column: "GlobalKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_Login",
                table: "Cooks",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PastaBinds_GlobalKey",
                table: "PastaBinds");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_Login",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "GlobalKey",
                table: "PastaBinds");

            migrationBuilder.AddColumn<string>(
                name: "GlobalKey",
                table: "PastaTxt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GlobalKey",
                table: "PastaImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Cooks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
