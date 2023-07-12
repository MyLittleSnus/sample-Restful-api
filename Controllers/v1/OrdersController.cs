using GoodsApi.Infrustructure.DTO;
using GoodsApi.Models;
using GoodsApi.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GoodsApi.Infrustructure;

namespace GoodsApi.Controllers.v1;

[ApiController]
[Route("orders")]
[Route("v{version:apiVersion}/orders")]
[ApiVersion("1.0")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;
    private readonly IMapper _mapper;

    public OrdersController(
        OrderService service,
        IMapper mapper,
        Generators generatorsFactory)
    {
        _service = service;
        _mapper = mapper;

        generatorsFactory
            .CreateGenerator(GeneratorType.GoodsGenerator)
            .Generate();
    }

    [Route("")]
    [Route("all")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(void))]
    public async Task<IEnumerable<OrderDTO>> GetAll()
    {
        var orders = await _service.GetCompleteOrders();

        return orders.Select(_mapper.Map<OrderDTO>);
    }

    [Route("new")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(void))]
    public async Task<IActionResult> CreateNewOrder([FromBody] OrderDTO orderDTO)
    {
        if (orderDTO == null)
            return BadRequest("Input object was null");
        try
        {
            var orderModel = _mapper.Map<Order>(orderDTO);

            var result = await _service.CreateOrder(orderModel);

            if (!result)
                return StatusCode(500, "Create operation failed");
        }
        catch
        {
            return StatusCode(500, "Error occured");
        }

        return Ok("Order has been created succesfuly");
    }

    [HttpDelete]
    [Route("close/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(void))]
    public async Task<IActionResult> CloseOrder(string id)
    {
        try
        {
            Guid.Parse(id);
        }
        catch
        {
            return BadRequest("Invalid id format");
        }

        var result = await _service.DeleteOrder(id.ToString());

        if (!result)
            return StatusCode(500, "Order has not been deleted");

        return Ok($"Order with id {id} has been deleted succesfuly");
    }

    [HttpPut]
    [Route("edit/status/{id:guid}&{status:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(void))]
    public async Task<IActionResult> UpdateOrder(string id, int status)
    {
        var result = await _service.UpdateOrderStatus((id, status));

        if (!result)
            return StatusCode(500, "Update operation failed");

        return Ok("Status has been changed succesfuly");
    }
}