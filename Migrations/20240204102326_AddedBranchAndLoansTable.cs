using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystems.Migrations
{
    /// <inheritdoc />
    public partial class AddedBranchAndLoansTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfEmps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    TypeOfLoan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanNumber = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    AmountTaken = table.Column<float>(type: "real", nullable: false),
                    PaidOff = table.Column<float>(type: "real", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.TypeOfLoan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
