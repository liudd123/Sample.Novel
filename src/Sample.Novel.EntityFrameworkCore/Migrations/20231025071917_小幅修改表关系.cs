using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Novel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class 小幅修改表关系 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChapterText_AppChapter_Id",
                table: "AppChapterText");

            migrationBuilder.CreateIndex(
                name: "IX_AppChapterText_ChapterId",
                table: "AppChapterText",
                column: "ChapterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppChapterText_AppChapter_ChapterId",
                table: "AppChapterText",
                column: "ChapterId",
                principalTable: "AppChapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppChapterText_AppChapter_ChapterId",
                table: "AppChapterText");

            migrationBuilder.DropIndex(
                name: "IX_AppChapterText_ChapterId",
                table: "AppChapterText");

            migrationBuilder.AddForeignKey(
                name: "FK_AppChapterText_AppChapter_Id",
                table: "AppChapterText",
                column: "Id",
                principalTable: "AppChapter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
