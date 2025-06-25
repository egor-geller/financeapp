namespace fin.server.Models.Transactions
{
    public class Transaction
    {
        public int TransactionId { get; set; } 
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }

        public string? Note { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
