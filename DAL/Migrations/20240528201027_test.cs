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
                name: "PastaImage",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastaBindID = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    GlobalKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaImage", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "PastaTxt",
                columns: table => new
                {
                    PastaTxtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GlobalKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaTxt", x => x.PastaTxtID);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    CookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PastaHistoryHistoryID = table.Column<int>(type: "int", nullable: true),
                    PastaSharingSettingsSharingSettingsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.CookID);
                });

            migrationBuilder.CreateTable(
                name: "PastaBinds",
                columns: table => new
                {
                    PastaBindID = table.Column<int>(type: "int", nullable: false),
                    PastaID = table.Column<int>(type: "int", nullable: false),
                    CookID = table.Column<int>(type: "int", nullable: false),
                    SharingSettingsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaBinds", x => x.PastaBindID);
                    table.ForeignKey(
                        name: "FK_PastaBinds_Cooks_CookID",
                        column: x => x.CookID,
                        principalTable: "Cooks",
                        principalColumn: "CookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PastaBinds_PastaImage_PastaBindID",
                        column: x => x.PastaBindID,
                        principalTable: "PastaImage",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastaBinds_PastaTxt_PastaBindID",
                        column: x => x.PastaBindID,
                        principalTable: "PastaTxt",
                        principalColumn: "PastaTxtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaGroupSharing",
                columns: table => new
                {
                    GroupSharingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PastaBindID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaGroupSharing", x => x.GroupSharingID);
                    table.ForeignKey(
                        name: "FK_PastaGroupSharing_PastaBinds_PastaBindID",
                        column: x => x.PastaBindID,
                        principalTable: "PastaBinds",
                        principalColumn: "PastaBindID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaHistory",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookID = table.Column<int>(type: "int", nullable: false),
                    PastaBindID = table.Column<int>(type: "int", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaHistory", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_PastaHistory_Cooks_CookID",
                        column: x => x.CookID,
                        principalTable: "Cooks",
                        principalColumn: "CookID");
                    table.ForeignKey(
                        name: "FK_PastaHistory_PastaBinds_PastaBindID",
                        column: x => x.PastaBindID,
                        principalTable: "PastaBinds",
                        principalColumn: "PastaBindID");
                });

            migrationBuilder.CreateTable(
                name: "PastaSharingSettings",
                columns: table => new
                {
                    SharingSettingsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookID = table.Column<int>(type: "int", nullable: false),
                    PastaBindID = table.Column<int>(type: "int", nullable: false),
                    EndSharingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaSharingSettings", x => x.SharingSettingsID);
                    table.ForeignKey(
                        name: "FK_PastaSharingSettings_Cooks_CookID",
                        column: x => x.CookID,
                        principalTable: "Cooks",
                        principalColumn: "CookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastaSharingSettings_PastaBinds_PastaBindID",
                        column: x => x.PastaBindID,
                        principalTable: "PastaBinds",
                        principalColumn: "PastaBindID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_PastaHistoryHistoryID",
                table: "Cooks",
                column: "PastaHistoryHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_PastaSharingSettingsSharingSettingsID",
                table: "Cooks",
                column: "PastaSharingSettingsSharingSettingsID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaBinds_CookID",
                table: "PastaBinds",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaGroupSharing_PastaBindID",
                table: "PastaGroupSharing",
                column: "PastaBindID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaHistory_CookID",
                table: "PastaHistory",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaHistory_PastaBindID",
                table: "PastaHistory",
                column: "PastaBindID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_CookID",
                table: "PastaSharingSettings",
                column: "CookID");

            migrationBuilder.CreateIndex(
                name: "IX_PastaSharingSettings_PastaBindID",
                table: "PastaSharingSettings",
                column: "PastaBindID",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_PastaHistory_PastaHistoryHistoryID",
                table: "Cooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_PastaSharingSettings_PastaSharingSettingsSharingSettingsID",
                table: "Cooks");

            migrationBuilder.DropTable(
                name: "PastaGroupSharing");

            migrationBuilder.DropTable(
                name: "PastaHistory");

            migrationBuilder.DropTable(
                name: "PastaSharingSettings");

            migrationBuilder.DropTable(
                name: "PastaBinds");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "PastaImage");

            migrationBuilder.DropTable(
                name: "PastaTxt");
        }
    }
}
