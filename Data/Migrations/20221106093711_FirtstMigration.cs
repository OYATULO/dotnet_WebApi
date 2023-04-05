using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetcore.Data.Migrations
{
    public partial class FirtstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    postId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 1, "the contnet post 1 this is the contntent", "title post 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 2, "the contnet post 2 this is the contntent", "title post 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 3, "the contnet post 3 this is the contntent", "title post 3" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 4, "the contnet post 4 this is the contntent", "title post 4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 5, "the contnet post 5 this is the contntent", "title post 5" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "postId", "Content", "Title" },
                values: new object[] { 6, "the contnet post 6 this is the contntent", "title post 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
