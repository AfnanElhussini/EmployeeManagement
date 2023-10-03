using EmployeeManagement.Models;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.RepoServices
{
    public class DepartmentRepositoryService : IDepartmentRepository

    {
        public ManagementSystemDbContext DbContext { get; }

        public DepartmentRepositoryService( ManagementSystemDbContext dbContext)
        {
            
            DbContext = dbContext;
        }
        public async Task<List<Department>> GetDepartments()
        {
           var departments = await DbContext.Departments.ToListAsync();
            return departments;
        }

        public async Task<Department> GetDepartment(int Id)
        {
            var department = DbContext.Departments.Where(d=>d.Id == Id).FirstOrDefault();
            if(department == null)
            {
                Console.WriteLine("Department not found");
            }
            return department;
        }

        public void AddDepartment(Department department)
        {
            try
            {
                DbContext.Departments.Add(department);
                DbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void UpdateDepartment(int id, Department department)
        {
            var UpdatedDepartment = DbContext.Departments.Where(d=> d.Id == id ).FirstOrDefault();
            if(UpdatedDepartment != null)
            {
                UpdatedDepartment.Name = department.Name;
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Department not found");
            }

        }

        public void DeleteDepartment(int id)
        {
            var deletedDepartment = DbContext.Departments.Where(d => d.Id == id).FirstOrDefault();
            if(deletedDepartment != null)
            {
                DbContext.Departments.Remove(deletedDepartment);
                DbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Department not found");
            }
       
        }
    }
}
