using AutoMapper;
using DevSkill.Inventory.Application.Features.ServiceFeatures.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServicesModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServicesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(IMediator mediator, IMapper mapper, ILogger<ServicesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult ServiceList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetServicesJsonData([FromBody] ServiceListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<ServiceSearchDto>(model.SearchItem);

                var query = new GetServicesSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Code", "ServiceName", "Price", "Details"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(s => new string[]
                    {
                        HttpUtility.HtmlEncode(s.Code),
                        HttpUtility.HtmlEncode(s.ServiceName),
                        s.Price.ToString("N2"),
                        HttpUtility.HtmlEncode(s.Details),
                        HttpUtility.HtmlEncode(s.Status),
                        s.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading service data");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
