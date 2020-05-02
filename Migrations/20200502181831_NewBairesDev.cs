using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class NewBairesDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BairesDev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CurrentRole = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    NumberOfRecommendations = table.Column<int>(nullable: true),
                    NumberOfConnections = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BairesDev", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BairesDev");
        }
    }
}
