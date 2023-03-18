using CaspelTest.Parsistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaspelTest.Parsistence.Configurations;

///<summary>
/// Конфигурация для модели Orders
///</summary>
public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
{
    public void Configure(EntityTypeBuilder<OrderModel> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(order => order.Id);
        builder
            .Property(order => order.Id)
            .HasColumnName("Id")
            .HasColumnType("int");
        builder
            .Property(order => order.DateOrder)
            .HasColumnName("DateOrder")
            .HasColumnType("date");
    }
}