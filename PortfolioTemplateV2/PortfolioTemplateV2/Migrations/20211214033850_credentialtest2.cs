using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class credentialtest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "hrM7Dx2fkc/mYzWadpVqIj6g6DihgMd6dp7VcS245QI=", "EsgMFJ0/60IOZp1IYzY/og==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "C9akJS62QloJvQLpdqNaFSFclEfhCD5uOY5FaFmPRQc=", "T6yiisb5PLH9Bu9RiRJ3fQ==" });
        }
    }
}
