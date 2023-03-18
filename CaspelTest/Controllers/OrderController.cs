using AutoMapper;
using CaspelTest.AutoMapper.dto;
using CaspelTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaspelTest.Controllers;

[ApiController]
[Route("Order")]
public class OrderController : BaseController
{
    private readonly IOrderRepository _repository;
    public OrderController(IMapper mapper,IOrderRepository repository) : base(mapper)
    {
        _repository = repository;
    }
    [HttpPost("AddOrder")]
   
    public async Task<IActionResult> AddOrder([FromBody]Order order,CancellationToken cancellationToken)
    {
        await _repository.PostOrder(order,Mapper,cancellationToken);
        return Ok("Your order has been received and sent for processing.");
    }
    [HttpGet("SearchOrders")]
    public async Task<IActionResult> SearchOrders([FromQuery]int? id,DateTime? date,CancellationToken cancellationToken)
    {
        var result = await _repository.SearchOrders(id, date, Mapper, cancellationToken);
        return Ok(result);
    }
}