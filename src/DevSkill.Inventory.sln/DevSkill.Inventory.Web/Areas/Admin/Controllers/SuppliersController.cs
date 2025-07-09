using AutoMapper;
using DevSkill.Inventory.Application.Features.Suppliers.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.SupplierModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SuppliersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<SuppliersController> _logger;

        public SuppliersController(IMediator mediator, IMapper mapper, ILogger<SuppliersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult SupplierList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetSuppliersJsonData([FromBody] SupplierListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<SupplierSearchDto>(model.SearchItem);

                var query = new GetSuppliersSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("SupplierNumber", "Name", "Company", "Mobile", "Address", "Status"),
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
                        HttpUtility.HtmlEncode(q.SupplierNumber),
                        HttpUtility.HtmlEncode(q.Name),
                        HttpUtility.HtmlEncode(q.Company),
                        HttpUtility.HtmlEncode(q.Mobile),
                        HttpUtility.HtmlEncode(q.Address),
                        HttpUtility.HtmlEncode(q.Status),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading suppliers");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
