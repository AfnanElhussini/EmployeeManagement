namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(int Id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(int id, Employee employee);
        public void DeleteEmployee(int employeeId);

    }
}
