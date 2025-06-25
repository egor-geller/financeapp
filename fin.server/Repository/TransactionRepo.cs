using fin.server.Data;
using fin.server.Models.Transactions;
using fin.server.Repository.Interface;

namespace fin.server.Repository
{
    public class TransactionRepo : ITransaction
    {
        private readonly FinContext _context;
        public TransactionRepo(FinContext context)
        {
            _context = context;
        }
        public async Task<bool> IsCreditCardExist(int creditNumber, int cvc, DateTime creditDate)
        {
            Transaction? transaction = await _context.Transactions.FindAsync(creditNumber, cvc, creditDate);
            return transaction != null;
        }

        public async Task<bool> IsCreditCardExist(int creditNumber, int cvc)
        {
            Transaction? transaction = await _context.Transactions.FindAsync(creditNumber, cvc);
            return transaction != null;
        }
    }
}
