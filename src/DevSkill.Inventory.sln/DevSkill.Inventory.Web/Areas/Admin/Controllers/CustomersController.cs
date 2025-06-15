using AutoMapper;
using DevSkill.Inventory.Application.Features.Customers.Queries;
using DevSkill.Inventory.Application.Features.Products.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Web.Areas.Admin.Models.Customers_Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IMediator mediator, IMapper mapper, ILogger<CustomersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerList()
        {
            return View();
        }



        [HttpPost]
        public async Task<JsonResult> GetCustomersJsonData([FromBody] CustomerListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<CustomerSearchDto>(model.SearchItem);

                var query = new GetCustomersSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("Name", "Mobile", "Address", "Email", "CurrentBalance"),
                    SearchItem = searchDto
                };

                (IList<Customer> data, int total, int totalDisplay) = await _mediator.Send(query); 


                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(c => new string[]
                    {
                    c.CustomerCode,
                    HttpUtility.HtmlEncode(c.Name),
                    HttpUtility.HtmlEncode(c.Mobile),
                    HttpUtility.HtmlEncode(c.Address),
                    HttpUtility.HtmlEncode(c.Email),
                    c.CurrentBalance.ToString("N2"),
                    c.IsActive ? "Active" : "Inactive",
                    c.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading customers");
                return Json(DataTables.EmptyResult);
            }
        }
    }

}
