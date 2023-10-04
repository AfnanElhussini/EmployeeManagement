namespace EmployeeManagement.RepoServices
{
    public class EmployeeDepartmentRepositoryService : IEmployeeDepartmentRepository
    {
        public ManagementSystemDbContext DbContext { get; }
        public EmployeeDepartmentRepositoryService(ManagementSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<EmployeeDepartment> GetEmployeeDepartments()
        {
            var employeeDepartments = DbContext.EmployeeDepartments
                .Include(c => c.Department)
                .Include(c => c.Employee).ToList();
            return employeeDepartments;
        }

        public EmployeeDepartment GetEmployeeDepartment(int Id)
        {
            var employeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == Id)
                .Include(c => c.Department)
                .Include(c => c.Employee)
                .FirstOrDefault();
            if (employeeDepartment == null)
            {
                Console.WriteLine("EmployeeDepartment not found");
            }
            return employeeDepartment;
        }
        public void AddEmployeeDepartment(EmployeeDepartment employeeDepartment)
        {
            try
            {
                DbContext.EmployeeDepartments.Add(employeeDepartment);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment)
        {
            var UpdatedEmployeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == id).FirstOrDefault();
            if (UpdatedEmployeeDepartment != null)
            {
                UpdatedEmployeeDepartment.EmployeeId = employeeDepartment.EmployeeId;
                UpdatedEmployeeDepartment.DepartmentId = employeeDepartment.DepartmentId;
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("EmployeeDepartment not found");
            }
        }

        public void DeleteEmployeeDepartment(int id)
        {
            var deletedEmployeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == id).FirstOrDefault();
            if (deletedEmployeeDepartment != null)
            {
                DbContext.EmployeeDepartments.Remove(deletedEmployeeDepartment);
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("EmployeeDepartment not found");
            }
        }

    }
}
