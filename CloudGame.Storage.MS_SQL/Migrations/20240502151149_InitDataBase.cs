using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudGame.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOwn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataRegistration = table.Column<DateTime>(type: "datetime2", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tariff = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IsnNode);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    IsnNode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnOwner = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameServer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Games = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Сharacteristic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.IsnNode);
                    table.ForeignKey(
                        name: "FK_Server_Owner_IsnOwner",
                        column: x => x.IsnOwner,
                        principalTable: "Owner",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Server",
                columns: table => new
                {
                    IsnServer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsnUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Server", x => new { x.IsnServer, x.IsnUser });
                    table.ForeignKey(
                        name: "FK_User_Server_Server_IsnServer",
                        column: x => x.IsnServer,
                        principalTable: "Server",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Server_User_IsnUser",
                        column: x => x.IsnUser,
                        principalTable: "User",
                        principalColumn: "IsnNode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_NameOwn",
                table: "Owner",
                column: "NameOwn");

            migrationBuilder.CreateIndex(
                name: "IX_Server_IsnOwner",
                table: "Server",
                column: "IsnOwner");

            migrationBuilder.CreateIndex(
                name: "IX_Server_NameServer_IsnOwner",
                table: "Server",
                columns: new[] { "NameServer", "IsnOwner" });

            migrationBuilder.CreateIndex(
                name: "IX_User_NameUser",
                table: "User",
                column: "NameUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_Server_IsnServer_IsnUser",
                table: "User_Server",
                columns: new[] { "IsnServer", "IsnUser" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Server_IsnUser",
                table: "User_Server",
                column: "IsnUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Server");

            migrationBuilder.DropTable(
                name: "Server");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
