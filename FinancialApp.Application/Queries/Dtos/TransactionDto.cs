namespace FinancialApp.Application.Queries.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Amount { get; set; }
    public DateTime TransationDate { get; set; }
}
