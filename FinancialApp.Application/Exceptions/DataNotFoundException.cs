namespace FinancialApp.Application.Exceptions
{
    public class DataNotFoundException:Exception
    {
        public DataNotFoundException(string name, object key): base($"{name} - {key} was not found")
        {
                
        }
    }
}
