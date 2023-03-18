using CaspelTest.Parsistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspelTest.Parsistence.Configurations;

///<summary>
/// Конфигурация для моедли Books
///</summary>
public class BookConfiguration : IEntityTypeConfiguration<BookModel>
{
    public void Configure(EntityTypeBuilder<BookModel> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(book => book.Id);
        builder
            .Property(book => book.Id)
            .HasColumnName("Id")
            .HasColumnType("int");
        builder
            .Property(book => book.Name)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(30)");
        builder
            .Property(book => book.DateOfCreate)
            .HasColumnName("DateOfCreate")
            .HasColumnType("date");
        builder
            .HasMany(book => book.Orders)
            .WithMany(orderBook => orderBook.OrderBooks);
    }
}
