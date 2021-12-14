using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateV2.Migrations
{
    public partial class credentialtest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
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
                values: new object[] { "DHQV5r4/PTW6qaKXa8h7GDs12F3sgoMeH4+Z+CGGuRU=", "cQfwROyOoQwOpq4ZtAdzVA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
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
                values: new object[] { "MObIQJ3fRNiaHcJAGhqrrKEozD9DRJg/8EZvXDWvwgI=", "Nf4KUyVGBHTRb5vPWU7s3Q==" });
        }
    }
}
