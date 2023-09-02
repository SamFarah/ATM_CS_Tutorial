using System.ComponentModel.DataAnnotations;

namespace ATM.Data.Models;
public class CardHolder
{
    [Key]
    public int Id { get; set; }

    [StringLength(16)]
    public string CardNum { get; set; } = string.Empty;

    [StringLength(4)]
    public string Pin { get; set; } = string.Empty;

    [MaxLength(128)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string LastName { get; set; } = string.Empty;

    public double Balance { get; set; } = 0;


    public CardHolder() { }

    public CardHolder(int id, string cardNum, string pin, string firstName, string lastName, double balance)
    {
        Id = id;
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }
}
