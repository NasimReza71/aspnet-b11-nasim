using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Web.Areas.Admin.Models.UserDashboardViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserDashboardController : Controller
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public UserDashboardController(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult UserDashboard()
        {
            var model = new UserDashboardViewModel
            {
                CustomerCount = _unitOfWork.GetCustomerCount(),
                SupplierCount = _unitOfWork.GetSupplierCount(),
                StaffCount = _unitOfWork.GetStaffCount(),
                UserCount = _unitOfWork.GetUserCount()
            };
            return View(model);
        }
    }
}
