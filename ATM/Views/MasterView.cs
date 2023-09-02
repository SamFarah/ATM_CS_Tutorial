using ATM.Helpers;

namespace ATM.Views;
public class MasterView : IMasterView
{
    public void DisplayView()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Clear();

        ConsoleHelper.PushConfig();

        Console.CursorVisible = false;
        ConsoleHelper.DrawBorder(Styles.MainBorder);
        DisplayDateTime();
        ConsoleHelper.WriteBordered("Welcome to Less Simple ATM", Styles.BorderedText);
        ConsoleHelper.PopConfig();

    }

    public void DisplayDateTime()
    {
        ConsoleHelper.PushConfig();
        Console.CursorVisible = false;
        Console.SetCursorPosition(Styles.MainBorder.Left + 10, Console.WindowHeight - (Styles.MainBorder.Top * 2));
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = Styles.MainBorder.FillColor;

        Console.Write(DateTime.Now.ToString(" dddd  MMMM d, yyyy "));
        var timeText = DateTime.Now.ToString(" HH:mm:ss ");

        Console.CursorLeft = Console.WindowWidth - (10 + Styles.MainBorder.Left + timeText.Length);
        Console.Write(timeText);
        ConsoleHelper.PopConfig();
    }
}
