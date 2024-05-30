using System;
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
                name: "FK_Cooks_PastaHistory_PastaHistoryHistoryID",
                table: "Cooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_PastaSharingSettings_PastaSharingSettingsSharingSettingsID",
                table: "Cooks");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_PastaHistoryHistoryID",
                table: "Cooks");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_PastaSharingSettingsSharingSettingsID",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "PastaHistoryHistoryID",
                table: "Cooks");

            migrationBuilder.DropColumn(
                name: "PastaSharingSettingsSharingSettingsID",
                table: "Cooks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndSharingDate",
                table: "PastaSharingSettings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "PastaImage",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "PastaGroupSharing",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndSharingDate",
                table: "PastaSharingSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteDate",
                table: "PastaImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteTime",
                table: "PastaGroupSharing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PastaHistoryHistoryID",
                table: "Cooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PastaSharingSettingsSharingSettingsID",
                table: "Cooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_PastaHistoryHistoryID",
                table: "Cooks",
                column: "PastaHistoryHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_PastaSharingSettingsSharingSettingsID",
                table: "Cooks",
                column: "PastaSharingSettingsSharingSettingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_PastaHistory_PastaHistoryHistoryID",
                table: "Cooks",
                column: "PastaHistoryHistoryID",
                principalTable: "PastaHistory",
                principalColumn: "HistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_PastaSharingSettings_PastaSharingSettingsSharingSettingsID",
                table: "Cooks",
                column: "PastaSharingSettingsSharingSettingsID",
                principalTable: "PastaSharingSettings",
                principalColumn: "SharingSettingsID");
        }
    }
}
