using AutoMapper;
using DevSkill.Inventory.Application.Features.Customers.Commands;
using DevSkill.Inventory.Application.Features.Customers.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.CustomersModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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


        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_ModalNewCustomerPartial", new CustomerAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CustomerAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CustomerAddCommand>(model);
                await _mediator.Send(command);

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Customer added successfully",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("CustomerList");
            }

            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = "Failed to add customer",
                Type = ResponseTypes.Danger
            });

            return PartialView("_ModalNewCustomerPartial", model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null) return NotFound();

            var model = _mapper.Map<CustomerUpdateViewModel>(customer);
            return PartialView("_ModalEditCustomerPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CustomerUpdateCommand>(model);
                await _mediator.Send(command);

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Customer updated successfully",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("CustomerList");
            }

            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = "Failed to update customer",
                Type = ResponseTypes.Danger
            });

            return PartialView("_ModalEditCustomerPartial", model);
        }


        public IActionResult CustomerList()
        {
            return View();
        }

        public async Task<IActionResult> ViewCustomer(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null) return NotFound();

            var viewModel = _mapper.Map<CustomerDetailViewModel>(customer);
            return View(viewModel);
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

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(c => new string[]
                    {

                        HttpUtility.HtmlEncode(c.Id),
                        HttpUtility.HtmlEncode(c.CustomerCode),
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new CustomerDeleteCommand { Id = id });
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Customer deleted",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete customer");
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete customer",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("CustomerList");
        }
    }
}
