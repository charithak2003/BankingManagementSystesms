using BankingSystems.Data;
using BankingSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BankingSystems.Controllers
{
    public class BranchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBranchViewModel addBranchViewModel)
        {
            if (string.IsNullOrWhiteSpace(addBranchViewModel.Name) ||
                string.IsNullOrWhiteSpace(addBranchViewModel.Description) ||
                string.IsNullOrWhiteSpace(addBranchViewModel.City) ||
                addBranchViewModel.NoOfEmps <= 0)
            {
                // If any of the required fields are not filled, return to the view with an error message.
                ModelState.AddModelError("", "All fields are required");
                return View(addBranchViewModel);
            }

            var branch = new Branch
            {
                Name = addBranchViewModel.Name,
                Description = addBranchViewModel.Description,
                City = addBranchViewModel.City,
                NoOfEmps = addBranchViewModel.NoOfEmps,
            };

            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branch = await _context.Branches.ToListAsync();
            return View(branch);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var branch = await _context.Branches.FindAsync(Id);
            return View(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Branch branch)
        {
            var branches = await _context.Branches.FindAsync(branch.Id);
            if (branches != null)
            {
                branches.Name = branch.Name;
                branches.Description = branch.Description;
                branches.City = branch.City;
                branches.NoOfEmps = branch.NoOfEmps;
                
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllBranches", "Branch");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Branch branch)
        {
            var branches = _context.Branches.AsNoTracking().FirstOrDefault(x=>x.Id == branch.Id);
            if (branch != null)
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllBranches", "Branch");
        }
    }
}
