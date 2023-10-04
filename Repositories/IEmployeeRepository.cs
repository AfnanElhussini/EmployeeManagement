namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int Id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(int id, Employee employee);
        public void DeleteEmployee(int employeeId);
       

       

    }
}
