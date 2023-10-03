using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
