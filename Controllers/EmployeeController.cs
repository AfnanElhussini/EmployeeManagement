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

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            string Name = "";
            string PhoneNumber = "";
            var employees = EmployeeRepository.GetEmployees();
            if (!string.IsNullOrEmpty(collection["name"]))
            {
                Name = collection["name"];
            }

            if (!string.IsNullOrEmpty(collection["phoneNumber"]))
            {
                PhoneNumber = collection["phoneNumber"];
            }

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(PhoneNumber))
            {
                return View(employees.Where(e => e.Name.Contains(Name) && e.PhoneNumber.Contains(PhoneNumber)));
            }
            else if (!string.IsNullOrEmpty(Name))
            {
                return View(employees.Where(e => e.Name.Contains(Name)));
            }
            else if (!string.IsNullOrEmpty(PhoneNumber))
            {
                return View(employees.Where(e => e.PhoneNumber.Contains(PhoneNumber)));
            }
            else
            {
                return RedirectToAction("Index");
            }
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
        
        
    }
}
