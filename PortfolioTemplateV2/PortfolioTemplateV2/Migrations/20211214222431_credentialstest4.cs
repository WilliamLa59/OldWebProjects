using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class credentialstest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Credential",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "MObIQJ3fRNiaHcJAGhqrrKEozD9DRJg/8EZvXDWvwgI=", "Nf4KUyVGBHTRb5vPWU7s3Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Credential",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Credential",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "wy4vvGOxq2tkMlslOpUmXdIh7Mtqyt3HdSWVnPDaU+4=", "iV3gMedoptQYfdaq3HECAg==" });
        }
    }
}
