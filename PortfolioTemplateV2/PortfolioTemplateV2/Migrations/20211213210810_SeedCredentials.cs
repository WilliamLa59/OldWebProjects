using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class SeedCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Credential",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "password", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credential");
        }
    }
}
