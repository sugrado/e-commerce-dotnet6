using ECommerceBackend.Application.CorePackages.Utilities.Results;
using ECommerceBackend.Application.Repositories.Customers;
using ECommerceBackend.Application.Repositories.Orders;
using ECommerceBackend.Application.Repositories.Products;
using ECommerceBackend.Application.RequestParameters;
using ECommerceBackend.Application.ViewModels.Products;
using ECommerceBackend.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = await _productReadRepository.GetAll(false).CountAsync();
            var products = _productReadRepository.GetAll(false)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedAt,
                    p.ModifiedAt
                })
                .Skip(pagination.Page * pagination.Size)
                .Take(pagination.Size);
            return Ok(new
            {
                products,
                totalCount
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {

            }
            var x = await _productWriteRepository.AddAsync(new() { Name = model.Name, Price = model.Price, Stock = model.Stock });
            await _productWriteRepository.SaveAsync();
            Thread.Sleep(5000);
            return Ok(new SuccessDataResult<Product>(x));
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            var product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Price = model.Price;
            product.Stock = model.Stock;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
