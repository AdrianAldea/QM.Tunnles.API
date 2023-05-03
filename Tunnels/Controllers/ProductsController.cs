using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Services;
using Tunnels.DTOs.Product;

namespace Tunnels.Controllers {
    /// <summary>
    /// Users Controller
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper) {
            _productService = productService;
            _mapper = mapper;
        }

        #region Get

        [HttpGet("")]
        public async Task<ActionResult<GetProductResponse>> GetAllProducts([FromQuery] bool? isActive) {
            var products = await _productService.GetAllProducts(isActive);

            List<GetProductResponse> result = new List<GetProductResponse>();
            foreach (var product in products) {
                var getProductsResponse = _mapper.Map<Product, GetProductResponse>(product);
                result.Add(getProductsResponse);
            }
            return Ok(result);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById([FromRoute] int id) {
            await _productService.DeleteById(id);
            return Ok();
        }

        #endregion
    }
}
