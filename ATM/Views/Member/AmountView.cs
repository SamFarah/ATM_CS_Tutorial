using ATM.Helpers;

namespace ATM.Views.Member;
public class AmountView : IAmountView
{
    public double? DisplayView()
    {
        ConsoleHelper.PushConfig();
        Console.CursorVisible = true;
        ConsoleHelper.WriteBordered("Enter Amount:\n $", Styles.PinBox);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(54, 15);
        var input = Console.ReadLine();
        ConsoleHelper.PopConfig();
        if (double.TryParse(input, out double amount)) return amount;

        return null;
    }
}
