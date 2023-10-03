namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetDepartments();
        public Task<Department> GetDepartment(int Id);
        public void AddDepartment(Department department);
        public void UpdateDepartment(int id, Department department);
        public void DeleteDepartment(int id);
    }
}
