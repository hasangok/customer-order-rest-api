using AktifTech.CustomerOrderRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AktifTech.CustomerOrderRestApi.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<ApiResult<IEnumerable<GetProductOutput>>> Get()
    {
        return Success("Products retrieved successfully.", _productService.Get());
    }

    [HttpGet("{id}")]
    public ActionResult<ApiResult<GetProductOutput>> Get(long id)
    {
        return Success($"Product #{id} retrieved successfully.", _productService.Get(id));
    }

    [HttpPost]
    public ActionResult<ApiResult<GetProductOutput>> Create(CreateProductInput input)
    {
        return Success("Product created successfully.", _productService.Create(input));
    }

    [HttpPut("{id}")]
    public ActionResult<ApiResult<GetProductOutput>> Update(long id, UpdateProductInput input)
    {
        return Success("Product updated successfully.", _productService.Update(id, input));
    }

    [HttpDelete("{id}")]
    public ActionResult<ApiResult<GetProductOutput>> Delete(long id)
    {
        return Success("Product deleted successfully.", _productService.Remove(id));
    }

    protected ActionResult Success(string message, object data = null)
    {
        return Ok(new ApiResult()
        {
            Success = true,
            Message = message,
            Data = data,
            Code = data == null ? 204 : 200
        });
    }
}
