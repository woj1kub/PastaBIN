using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PastaID",
                table: "PastaBinds",
                newName: "TxtID");

            migrationBuilder.AddColumn<int>(
                name: "ImgID",
                table: "PastaBinds",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgID",
                table: "PastaBinds");

            migrationBuilder.RenameColumn(
                name: "TxtID",
                table: "PastaBinds",
                newName: "PastaID");
        }
    }
}
