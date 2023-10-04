namespace EmployeeManagement.Repositories
{
    public interface IEmployeeDepartmentRepository
    {
        public List<EmployeeDepartment> GetEmployeeDepartments();
        public EmployeeDepartment GetEmployeeDepartment(int Id);
        public void AddEmployeeDepartment(EmployeeDepartment employeeDepartment);
        public void UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment);
        public void DeleteEmployeeDepartment(int id);
    }
}
