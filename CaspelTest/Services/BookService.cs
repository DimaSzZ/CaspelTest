using AutoMapper;
using CaspelTest.AutoMapper.dto;
using CaspelTest.Exception;
using CaspelTest.Parsistence.Models;
using CaspelTest.Parsistence.MSSQLDbContext;
using CaspelTest.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CaspelTest.Services;


///<summary>
/// Во все мои методы передается mapper, потому что все мои апи наследуются от кастомного BaseController и мне показалось это
/// хорошей идеей.
///</summary>
public class BookService : IBookRepository
{
    private readonly SqlDbContext _db;
    public BookService(SqlDbContext db)
    {
        _db = db;
    }
    ///<summary>
    /// Метод, который позволяет нам получить книги, в зафисимости от тех данных, которые мы ввели (фильтры)
    ///</summary>
    public async Task<List<Book>> Search(string? name,DateTime? date, IMapper mapper, CancellationToken cancellationToken)
    {
        var result = _db.BookModels.AsQueryable()
            .Where(x => string.IsNullOrWhiteSpace(name) ? true : x.Name == name)
            .Where(x => date == null ? true : x.DateOfCreate == date);

        return await result.Select(x => mapper.Map<Book>(x)).ToListAsync(cancellationToken);
    }
    ///<summary>
    /// Вынужденные метод, который пришлось добавить для тестирования. Просто добавляет книгу
    ///</summary>
    public async Task PostBook(string Name, DateTime date, IMapper mapper, CancellationToken cancellationToken)
    {
        await _db.BookModels.AddAsync(new BookModel { Name = Name, DateOfCreate = date },cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }
    ///<summary>
    /// Находит книгу по Id
    ///</summary>
    public async Task<Book> OneById(int id, IMapper mapper, CancellationToken cancellationToken)
    {
        return _db.BookModels.Any(x => x.Id == id)
            ? mapper.Map<Book>(await _db.BookModels.Where(x => x.Id == id).FirstAsync(cancellationToken))
            : throw new BookIdException(id);
    }
}