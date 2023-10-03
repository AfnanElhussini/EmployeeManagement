namespace EmployeeManagement.Repositories
{
    public interface IEmployeeDepartmentRepository
    {
        public Task<List<EmployeeDepartment>> GetEmployeeDepartments();
        public Task<EmployeeDepartment> GetEmployeeDepartment(int Id);
        public Task<EmployeeDepartment> AddEmployeeDepartment(EmployeeDepartment employeeDepartment);
        public Task<EmployeeDepartment> UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment);
        public Task<EmployeeDepartment> DeleteEmployeeDepartment(int id);
    }
}
