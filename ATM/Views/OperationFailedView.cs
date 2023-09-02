using ATM.Helpers;

namespace ATM.Views;
public class OperationFailedView : IOperationFailedView
{
    public void DisplayView(string? Message = null)
    {
        ConsoleHelper.WriteBordered(Message ?? "Operation Failed", Styles.InvalidMessage);
        Console.ReadKey(true);
    }
}
