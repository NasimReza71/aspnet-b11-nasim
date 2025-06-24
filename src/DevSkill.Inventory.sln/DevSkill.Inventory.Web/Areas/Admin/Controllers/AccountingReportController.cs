using DevSkill.Inventory.Web.Areas.Admin.Models.AccountingReportModels;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountingReportController : Controller
    {
        public IActionResult Index()
        {
          
            var cards = new List<AccountingReportCardViewModel>
            {
                new AccountingReportCardViewModel { Title="Sales Report", Value="2,508,351.00", Icon="bi-pie-chart-fill", BgColorClass="bg-violet" },
                new AccountingReportCardViewModel { Title="Purchase Report", Value="0.00", Icon="bi-file-earmark-text", BgColorClass="bg-green" },
                new AccountingReportCardViewModel { Title="Profit / Loss Report", Value="-417,946.00", Icon="bi-graph-up-arrow", BgColorClass="bg-blue" },
                new AccountingReportCardViewModel { Title="Profit Report (Product Wise)", Value="", Icon="bi-graph-up", BgColorClass="bg-pink" },
              
            };
            return View(cards);
        }
    }
}
