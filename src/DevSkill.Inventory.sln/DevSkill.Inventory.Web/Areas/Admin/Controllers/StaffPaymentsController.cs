using AutoMapper;
using DevSkill.Inventory.Application.Features.StaffPayments.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.StaffPaymentModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StaffPaymentsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffPaymentsController> _logger;

        public StaffPaymentsController(IMediator mediator, IMapper mapper, ILogger<StaffPaymentsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult StaffPaymentList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetStaffPaymentsJsonData([FromBody] StaffPaymentListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<StaffPaymentSearchDto>(model.SearchItem);

                var query = new GetStaffPaymentsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Name", "Date", "Salary", "Attendance", "Advance", "Payment", "Note"),
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
                        HttpUtility.HtmlEncode(q.Name),
                        q.Date,
                        q.Salary.ToString("N2"),
                        q.Attendance.ToString(),
                        q.Advance.ToString("N2"),
                        q.Payment.ToString("N2"),
                        HttpUtility.HtmlEncode(q.Note),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading staff payments");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
