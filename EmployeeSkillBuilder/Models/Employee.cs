using System.ComponentModel.DataAnnotations;

namespace EmployeeSkillBuilder.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name ="First Name:")]
        public string? FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string? LastName { get; set; }
        [Display(Name = "Date Hired:")]
        public DateTime DateHired { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
    }
}
