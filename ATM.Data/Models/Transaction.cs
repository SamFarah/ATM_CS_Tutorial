using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models;
public class Transaction
{
    [Key]
    public int Id { get; set; }
    public CardHolder? CardHoler { get; set; }
    public double Amount { get; set; }
    public DateTime TimeStamp { get; set; }
    public double Balance { get; set; }
}
