using ATM.Helpers;

namespace ATM.Views.Guest;
public class InvalidLoginView : IInvalidLoginView
{
    public void DisplayView()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(800, 50);
            Console.Beep(800, 50);
            Console.Beep(800, 100);
        }


        ConsoleHelper.WriteBordered("Invalid Information", Styles.InvalidMessage);
        Console.ReadKey(true);
    }
}
