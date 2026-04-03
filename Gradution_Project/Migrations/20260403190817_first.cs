using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gradution_Project.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Emergency_Alerts",
                columns: table => new
                {
                    alert_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender_id = table.Column<int>(type: "int", nullable: false),
                    receiver_id = table.Column<int>(type: "int", nullable: false),
                    alert_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emergency_Alerts", x => x.alert_id);
                    table.ForeignKey(
                        name: "FK_Emergency_Alerts_Users_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emergency_Alerts_Users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pairings",
                columns: table => new
                {
                    pairing_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deaf_user_id = table.Column<int>(type: "int", nullable: false),
                    compainin_id = table.Column<int>(type: "int", nullable: false),
                    pairing_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairings", x => x.pairing_id);
                    table.ForeignKey(
                        name: "FK_Pairings_Users_compainin_id",
                        column: x => x.compainin_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pairings_Users_deaf_user_id",
                        column: x => x.deaf_user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sound_Histories",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    sound_label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sound_Histories", x => x.log_id);
                    table.ForeignKey(
                        name: "FK_Sound_Histories_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Preferences",
                columns: table => new
                {
                    pref_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    vibration_enabled = table.Column<bool>(type: "bit", nullable: false),
                    flash_enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Preferences", x => x.pref_id);
                    table.ForeignKey(
                        name: "FK_User_Preferences_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emergency_Alerts_receiver_id",
                table: "Emergency_Alerts",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Emergency_Alerts_sender_id",
                table: "Emergency_Alerts",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pairings_compainin_id",
                table: "Pairings",
                column: "compainin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pairings_deaf_user_id",
                table: "Pairings",
                column: "deaf_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sound_Histories_user_id",
                table: "Sound_Histories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Preferences_user_id",
                table: "User_Preferences",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emergency_Alerts");

            migrationBuilder.DropTable(
                name: "Pairings");

            migrationBuilder.DropTable(
                name: "Sound_Histories");

            migrationBuilder.DropTable(
                name: "User_Preferences");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
