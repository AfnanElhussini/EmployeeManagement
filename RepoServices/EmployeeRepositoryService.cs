namespace EmployeeManagement.RepoServices
{
    public class EmployeeRepositoryService : IEmployeeRepository
    {
        public ManagementSystemDbContext DbContext { get; }

        public EmployeeRepositoryService(ManagementSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        {
            var employeeList = DbContext.Employees
                .Include(c => c.EmployeeDepartments)
                .ThenInclude(c => c.Department).ToList();
            return employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            var employee = DbContext.Employees.Where(e => e.Id == Id)
                .Include(c => c.EmployeeDepartments)
                .ThenInclude(c => c.Department).FirstOrDefault();
            if (employee == null)
            {
                Console.WriteLine("Employee not found");
            }
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                DbContext.Employees.Add(employee);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            var UpdatedEmployee = DbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
            if (UpdatedEmployee != null)
            {
                UpdatedEmployee.Name = employee.Name;
                UpdatedEmployee.PhoneNumber = employee.PhoneNumber;
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            var deletedEmployee = DbContext.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            if (deletedEmployee != null)
            {
                DbContext.Employees.Remove(deletedEmployee);
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
    }
}
