using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystems.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginPageToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.CreateTable(
                name: "LoginPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginPages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginPages");

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    TypeOfLoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountTaken = table.Column<float>(type: "real", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    LoanNumber = table.Column<int>(type: "int", nullable: false),
                    PaidOff = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.TypeOfLoan);
                });
        }
    }
}
