using ATM.Helpers;

namespace ATM.Views;
public class OperationSuccessfullView : IOperationSuccessfullView
{
    public void DisplayView()
    {

        ConsoleHelper.WriteBordered("Success", Styles.SuccessMessage);
        Console.ReadKey(true);
    }
}
