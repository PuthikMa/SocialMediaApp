using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialMedia.API.Migrations
{
    public partial class AddEmotionPostFKwithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PostEmotions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostEmotions_UserId",
                table: "PostEmotions",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PostEmotions_AspNetUsers_UserId",
                table: "PostEmotions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostEmotions_AspNetUsers_UserId",
                table: "PostEmotions");

            migrationBuilder.DropIndex(
                name: "IX_PostEmotions_UserId",
                table: "PostEmotions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostEmotions");
        }
    }
}
