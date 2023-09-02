using ATM.Library.Models;

namespace ATM.Library.Services;
public interface IAtmService
{
    bool AddTransaction(string cardNum, string pin, double amount);
    double? GetBalance(string cardNum, string pin);
    CardHolder? GetCardHolder(string cardNum, string pin);
    List<Transaction>? GetTransactions(string cardNum, string pin);
    CardHolder? SignIn(string carNum, string pin);
}