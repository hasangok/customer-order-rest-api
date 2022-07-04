using AktifTech.CustomerOrderRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AktifTech.CustomerOrderRestApi.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly CustomerOrderService _customerOrderService;

    public CustomersController(CustomerService customerService, CustomerOrderService customerOrderService)
    {
        _customerService = customerService;
        _customerOrderService = customerOrderService;
    }

    // customer CRUD methods

    [HttpGet]
    public ActionResult<ApiResult<IEnumerable<GetCustomerOutput>>> Get()
    {
        return Success("Customers retrieved successfully.", _customerService.Get());
    }

    [HttpGet("{id}")]
    public ActionResult<ApiResult<GetCustomerOutput>> Get(long id)
    {
        return Success($"Customer #{id} retrieved successfully.", _customerService.Get(id));
    }

    [HttpPost]
    public ActionResult<ApiResult<GetCustomerOutput>> Create(CreateCustomerInput input)
    {
        return Success("Customer created successfully.", _customerService.Create(input));
    }

    [HttpPut("{id}")]
    public ActionResult<ApiResult<GetCustomerOutput>> Update(long id, UpdateCustomerInput input)
    {
        return Success("Customer updated successfully.", _customerService.Update(id, input));
    }

    [HttpDelete("{id}")]
    public ActionResult<ApiResult<GetCustomerOutput>> Delete(long id)
    {
        return Success("Customer deleted successfully.", _customerService.Remove(id));
    }

    // customer addresses methods

    [HttpPost("{id}/Addresses")]
    public ActionResult<ApiResult<GetCustomerOutput>> CreateAddress(long id, CreateCustomerAddressInput input)
    {
        return Success("Customer created successfully.", _customerService.CreateCustomerAddress(id, input));
    }
    [HttpDelete("{id}/Addresses")]
    public ActionResult<ApiResult<GetCustomerOutput>> CreateAddress(long id, DeleteCustomerAddressInput input)
    {
        return Success("Customer created successfully.", _customerService.DeleteCustomerAddress(id, input));
    }

    // customer order methods
    [HttpPost("{id}/Orders")]
    public ActionResult<ApiResult<GetCustomerOrderOutput>> SaveOrder(long id, CreateCustomerOrderInput input)
    {
        return Success("Order created successfully.", _customerOrderService.SaveOrder(id, input));
    }

    [HttpDelete("{id}/Orders/{orderId}")]
    public ActionResult<ApiResult<GetCustomerOutput>> DeleteOrder(long id, long orderId)
    {
        return Success("Order deleted successfully.", _customerOrderService.DeleteOrderById(id, orderId));
    }

    [HttpPut("{id}/Orders/{orderId}/Products")]
    public ActionResult<ApiResult<GetCustomerOutput>> UpdateOrder(long id, long orderId, AddOrUpdateProductInput input)
    {
        return Success("Updated products in order successfully.", _customerOrderService.AddOrUpdateProduct(id, orderId, input));
    }

    [HttpDelete("{id}/Orders/{orderId}/Products/{productId}")]
    public ActionResult<ApiResult<GetCustomerOutput>> RemoveProduct(long id, long orderId, long productId)
    {
        return Success("Product removed  from order successfully.", _customerOrderService.RemoveProductFromOrder(id, orderId, productId));
    }

    [HttpPut("{id}/Orders/{orderId}/Address/{addressId}")]
    public ActionResult<ApiResult<GetCustomerOutput>> UpdateOrderAddress(long id, long orderId, long addressId)
    {
        return Success("Updated products in order successfully.", _customerOrderService.UpdateOrderAddress(id, orderId, addressId));
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
