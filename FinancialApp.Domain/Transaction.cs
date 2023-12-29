using FinancialApp.Domain.Common;

namespace FinancialApp.Domain;

public class Transaction : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime TransationDate { get; set; }
    public double Amount { get; set; }
}
