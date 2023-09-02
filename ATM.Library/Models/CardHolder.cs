namespace ATM.Library.Models;
public class CardHolder
{
    public string CardNum { get; set; } = string.Empty;
    public string Pin { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double Balance { get; set; } = 0;
}
