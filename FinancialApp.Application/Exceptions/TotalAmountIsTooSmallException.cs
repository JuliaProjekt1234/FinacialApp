
namespace FinancialApp.Application.Exceptions;

public class TotalAmountIsTooSmallException : Exception
{
    public TotalAmountIsTooSmallException(double totalAmount, double transactionAmount) :
        base($"Total amount is {totalAmount}. You can not create transaction with an amount {transactionAmount}")
    {

    }
}
