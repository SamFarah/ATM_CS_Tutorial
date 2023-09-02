using ATM.Library.Models;

namespace ATM.Models;
public class TransactionViewModel
{
    public CardHolder? CardHolder { get; set; }
    public List<Transaction>? Transactions { get; set; }
}
