using AutoMapper;
using DevSkill.Inventory.Application.Features.DebitVouchers.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Web.Areas.Admin.Models.DebitVouchersModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DebitVouchersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<DebitVouchersController> _logger;

        public DebitVouchersController(IMediator mediator, IMapper mapper, ILogger<DebitVouchersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult DebitVoucherList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetDebitVouchersJsonData([FromBody] DebitVoucherListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<DebitVoucherSearchDto>(model.SearchItem);

                var query = new GetDebitVouchersSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("InvoiceNumber", "VoucherDate", "VoucherType", "CostType", "Particulars", "Amount", "Status"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(d => new string[]
                    {
                        HttpUtility.HtmlEncode(d.Id),
                        HttpUtility.HtmlEncode(d.InvoiceNumber),
                        d.VoucherDate.ToString("dd-MM-yyyy"),
                        HttpUtility.HtmlEncode(d.VoucherType),
                        HttpUtility.HtmlEncode(d.CostType),
                        HttpUtility.HtmlEncode(d.Particulars),
                        d.Amount.ToString("N2"),
                        HttpUtility.HtmlEncode(d.Status),
                        d.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading debit vouchers");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
