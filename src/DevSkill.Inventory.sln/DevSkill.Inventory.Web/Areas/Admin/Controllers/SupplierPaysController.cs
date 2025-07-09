using AutoMapper;
using DevSkill.Inventory.Application.Features.SupplierPays.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.SupplierPaysModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SupplierPaysController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierPaysController> _logger;

        public SupplierPaysController(IMediator mediator, IMapper mapper, ILogger<SupplierPaysController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult SupplierPayList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetSupplierPaysJsonData([FromBody] SupplierPayListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<SupplierPaySearchDto>(model.SearchItem);

                var query = new GetSupplierPaysSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Invoice", "Date", "VoucherType", "Employee", "Particulars", "Amount", "Status"),
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
                        HttpUtility.HtmlEncode(q.Invoice),
                        q.Date.ToString("dd-MM-yyyy"),
                        HttpUtility.HtmlEncode(q.VoucherType),
                        HttpUtility.HtmlEncode(q.Employee),
                        HttpUtility.HtmlEncode(q.Particulars),
                        q.Amount.ToString("N2"),
                        HttpUtility.HtmlEncode(q.Status),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error loading supplier pays");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
