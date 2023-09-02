using ATM.Helpers;
using ATM.Models;

namespace ATM.Views.Guest;
public class GuestView : IGuestView
{
    private readonly IMasterView _masterView;
    private LoginViewModel? _model;

    public GuestView(IMasterView masterView)
    {
        _masterView = masterView;
    }

    public LoginViewModel? DisplayView()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(1000, 100); ;
        }
        _masterView.DisplayView();

        //ConsoleHelper.DrawBorder(Styles.InnerBorder);       
        ConsoleHelper.WriteBordered("Please insert your debit card", Styles.InsertCard);
        Console.ForegroundColor = Styles.InsertCard.TextColor;
        Console.SetCursorPosition(Styles.InsertCard.Left + 1, Styles.InsertCard.Top + 3);

        _model = new LoginViewModel
        {
            CardNum = Console.ReadLine()
        };

        ConsoleHelper.WriteBordered("Enter Pin Number:\n->", Styles.PinBox);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(54, 15);

        var pinStack = new Stack<char>();
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) break;
            if (key.Key == ConsoleKey.Escape) break;
            if (key.Key == ConsoleKey.Backspace)
            {
                if (pinStack.Count > 0)
                {
                    pinStack.Pop();
                    Console.Write(key.KeyChar);
                }
                continue;
            }
            Console.Write("*");
            pinStack.Push(key.KeyChar);
        }
        _model.Pin = string.Join("", pinStack.Reverse().ToArray());
        return _model;
    }
}
