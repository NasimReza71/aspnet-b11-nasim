using AutoMapper;
using DevSkill.Inventory.Application.Features.TransferAccounts.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Web.Areas.Admin.Models.TransferAccounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class TransferAccountsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<TransferAccountsController> _logger;

        public TransferAccountsController(IMediator mediator, IMapper mapper, ILogger<TransferAccountsController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult TransferAccountList()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetTransferAccountsJsonData([FromBody] TransferAccountListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<TransferAccountSearchDto>(model.SearchItem);

                var query = new GetTransferAccountsSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Date", "FromAccount", "ToAccount", "TransferAmount", "Note"),
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
                        q.Date.ToString("dd-MM-yyyy"),
                        HttpUtility.HtmlEncode(q.FromAccount),
                        HttpUtility.HtmlEncode(q.ToAccount),
                        q.TransferAmount.ToString("N2"),
                        HttpUtility.HtmlEncode(q.Note),
                        q.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading transfer accounts");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}
