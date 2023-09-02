using ATM.Library.DataAccess;
using ATM.Library.Models;
using AutoMapper;

namespace ATM.Library.Services;
public class AtmService : IAtmService
{
    private readonly ICardHolderData _cardholderData;
    private readonly ITransactionData _transactionData;
    private readonly IMapper _mapper;

    public AtmService(ICardHolderData cardholders,
                      ITransactionData transactionData,
                      IMapper mapper)
    {
        _cardholderData = cardholders;
        _transactionData = transactionData;
        _mapper = mapper;
    }

    public CardHolder? SignIn(string carNum, string pin)
    {
        var cardHolder = _cardholderData.GetCardHolder(carNum);
        if (cardHolder != null)
        {
            if (cardHolder.Pin == pin)
            {
                return _mapper.Map<CardHolder>(cardHolder);
            }
            else
            {
                // Increase some kind of attempt counter;
            }

        }
        return null;
    }

    public double? GetBalance(string cardNum, string pin)
    {
        var cardHolder = _cardholderData.GetCardHolder(cardNum, pin);
        return cardHolder?.Balance;
    }

    public bool AddTransaction(string cardNum, string pin, double amount)
    {
        if (amount == 0) return false; // no point putting in a transaction for 0 amount
        var cardHolder = _cardholderData.GetCardHolder(cardNum, pin);
        if (cardHolder != null)
        {
            if (amount < 0) // withdraw
            {
                if (cardHolder.Balance < amount) return false;
            }
            _transactionData.AddTransaction(cardHolder, amount);
            _cardholderData.UpdateBalance(cardHolder, amount);
            return true;
        }


        return false;
    }

    public CardHolder? GetCardHolder(string cardNum, string pin)
    {
        var cardHolder = _cardholderData.GetCardHolder(cardNum, pin);
        return _mapper.Map<CardHolder>(cardHolder);
    }

    public List<Transaction>? GetTransactions(string cardNum, string pin)
    {
        var cardHolder = _cardholderData.GetCardHolder(cardNum, pin);
        if (cardHolder != null)
        {
            var transactions = _transactionData.GetTransactions(cardHolder.Id);
            return _mapper.Map<List<Transaction>>(transactions);
        }
        return null;
    }
}
