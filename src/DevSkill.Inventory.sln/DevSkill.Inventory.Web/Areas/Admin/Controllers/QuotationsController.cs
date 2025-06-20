using AutoMapper;
using DevSkill.Inventory.Application.Features.Quotations.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.QuotationsModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuotationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuotationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult QuotationList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetQuotationsJsonData([FromBody] QuotationListModel model)
        {
            var searchDto = _mapper.Map<QuotationSearchDto>(model.SearchItem);
            var query = new GetQuotationsSPQuery
            {
                PageIndex = model.PageIndex,
                PageSize = model.PageSize,
                SortExpression = model.FormatSortExpression("QuotationNumber", "QuotationDate", "CustomerName", "Quantity", "TotalPrice"),
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
                    HttpUtility.HtmlEncode(q.QuotationNumber),
                    q.QuotationDate.ToString("dd-MM-yyyy"),
                    HttpUtility.HtmlEncode(q.CustomerName),
                    q.Quantity.ToString(),
                    q.TotalPrice.ToString("N2"),
                    q.Id.ToString()
                }).ToArray()
            };

            return Json(result);
        }
    }
}
