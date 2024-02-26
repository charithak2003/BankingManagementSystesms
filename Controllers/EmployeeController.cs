using BankingSystems.Data;
using BankingSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystems.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            if (string.IsNullOrWhiteSpace(addEmployeeViewModel.Address) ||
                string.IsNullOrWhiteSpace(addEmployeeViewModel.Gender) ||
                addEmployeeViewModel.Ssn <= 0 || addEmployeeViewModel.Salary <= 0.0)
            {
                // If any of the required fields are not filled, return to the view with an error message.
                ModelState.AddModelError("", "All fields are required");
                return View(addEmployeeViewModel);
            }

            var employee = new Employee
            {
                Address = addEmployeeViewModel.Address,
                Gender = addEmployeeViewModel.Gender,
                Ssn = addEmployeeViewModel.Ssn,
                Salary = addEmployeeViewModel.Salary,
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employee = await _context.Employees.ToListAsync();
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var employees = await _context.Employees.FindAsync(employee.Id);
            if (employees != null)
            {
                employees.Address = employee.Address;
                employees.Gender = employee.Gender;
                employees.Ssn = employee.Ssn;
                employees.Salary = employee.Salary;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllEmployees", "Employee");
        }
     
        [HttpPost]

        public async Task<IActionResult> Delete(Employee  employee)
        {
            var employees = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == employee.Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllEmployees", "Employee");
        }
    }
}
