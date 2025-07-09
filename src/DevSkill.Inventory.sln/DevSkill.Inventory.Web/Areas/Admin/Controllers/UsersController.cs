using AutoMapper;
using DevSkill.Inventory.Application.Features.Users.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, IMapper mapper, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult UserList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetUsersJsonData([FromBody] UserListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<UserSearchDto>(model.SearchItem);

                var query = new GetUsersSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Employee", "Company", "Email", "Mobile", "Role", "Status"),
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
                        HttpUtility.HtmlEncode(q.Employee),
                        HttpUtility.HtmlEncode(q.Company),
                        HttpUtility.HtmlEncode(q.Email),
                        HttpUtility.HtmlEncode(q.Mobile),
                        HttpUtility.HtmlEncode(q.Role),
                        HttpUtility.HtmlEncode(q.Status),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading users");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
