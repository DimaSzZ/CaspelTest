using AutoMapper;
using CaspelTest.AutoMapper.dto;

namespace CaspelTest.Repositories;

///<summary>
/// Обычные репозитории, для реализации паттерна репозиторий в сервисах.
///</summary>
public interface IBookRepository
{
    public Task<List<Book>> Search(string? Name,DateTime? date, IMapper mapper, CancellationToken cancellationToken);

    public Task PostBook(string Name, DateTime date, IMapper mapper, CancellationToken cancellationToken);
    public Task<Book> OneById(int id, IMapper mapper, CancellationToken cancellationToken);
}