using AutoMapper;
using CaspelTest.AutoMapper.dto;
using CaspelTest.Parsistence.Models;

namespace CaspelTest.AutoMapper.Mapper;

public class MapOrder : Profile
{
    public MapOrder()
    {
        CreateMap<Order, OrderModel>();
        CreateMap<OrderModel, Order>() // это самое сложно и интересное, что было в задании. Пришлось изрядно попотеть, для того, что бы найти материал и сделать вложенность. 
            .ForMember(dest => dest.OrderBooks,
                opt => opt.MapFrom(src 
                    => src.OrderBooks.Select(x=>new Book
                    {
                        DateOfCreate = x.DateOfCreate,
                        Id = x.Id,
                        Name = x.Name
                    })));
    }
}