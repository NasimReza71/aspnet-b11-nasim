using DevSkill.Inventory.Application.Features.MoneyReceipts.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.MoneyReceiptsModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MoneyReceiptsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MoneyReceiptsController> _logger;

        public MoneyReceiptsController(IMediator mediator, ILogger<MoneyReceiptsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public IActionResult MoneyReceiptList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetMoneyReceiptsJsonData([FromBody] MoneyReceiptListModel model)
        {
            try
            {
                var searchDto = new MoneyReceiptSearchDto
                {
                    Invoice = model.SearchItem.Invoice,
                    Participant = model.SearchItem.Participant,
                    VoucherType = model.SearchItem.VoucherType,
                    Amount = model.SearchItem.Amount,
                    Status = model.SearchItem.Status
                };

                var query = new GetMoneyReceiptsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Invoice", "Date", "VoucherType", "Participant", "Amount", "Status"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(c => new string[]
                    {
                        HttpUtility.HtmlEncode(c.Id),
                        HttpUtility.HtmlEncode(c.Invoice),
                        c.Date.ToString("yyyy-MM-dd"),
                        HttpUtility.HtmlEncode(c.VoucherType),
                        HttpUtility.HtmlEncode(c.Participant),
                        HttpUtility.HtmlEncode(c.Particulars),
                        c.Amount.ToString("N2"),
                        HttpUtility.HtmlEncode(c.Status),
                        c.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading money receipts");
                return Json(DataTables.EmptyResult);
            }
        }

        public async Task<IActionResult> ViewMoneyReceipt(Guid id)
        {
            var moneyReceipt = await _mediator.Send(new GetMoneyReceiptByIdQuery { Id = id });
            if (moneyReceipt == null) return NotFound();
            return View(moneyReceipt);
        }
    }
}
