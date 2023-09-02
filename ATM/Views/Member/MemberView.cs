using ATM.Helpers;
using ATM.Library.Models;

namespace ATM.Views.Member;
public class MemberView : IMemberView
{
    private readonly IMasterView _masterView;

    public MemberView(IMasterView masterView)
    {
        _masterView = masterView;
    }
    public int DisplayView(CardHolder model, bool beep = true)
    {
        if (beep && OperatingSystem.IsWindows())
        {
            Console.Beep(1000, 50);
            Console.Beep(1200, 50);
            Console.Beep(1600, 100);
        }
        _masterView.DisplayView();
        Console.CursorVisible = false;

        var options = new List<string>{
            "1) Deposit",
            "2) Withdraw",
            "3) Show Transactions",
            "4) Logout"
        };

        ConsoleHelper.WriteBordered($@"Member: {model.FirstName} {model.LastName}
Card: {"".PadRight(model.CardNum.Length - 4, '*')}{model.CardNum[^4..]}
Balance: {model.Balance:C}", Styles.MemberInfo);


        var selectedOption = 0;
        while (true)
        {
            ConsoleHelper.WriteBordered($"Please choose from one of the following options...\n\n{string.Join('\n', options)}", Styles.InnerBorder);

            var firstOptionLocationTop = Styles.InnerBorder.Top + Styles.InnerBorder.PaddingTop + selectedOption + 3;
            var firstOptionLocationLeft = Styles.InnerBorder.Left + Styles.InnerBorder.PaddingLeft + 1;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(firstOptionLocationLeft, firstOptionLocationTop);
            Console.Write(options[selectedOption]);

            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption + 1) % options.Count;
                    break;
                case ConsoleKey.UpArrow:
                    selectedOption = selectedOption == 0 ? options.Count - 1 : selectedOption - 1;
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                    selectedOption = int.Parse(key.KeyChar.ToString()) - 1;
                    break;

                case ConsoleKey.Enter:
                    return selectedOption;
            }
        }


    }
}
