namespace Presentation.Customers.Dtos
{
    public record CustomerUpdateDto (string? Name, string? CPF, string? Address, int? PhoneNumber, DateTime? BirthDate);
}
