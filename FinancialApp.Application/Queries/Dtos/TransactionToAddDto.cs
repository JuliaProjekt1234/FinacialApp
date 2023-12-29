

namespace FinancialApp.Application.Queries.Dtos;

public class TransactionToAddDto
{
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Amount { get; set; }
}