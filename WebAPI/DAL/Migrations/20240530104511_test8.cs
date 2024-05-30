using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "PastaGroupSharing",
                newName: "EndSharingDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PastaSharingSettings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PastaSharingSettings");

            migrationBuilder.RenameColumn(
                name: "EndSharingDate",
                table: "PastaGroupSharing",
                newName: "DeleteTime");
        }
    }
}
