using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystems.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanTableToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanNumber = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<float>(type: "real", nullable: false),
                    AmountTaken = table.Column<float>(type: "real", nullable: false),
                    PaidOff = table.Column<float>(type: "real", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTables", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanTables");
        }
    }
}
