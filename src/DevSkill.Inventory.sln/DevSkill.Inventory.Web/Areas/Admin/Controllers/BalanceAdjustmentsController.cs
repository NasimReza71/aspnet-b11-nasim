using AutoMapper;
using DevSkill.Inventory.Application.Features.BalanceAdjustments.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.BalanceAdjustmentModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class BalanceAdjustmentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BalanceAdjustmentsController> _logger;

        public BalanceAdjustmentsController(IMediator mediator, IMapper mapper, ILogger<BalanceAdjustmentsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult BalanceAdjustmentList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetBalanceAdjustmentsJsonData([FromBody] BalanceAdjustmentListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<BalanceAdjustmentSearchDto>(model.SearchItem);

                var query = new GetBalanceAdjustmentsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Date", "AdjustmentType", "Amount", "Note", "AccountType"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(q => new string[]
                    {
                        HttpUtility.HtmlEncode(q.Id),
                        q.Date.ToString("yyyy-MM-dd"),
                        HttpUtility.HtmlEncode(q.AdjustmentType),
                        q.Amount.ToString("N2"),
                        HttpUtility.HtmlEncode(q.Note),
                        HttpUtility.HtmlEncode(q.AccountType),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading balance adjustments");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
