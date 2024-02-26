using BankingSystems.Data;
using BankingSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BankingSystems.Controllers
{
    public class LoanTableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanTableController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLoanTableViewModel addLoanTableViewModel)
        {
            if (string.IsNullOrWhiteSpace(addLoanTableViewModel.BranchName) ||
                string.IsNullOrWhiteSpace(addLoanTableViewModel.TypeOfLoan) ||
                addLoanTableViewModel.LoanNumber <= 0 || addLoanTableViewModel.Interest <= 0.0 || addLoanTableViewModel.AmountTaken <= 0.0 || addLoanTableViewModel.PaidOff<= 0.0)
            {
                // If any of the required fields are not filled, return to the view with an error message.
                ModelState.AddModelError("", "All fields are required");
                return View(addLoanTableViewModel);
            }

            var loanTable = new LoanTable
            {
                BranchName = addLoanTableViewModel.BranchName,
                TypeOfLoan = addLoanTableViewModel.TypeOfLoan,
                LoanNumber = addLoanTableViewModel.LoanNumber,
                Interest = addLoanTableViewModel.Interest,
                AmountTaken = addLoanTableViewModel.AmountTaken,
                PaidOff = addLoanTableViewModel.PaidOff,
            };

            await _context.LoanTables.AddAsync(loanTable);
            await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoanTables()
        {
            var loanTable = await _context.LoanTables.ToListAsync();
            return View(loanTable);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var loanTable = await _context.LoanTables.FindAsync(Id);
            return View(loanTable);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LoanTable loanTable)
        {
            var loanTables = await _context.LoanTables.FindAsync(loanTable.Id);
            if (loanTables != null)
            {
                loanTables.BranchName = loanTable.BranchName;
                loanTables.TypeOfLoan = loanTable.TypeOfLoan;
                loanTables.LoanNumber = loanTable.LoanNumber;
                loanTables.Interest = loanTable.Interest;
                loanTables.AmountTaken = loanTable.AmountTaken;
                loanTables.PaidOff = loanTable.PaidOff;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllLoanTables", "LoanTable");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(LoanTable loanTable)
        {
            var loanTables = _context.LoanTables.AsNoTracking().FirstOrDefault(x => x.Id == loanTable.Id);
            if (loanTable != null)
            {
                _context.LoanTables.Remove(loanTable);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllLoanTables", "LoanTable");
        }
    }
}
