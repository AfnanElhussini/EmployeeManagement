namespace EmployeeManagement.Controllers
{
    public class EmpDeptController : Controller
    {
        public IEmployeeDepartmentRepository EmployeeDepartmentRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        public EmpDeptController(IEmployeeDepartmentRepository employeeDepartmentRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            EmployeeDepartmentRepository = employeeDepartmentRepository;
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }

        public ActionResult Index()
        {
            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");
            return View("Index", EmployeeDepartmentRepository.GetEmployeeDepartments());
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            int EmpId = 0;
            int DeptId = 0;

            if (!string.IsNullOrEmpty(collection["Employee"]))
            {
                EmpId = int.Parse(collection["Employee"]);
            }
            if (!string.IsNullOrEmpty(collection["Department"]))
            {
                DeptId = int.Parse(collection["Department"]);
            }

            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");

            if (EmpId != 0 && DeptId != 0)
            {
                return View(EmployeeDepartmentRepository.GetEmployeeDepartments()
                        .Where(c => c.EmployeeId == EmpId && c.DepartmentId == DeptId).ToList());
            }
            else if (EmpId != 0)
            {
                return View(EmployeeDepartmentRepository.GetEmployeeDepartments()
                        .Where(c => c.EmployeeId == EmpId).ToList());
            }
            else if (DeptId != 0)
            {
                return View(EmployeeDepartmentRepository.GetEmployeeDepartments()
                        .Where(c => c.DepartmentId == DeptId).ToList());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            return View(EmployeeDepartmentRepository.GetEmployeeDepartment(id));
        }

        public ActionResult Create()
        {
            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDepartment employeeDepartment)
        {
            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");

            var Uniq = EmployeeDepartmentRepository.GetEmployeeDepartments()
                .Any(c => c.EmployeeId == employeeDepartment.EmployeeId && c.DepartmentId == employeeDepartment.DepartmentId);
            if (Uniq)
            {
                ModelState.AddModelError("All", "This Record Exist");
            }

            if (ModelState.IsValid)
            {
                EmployeeDepartmentRepository.AddEmployeeDepartment(employeeDepartment);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");

            return View(EmployeeDepartmentRepository.GetEmployeeDepartment(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeDepartment employeeDepartment)
        {
            ViewBag.EmpList = new SelectList(EmployeeRepository.GetEmployees(), "Id", "Name");
            ViewBag.DeptList = new SelectList(DepartmentRepository.GetDepartments(), "Id", "Name");

            var Uniq = EmployeeDepartmentRepository.GetEmployeeDepartments()
                .Any(c => c.EmployeeId == employeeDepartment.EmployeeId && c.DepartmentId == employeeDepartment.DepartmentId);
            if (Uniq)
            {
                ModelState.AddModelError("All", "This Record Exist");
            }

            if (ModelState.IsValid)
            {
                EmployeeDepartmentRepository.UpdateEmployeeDepartment(id , employeeDepartment);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeeDepartmentRepository.DeleteEmployeeDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
