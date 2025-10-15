using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeSkillBuilder.Data;
using EmployeeSkillBuilder.Models;

namespace EmployeeSkillBuilder.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeSkillBuilder.Data.AppDbContext _context;

        public DetailsModel(EmployeeSkillBuilder.Data.AppDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (employee is not null)
            {
                Employee = employee;

                return Page();
            }

            return NotFound();
        }
    }
}
