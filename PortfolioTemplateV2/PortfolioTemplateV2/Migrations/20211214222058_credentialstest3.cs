using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class credentialstest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "wy4vvGOxq2tkMlslOpUmXdIh7Mtqyt3HdSWVnPDaU+4=", "iV3gMedoptQYfdaq3HECAg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "hrM7Dx2fkc/mYzWadpVqIj6g6DihgMd6dp7VcS245QI=", "EsgMFJ0/60IOZp1IYzY/og==" });
        }
    }
}
