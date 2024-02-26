using BankingSystems.Data;
using BankingSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystems.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAccountViewModel addAccountViewModel)
        {
            if (string.IsNullOrWhiteSpace(addAccountViewModel.Name) || string.IsNullOrWhiteSpace(addAccountViewModel.IFSCCode) ||
                addAccountViewModel.AccountNo <= 0 || addAccountViewModel.Balance <= 0.0 || addAccountViewModel.NoOfTransactions <= 0)
            {
                // If any of the required fields are not filled, return to the view with an error message.
                ModelState.AddModelError("", "All fields are required");
                return View(addAccountViewModel);
            }

            var account = new Account
            {
                Name = addAccountViewModel.Name,
                IFSCCode = addAccountViewModel.IFSCCode,
                AccountNo = addAccountViewModel.AccountNo,
                Balance = addAccountViewModel.Balance,
                NoOfTransactions = addAccountViewModel.NoOfTransactions,
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var account = await _context.Accounts.ToListAsync();
            return View(account);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var account = await _context.Accounts.FindAsync(Id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {
            var accounts = await _context.Accounts.FindAsync(account.Id);
            if (accounts != null)
            {
                accounts.Name = account.Name;
                accounts.IFSCCode = account.IFSCCode;
                accounts.AccountNo = account.AccountNo;
                accounts.Balance = account.Balance;
                accounts.NoOfTransactions = account.NoOfTransactions;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllAccounts", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Account account)
        {
            var accounts = _context.Accounts.AsNoTracking().FirstOrDefault(x => x.Id == account.Id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllAccounts", "Account");
        }



    }
}
