using Domain.Orders;

namespace Presentation.Customers.Dtos
{
    public record CustomerCreateDto(string Name, string CPF, string? Address, int? PhoneNumber, DateTime? BirthDate, ICollection<Order>? Orders);
}
