namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository
    {
        public List<Department> GetDepartments();
        public Department GetDepartment(int Id);
        public void AddDepartment(Department department);
        public void UpdateDepartment(int id, Department department);
        public void DeleteDepartment(int id);
    }
}
