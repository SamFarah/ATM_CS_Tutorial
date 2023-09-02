using ATM.Data;
using ATM.Data.Models;

namespace ATM.Library.DataAccess;
public class TransactionData : ITransactionData
{
    private readonly IAtmDbContext _db;

    public TransactionData(IAtmDbContext db)
    {
        _db = db;
    }

    public void AddTransaction(CardHolder cardHolder, double amount)
    {
        var newTransaciton = new Transaction
        {
            CardHoler = cardHolder,
            Amount = amount,
            Balance = cardHolder.Balance + amount,
            TimeStamp = DateTime.UtcNow
        };
        _db.Transactions.Add(newTransaciton);
        _db.SaveChanges();

    }

    public List<Transaction> GetTransactions(int cardHolderId)
    {
        return _db.Transactions.Where(x => x.CardHoler != null && x.CardHoler.Id == cardHolderId).OrderByDescending(x => x.TimeStamp).ToList();
    }
}
