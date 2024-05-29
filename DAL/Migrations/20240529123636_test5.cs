using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.AddColumn<int>(
                name: "PastaBindID",
                table: "PastaTxt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SharingSettingsID",
                table: "PastaBinds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PastaID",
                table: "PastaBinds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PastaTxt_PastaBindID",
                table: "PastaTxt",
                column: "PastaBindID",
                unique: true);

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
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.DropIndex(
                name: "IX_PastaTxt_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.DropColumn(
                name: "PastaBindID",
                table: "PastaTxt");

            migrationBuilder.AlterColumn<int>(
                name: "SharingSettingsID",
                table: "PastaBinds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PastaID",
                table: "PastaBinds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaTxt",
                principalColumn: "PastaTxtID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
