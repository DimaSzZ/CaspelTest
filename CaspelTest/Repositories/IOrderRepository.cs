using AutoMapper;
using CaspelTest.AutoMapper.dto;

namespace CaspelTest.Repositories;

public interface IOrderRepository
{
    public Task PostOrder(Order order, IMapper mapper,CancellationToken cancellationToken);
    public Task<List<Order>> SearchOrders(int? id, DateTime? dateOrder, IMapper mapper, CancellationToken cancellationToken);
}