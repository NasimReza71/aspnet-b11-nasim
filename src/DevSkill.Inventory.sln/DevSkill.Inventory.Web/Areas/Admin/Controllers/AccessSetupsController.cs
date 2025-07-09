using AutoMapper;
using DevSkill.Inventory.Application.Features.AccessSetups;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.AccessSetupModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccessSetupsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AccessSetupsController> _logger;

        public AccessSetupsController(IMediator mediator, IMapper mapper, ILogger<AccessSetupsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        
        public IActionResult AccessSetupList()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<JsonResult> GetAccessSetupsJsonData([FromBody] AccessSetupListModel model)
        {
            try
            {
               
                var searchDto = _mapper.Map<AccessSetupSearchDto>(model.SearchItem);

                
                var query = new GetAccessSetupsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("CompID", "UserType", "Status", "CreatedDate"),
                    SearchItem = searchDto
                };

                
                var (data, total, totalDisplay) = await _mediator.Send(query);

                
                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(q => new string[]
                    {
                        HttpUtility.HtmlEncode(q.Id.ToString()),
                        HttpUtility.HtmlEncode(q.CompID),
                        HttpUtility.HtmlEncode(q.UserType),
                        HttpUtility.HtmlEncode(q.Status),
                        q.CreatedDate.ToString("yyyy-MM-dd"),
                        HttpUtility.HtmlEncode(q.Id.ToString()) 
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Error loading access setups");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
