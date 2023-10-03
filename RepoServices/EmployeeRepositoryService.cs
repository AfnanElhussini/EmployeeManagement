using EmployeeManagement.Repositories;

namespace EmployeeManagement.RepoServices
{
    public class EmployeeRepositoryService : IEmployeeRepository
    {
        public ManagementSystemDbContext DbContext { get; }

        public EmployeeRepositoryService(ManagementSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employeeList = DbContext.Employees.ToList();
            return employeeList;
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            var employee = DbContext.Employees.Where(e => e.Id == Id).FirstOrDefault();
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
