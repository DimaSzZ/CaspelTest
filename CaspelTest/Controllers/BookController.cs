using AutoMapper;
using CaspelTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CaspelTest.Controllers;

[ApiController]
[Route("Book")]
public class BookController : BaseController
{
   private readonly IBookRepository _bookRepository;

   public BookController(IMapper mapper,IBookRepository repository) : base(mapper)
   {
      _bookRepository = repository;
   }
      
   [HttpPost("PostBook")]
   
   public async Task<IActionResult> PostBook([FromQuery]string name,DateTime date,CancellationToken cancellationToken)
   {
       await _bookRepository.PostBook(name, date, Mapper, cancellationToken);
      return Ok("Book has been created");
   }
   [HttpGet("SearchBook")]
   
   public async Task<IActionResult> SearchBook([FromQuery]string? name,DateTime? dateOnly,CancellationToken cancellationToken)
   {
      var result = await _bookRepository.Search(name, dateOnly, Mapper, cancellationToken);
      return Ok(result);
   }
   [HttpGet("GetBook")]
   public async Task<IActionResult> GetBook([FromQuery]int id,CancellationToken cancellationToken)
   {
      var result = await _bookRepository.OneById(id, Mapper, cancellationToken);
      return Ok(result);
   }
}