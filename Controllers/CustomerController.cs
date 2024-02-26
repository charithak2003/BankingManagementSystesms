using BankingSystems.Data;
using BankingSystems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingSystems.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel addCustomerViewModel)
        {
            if (string.IsNullOrWhiteSpace(addCustomerViewModel.CustomerName) || string.IsNullOrWhiteSpace(addCustomerViewModel.Address) ||
                addCustomerViewModel.Phone <= 0 || addCustomerViewModel.AadhaarNo <= 0)
            {
                // If any of the required fields are not filled, return to the view with an error message.
                ModelState.AddModelError("", "All fields are required");
                return View(addCustomerViewModel);
            }

            var customer = new Customer
            {
                CustomerName = addCustomerViewModel.CustomerName,
                Address = addCustomerViewModel.Address,
                Phone = addCustomerViewModel.Phone,
                AadhaarNo = addCustomerViewModel.AadhaarNo,
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _context.Customers.ToListAsync();
            return View(customer);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var customer = await _context.Customers.FindAsync(Id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            var customers = await _context.Customers.FindAsync(customer.Id);
            if (customers != null)
            {
                customers.CustomerName = customer.CustomerName;
                customers.Address = customer.Address;
                customers.Phone = customer.Phone;
                customers.AadhaarNo = customer.AadhaarNo;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllCustomer", "Customer");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            var customers = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == customer.Id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetAllCustomer", "Customer");
        }
    }
}





