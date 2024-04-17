using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cook",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PastaInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PastaInfo_Cook_UserID",
                        column: x => x.UserID,
                        principalTable: "Cook",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PastaInfoID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PastaHistory_Cook_UserID",
                        column: x => x.UserID,
                        principalTable: "Cook",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastaHistory_PastaInfo_PastaInfoID",
                        column: x => x.PastaInfoID,
                        principalTable: "PastaInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PastaImg",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastaInfoID = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaImg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PastaImg_PastaInfo_PastaInfoID",
                        column: x => x.PastaInfoID,
                        principalTable: "PastaInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaSharingSettings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PastaInfoID = table.Column<int>(type: "int", nullable: false),
                    EndSharingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaSharingSettings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PastaSharingSettings_Cook_UserID",
                        column: x => x.UserID,
                        principalTable: "Cook",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PastaSharingSettings_PastaInfo_PastaInfoID",
                        column: x => x.PastaInfoID,
                        principalTable: "PastaInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaText",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastaInfoID = table.Column<int>(type: "int", nullable: false),
                    Pasta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaText", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PastaText_PastaInfo_PastaInfoID",
                        column: x => x.PastaInfoID,
                        principalTable: "PastaInfo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PastaHistory_PastaInfoID",
                table: "PastaHistory",
                column: "PastaInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaHistory_UserID",
                table: "PastaHistory",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaImg_PastaInfoID",
                table: "PastaImg",
                column: "PastaInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaInfo_UserID",
                table: "PastaInfo",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_PastaInfoID",
                table: "PastaSharingSettings",
                column: "PastaInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_UserID",
                table: "PastaSharingSettings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaText_PastaInfoID",
                table: "PastaText",
                column: "PastaInfoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PastaHistory");

            migrationBuilder.DropTable(
                name: "PastaImg");

            migrationBuilder.DropTable(
                name: "PastaSharingSettings");

            migrationBuilder.DropTable(
                name: "PastaText");

            migrationBuilder.DropTable(
                name: "PastaInfo");

            migrationBuilder.DropTable(
                name: "Cook");
        }
    }
}
