using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeSkillBuilder.Data;
using EmployeeSkillBuilder.Models;

namespace EmployeeSkillBuilder.Pages.Employees
{
    public class IndexModel : PageModel
    {

        //Pang kuha ng DbContext Dependency Injection
        #region AppDbContext
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        } 
        #endregion

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee.ToListAsync();
        }
    }
}
