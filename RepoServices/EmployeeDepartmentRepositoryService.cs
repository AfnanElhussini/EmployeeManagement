namespace EmployeeManagement.RepoServices
{
    public class EmployeeDepartmentRepositoryService
    {
        public ManagementSystemDbContext DbContext { get; }
        public EmployeeDepartmentRepositoryService(ManagementSystemDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<List<EmployeeDepartment>> GetEmployeeDepartments()
        {
            var employeeDepartments = await DbContext.EmployeeDepartments.ToListAsync();
            return employeeDepartments;
        }

        public async Task<EmployeeDepartment> GetEmployeeDepartment(int Id)
        {
            var employeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == Id).FirstOrDefault();
            if (employeeDepartment == null)
            {
                Console.WriteLine("EmployeeDepartment not found");
            }
            return employeeDepartment;
        }
        public async Task<EmployeeDepartment> AddEmployeeDepartment(EmployeeDepartment employeeDepartment)
        {
            try
            {
                DbContext.EmployeeDepartments.Add(employeeDepartment);
                await DbContext.SaveChangesAsync();
                return employeeDepartment;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<EmployeeDepartment> UpdateEmployeeDepartment(int id, EmployeeDepartment employeeDepartment)
        {
            var UpdatedEmployeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == id).FirstOrDefault();
            if (UpdatedEmployeeDepartment != null)
            {
                UpdatedEmployeeDepartment.EmployeeId = employeeDepartment.EmployeeId;
                UpdatedEmployeeDepartment.DepartmentId = employeeDepartment.DepartmentId;
                await DbContext.SaveChangesAsync();
                return UpdatedEmployeeDepartment;
            }
            else
            {
                Console.WriteLine("EmployeeDepartment not found");
                return null;
            }
        }

        public async Task<EmployeeDepartment> DeleteEmployeeDepartment(int id)
        {
            var deletedEmployeeDepartment = DbContext.EmployeeDepartments.Where(ed => ed.Id == id).FirstOrDefault();
            if (deletedEmployeeDepartment != null)
            {
                DbContext.EmployeeDepartments.Remove(deletedEmployeeDepartment);
                await DbContext.SaveChangesAsync();
                return deletedEmployeeDepartment;
            }
            else
            {
                Console.WriteLine("EmployeeDepartment not found");
                return null;
            }
        }

    }
}
