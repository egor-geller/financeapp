namespace fin.server.Repository.Interface
{
    public interface ITransaction
    {
        Task<bool> IsCreditCardExist(int creditNumber, int cvc, DateTime creditDate);
        Task<bool> IsCreditCardExist(int creditNumber, int cvc);
    }
}
