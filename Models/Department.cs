namespace EmployeeManagement.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Department name cannot exceed 50 characters")]
        public string Name { get; set; }
        public ICollection<EmployeeDepartment>? EmployeeDepartments { get; set; }
    }

}
