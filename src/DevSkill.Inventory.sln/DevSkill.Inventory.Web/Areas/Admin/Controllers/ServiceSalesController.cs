using AutoMapper;
using DevSkill.Inventory.Application.Features.ServiceSales.Commands;
using DevSkill.Inventory.Application.Features.ServiceSales.Queries;
using DevSkill.Inventory.Domain;
using DevSkill.Inventory.Domain.Dtos;
using DevSkill.Inventory.Domain.Entities;
using DevSkill.Inventory.Infrastructure;
using DevSkill.Inventory.Web.Areas.Admin.Models;
using DevSkill.Inventory.Web.Areas.Admin.Models.ServiceSalesModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DevSkill.Inventory.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceSalesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceSalesController> _logger;

        public ServiceSalesController(IMediator mediator, IMapper mapper, ILogger<ServiceSalesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_ModalNewServiceSalePartial", new ServiceSaleAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ServiceSaleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<AddServiceSaleCommand>(model);
                await _mediator.Send(command);

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Service Sale added successfully",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("ServiceSaleList");
            }

            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = "Failed to add Service Sale",
                Type = ResponseTypes.Danger
            });

            return PartialView("_ModalNewServiceSalePartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _mediator.Send(new GetServiceSaleByIdQuery { Id = id });
            if (dto == null) return NotFound();

            var model = _mapper.Map<ServiceSaleUpdateViewModel>(dto);
            return PartialView("_ModalEditServiceSalePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceSaleUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateServiceSaleCommand>(model);
                await _mediator.Send(command);

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Service Sale updated successfully",
                    Type = ResponseTypes.Success
                });

                return RedirectToAction("ServiceSaleList");
            }

            TempData.Put("ResponseMessage", new ResponseModel
            {
                Message = "Failed to update Service Sale",
                Type = ResponseTypes.Danger
            });

            return PartialView("_ModalEditServiceSalePartial", model);
        }

        public IActionResult ServiceSaleList()
        {
            return View();
        }

        public async Task<IActionResult> ViewServiceSale(Guid id)
        {
            var dto = await _mediator.Send(new GetServiceSaleByIdQuery { Id = id });
            if (dto == null) return NotFound();

            var viewModel = _mapper.Map<ServiceSaleDetailViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> GetServiceSalesJsonData([FromBody] ServiceSaleListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<ServiceSaleSearchDto>(model.SearchItem);

                var query = new GetServiceSalesSPQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    SortExpression = model.FormatSortExpression("InvoiceNo", "CustomerName", "ServiceName", "Total", "Paid", "Due"),
                    SearchItem = searchDto
                };

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(s => new string[]
                    {
                        HttpUtility.HtmlEncode(s.Id),
                        HttpUtility.HtmlEncode(s.InvoiceNo),
                        s.Date.ToString("yyyy-MM-dd"),
                        HttpUtility.HtmlEncode(s.CustomerName),
                        HttpUtility.HtmlEncode(s.ServiceName),
                        s.Total.ToString("N2"),
                        s.Paid.ToString("N2"),
                        s.Due.ToString("N2"),
                        s.Id.ToString()
                    }).ToArray()
                };

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading service sales");
                return Json(DataTables.EmptyResult);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteServiceSaleCommand { Id = id });
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Service Sale deleted",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete service sale");
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete service sale",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("ServiceSaleList");
        }
    }
}
