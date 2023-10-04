using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public IDepartmentRepository DepartmentRepository { get; }

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            DepartmentRepository = departmentRepository;
        }

        public ActionResult Index()
        {
            return View("Index", DepartmentRepository.GetDepartments());
        }

        public ActionResult Details(int id)
        {
            return View("Details", DepartmentRepository.GetDepartment(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentRepository.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(DepartmentRepository.GetDepartment(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                DepartmentRepository.UpdateDepartment(id, department);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            DepartmentRepository.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
