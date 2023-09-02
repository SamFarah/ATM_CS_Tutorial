namespace ATM.Library.Models;
public class Transaction
{
    public int Id { get; set; }
    public CardHolder? CardHoler { get; set; }
    public double Amount { get; set; }
    public DateTime TimeStamp { get; set; }
    public double Balance { get; set; }
    public double? MoneyIn => Amount > 0 ? Amount : null;
    public double? MoneyOut => Amount < 0 ? -Amount : null;
}
