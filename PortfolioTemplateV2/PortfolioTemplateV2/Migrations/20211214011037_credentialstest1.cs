using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class credentialstest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "C9akJS62QloJvQLpdqNaFSFclEfhCD5uOY5FaFmPRQc=", "T6yiisb5PLH9Bu9RiRJ3fQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SS6Y/x+Z3kBQFl3vcrLrNOJqBSem3V6QmSLp4LeoRt4=", "0qlpxwzBwTRYMXv2ofEsUg==" });
        }
    }
}
