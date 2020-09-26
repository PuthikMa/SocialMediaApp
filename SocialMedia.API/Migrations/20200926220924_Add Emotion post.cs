using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMedia.API.Migrations
{
    public partial class AddEmotionpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmotionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmotionDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmotionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostEmotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmotionTypeId = table.Column<int>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostEmotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostEmotions_EmotionTypes_EmotionTypeId",
                        column: x => x.EmotionTypeId,
                        principalTable: "EmotionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostEmotions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostEmotions_EmotionTypeId",
                table: "PostEmotions",
                column: "EmotionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostEmotions_PostId",
                table: "PostEmotions",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostEmotions");

            migrationBuilder.DropTable(
                name: "EmotionTypes");
        }
    }
}
