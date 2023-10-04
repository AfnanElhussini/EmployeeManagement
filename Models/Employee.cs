namespace EmployeeManagement.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Employee name cannot exceed 50 characters")]
        public string Name { get; set; }

        public ICollection<EmployeeDepartment>? EmployeeDepartments { get; set; }
    }
}
