using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.DropIndex(
                name: "IX_PastaTxt_PastaBindID",
                table: "PastaTxt");

            migrationBuilder.DropIndex(
                name: "IX_PastaSharingSettings_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "PastaTxt",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "GroupKey",
                table: "PastaGroupSharing",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaGroupSharing_GroupKey",
                table: "PastaGroupSharing",
                column: "GroupKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds",
                column: "PastaBindID",
                principalTable: "PastaTxt",
                principalColumn: "PastaTxtID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds");

            migrationBuilder.DropForeignKey(
                name: "FK_PastaBinds_PastaTxt_PastaBindID",
                table: "PastaBinds");

            migrationBuilder.DropIndex(
                name: "IX_PastaSharingSettings_PastaBindID",
                table: "PastaSharingSettings");

            migrationBuilder.DropIndex(
                name: "IX_PastaGroupSharing_GroupKey",
                table: "PastaGroupSharing");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "PastaTxt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupKey",
                table: "PastaGroupSharing",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_PastaTxt_PastaBindID",
                table: "PastaTxt",
                column: "PastaBindID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PastaBinds_Cooks_CookID",
                table: "PastaBinds",
                column: "CookID",
                principalTable: "Cooks",
                principalColumn: "CookID");

            migrationBuilder.AddForeignKey(
                name: "FK_PastaTxt_PastaBinds_PastaBindID",
                table: "PastaTxt",
                column: "PastaBindID",
                principalTable: "PastaBinds",
                principalColumn: "PastaBindID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
