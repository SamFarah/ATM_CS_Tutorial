using ATM.Data;
using ATM.Data.Models;

namespace ATM.Library.DataAccess;
public class CardHolderData : ICardHolderData
{
    private readonly IAtmDbContext _db;

    public CardHolderData(IAtmDbContext db)
    {
        _db = db;
    }

    public CardHolder? GetCardHolder(string cardNum)
    {
        var ouput = _db.CardHolders.FirstOrDefault(x => x.CardNum == cardNum);
        return ouput;
    }

    public CardHolder? GetCardHolder(string cardNum, string pin)
    {
        var ouput = _db.CardHolders.FirstOrDefault(x => x.CardNum == cardNum && x.Pin == pin);
        return ouput;
    }

    public void UpdateBalance(CardHolder cardHolder, double amount)
    {
        cardHolder.Balance += amount;
        _db.CardHolders.Update(cardHolder);
        _db.SaveChanges();
    }
}
