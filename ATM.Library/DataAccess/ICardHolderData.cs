using ATM.Data.Models;

namespace ATM.Library.DataAccess;
public interface ICardHolderData
{
    CardHolder? GetCardHolder(string cardNum);
    CardHolder? GetCardHolder(string cardNum, string pin);
    void UpdateBalance(CardHolder cardHolder, double amount);
}