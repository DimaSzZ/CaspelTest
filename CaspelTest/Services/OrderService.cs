using AutoMapper;
using CaspelTest.AutoMapper.dto;
using CaspelTest.Exception;
using CaspelTest.Parsistence.Models;
using CaspelTest.Parsistence.MSSQLDbContext;
using CaspelTest.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CaspelTest.Services;

public class OrderService : IOrderRepository
{
    private readonly SqlDbContext _db;
    public OrderService(SqlDbContext db)
    {
        _db = db;
    }
    ///<summary>
    /// Создает заказ, если заказ не пустой, иначе кастомная ошибка
    ///</summary>
    public async Task PostOrder(Order order, IMapper mapper, CancellationToken cancellationToken)
    {
        if (order.OrderBooks.Count >= 1)
        {
            await _db.OrderModels.AddAsync(mapper.Map<OrderModel>(order), cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
        }
        else
        {
            throw new OrderException();
        }
    }
    ///<summary>
    /// Как и в BookService, показывает ответ в зависимости от того, что мы указали. 
    ///</summary>
    public async Task<List<Order>> SearchOrders(int? id, DateTime? dateOrder, IMapper mapper, CancellationToken cancellationToken)
    {
        
        var result = _db.OrderModels.AsQueryable();
        result = id != null
            ? result.Where(x => x.Id == id)
            : result;

        result = dateOrder != null
            ? result.Where(x => x.DateOrder == dateOrder)
            : result;

        var orders = await result.ToListAsync(cancellationToken);
        var mappedOrders = mapper.Map<List<OrderModel>, List<Order>>(orders);
        return mappedOrders;
    }
}