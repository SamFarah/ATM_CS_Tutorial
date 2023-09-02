using ATM.Data.Models;

namespace ATM.Library.DataAccess;
public interface ITransactionData
{
    void AddTransaction(CardHolder cardHolder, double amount);
    List<Transaction> GetTransactions(int cardHolderId);
}