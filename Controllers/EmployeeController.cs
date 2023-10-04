using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public IEmployeeDepartmentRepository EmployeeDepartmentRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IEmployeeDepartmentRepository employeeDepartmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
            EmployeeDepartmentRepository = employeeDepartmentRepository;
        }

        public ActionResult Index()
        {
            return View("Index", EmployeeRepository.GetEmployees());
        }

        public ActionResult Details(int id)
        {
            ViewBag.AllDepts = EmployeeDepartmentRepository.GetEmployeeDepartments()
                .Where(e => e.EmployeeId == id).Select(c => c.Department.Name).ToList();
            return View("Details", EmployeeRepository.GetEmployee(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var PhoneNumber = EmployeeRepository.GetEmployees().Any(c => c.PhoneNumber == employee.PhoneNumber);
            if (PhoneNumber)
            {
                ModelState.AddModelError("PhoneNumber", "Already Exist Phone Number");
            }
            var Name = EmployeeRepository.GetEmployees().Any(c => c.Name == employee.Name);
            if (Name)
            {
                ModelState.AddModelError("Name", "Already Exist Name");
            }

            if (ModelState.IsValid)
            {
                EmployeeRepository.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(EmployeeRepository.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            var PhoneNumber = EmployeeRepository.GetEmployees().Any(c => c.PhoneNumber == employee.PhoneNumber);
            if (PhoneNumber)
            {
                ModelState.AddModelError("PhoneNumber", "Already Exist Phone Number");
            }
            var Name = EmployeeRepository.GetEmployees().Any(c => c.Name == employee.Name);
            if (Name)
            {
                ModelState.AddModelError("Name", "Already Exist Name");
            }

            if (ModelState.IsValid)
            {
                EmployeeRepository.UpdateEmployee(id, employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult SearchByName(string name)
        {
            var employees = EmployeeRepository.GetEmployees();
            if (!string.IsNullOrEmpty(name))
            {
                employees = (List<Employee>)employees.Where(e => e.Name.Contains(name));
            }
            return View("Index", employees);
        }
        public IActionResult SearchByPhoneNumber(string phoneNumber)
        {
            var employees = EmployeeRepository.GetEmployees();
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                employees = (List<Employee>)employees.Where(e => e.PhoneNumber.Contains(phoneNumber));
            }
            return View("Index", employees);
        }
    }
}
