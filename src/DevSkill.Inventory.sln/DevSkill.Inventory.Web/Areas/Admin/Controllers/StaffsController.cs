using AutoMapper;
using DevSkill.Inventory.Application.Features.Staffs.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.StaffModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StaffsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffsController> _logger;

        public StaffsController(IMediator mediator, IMapper mapper, ILogger<StaffsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult StaffList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetStaffsJsonData([FromBody] StaffListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<StaffSearchDto>(model.SearchItem);

                var query = new GetStaffsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("StaffNumber", "Name", "Mobile", "Email", "Address", "JoiningDate", "Salary", "Status"),
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
                        HttpUtility.HtmlEncode(q.StaffNumber),
                        HttpUtility.HtmlEncode(q.Name),
                        HttpUtility.HtmlEncode(q.Mobile),
                        HttpUtility.HtmlEncode(q.Email),
                        HttpUtility.HtmlEncode(q.Address),
                        q.JoiningDate.ToString("dd-MM-yyyy"),
                        q.Salary.ToString("N2"),
                        HttpUtility.HtmlEncode(q.Status),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading staff");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
