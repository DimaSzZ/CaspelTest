using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CaspelTest.Controllers;

///<summary>
/// Реализую маппер, что бы могли пользоваться все контроллеры, которые наследуются от него 
///</summary>
/// 
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IMapper Mapper;
    public BaseController(IMapper mapper)
    {
        Mapper = mapper;
    }
}