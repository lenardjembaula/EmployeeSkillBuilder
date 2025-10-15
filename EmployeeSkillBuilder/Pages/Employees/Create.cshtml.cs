using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeSkillBuilder.Data;
using EmployeeSkillBuilder.Models;

namespace EmployeeSkillBuilder.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var EmployeeExists = _context.Employee
                .FirstOrDefault(e => e.LastName == Employee.LastName && e.FirstName == Employee.FirstName);

            if (EmployeeExists != null)
            {
                ModelState.AddModelError(string.Empty, "Employee Already Exists.");
                return Page();
            }

            //Employee.DateHired = Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd"));
            Employee.DateHired = DateTime.Now;
            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
