using ATM.Models;

namespace ATM.Views.Member;
public class TransactionsView : ITransactionsView
{
    private readonly IMasterView _masterView;
    public TransactionsView(IMasterView masterView)
    {
        _masterView = masterView;
    }
    public void DisplayView(TransactionViewModel model)
    {
        _masterView.DisplayView();

        var left = Styles.MainBorder.Left + 3;


        if (model?.CardHolder == null) return;
        Console.SetCursorPosition(left + 1, Styles.MainBorder.Top + 3);
        Console.WriteLine($"Member: {model.CardHolder.FirstName} {model.CardHolder.LastName}");
        Console.CursorLeft = left + 1;
        Console.WriteLine($"Card Numner: {"".PadRight(model.CardHolder.CardNum.Length - 4, '*')}{model.CardHolder.CardNum[^4..]}");

        Console.SetCursorPosition(left, Styles.MainBorder.Top + 5);

        // TODO: This can be refactored into a generic table builder.
        // TODO: handle paging

        Console.Write("╔");
        Console.Write("".PadLeft(23, '═'));
        Console.Write("╤");
        Console.Write("".PadLeft(15, '═'));
        Console.Write("╤");
        Console.Write("".PadLeft(12, '═'));
        Console.Write("╤");
        Console.Write("".PadLeft(12, '═'));
        Console.Write("╤");
        Console.Write("".PadLeft(12, '═'));
        Console.WriteLine("╗");

        Console.CursorLeft = left;
        Console.Write("║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Date".PadRight(23, ' '));
        Console.ForegroundColor = Styles.MainBorder.TextColor;
        Console.Write("│");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Item".PadRight(15, ' '));
        Console.ForegroundColor = Styles.MainBorder.TextColor;
        Console.Write("│");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Money In".PadRight(12, ' '));
        Console.ForegroundColor = Styles.MainBorder.TextColor;
        Console.Write("│");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Money Out".PadRight(12, ' '));
        Console.ForegroundColor = Styles.MainBorder.TextColor;
        Console.Write("│");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Balance".PadRight(12, ' '));
        Console.ForegroundColor = Styles.MainBorder.TextColor;
        Console.WriteLine("║");

        Console.CursorLeft = left;
        Console.Write("╟");
        Console.Write("".PadLeft(23, '─'));
        Console.Write("┼");
        Console.Write("".PadLeft(15, '─'));
        Console.Write("┼");
        Console.Write("".PadLeft(12, '─'));
        Console.Write("┼");
        Console.Write("".PadLeft(12, '─'));
        Console.Write("┼");
        Console.Write("".PadLeft(12, '─'));
        Console.WriteLine("╢");

        if (model.Transactions != null)
        {
            foreach (var transaction in model.Transactions)
            {
                Console.CursorLeft = left;
                Console.Write("║");
                Console.Write(transaction.TimeStamp.ToString().PadRight(23, ' '));
                Console.Write("│");


                if (transaction.Amount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("  ATM Deposit".PadRight(15, ' '));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  ATM withdraw".PadRight(15, ' '));
                }
                Console.ForegroundColor = Styles.MainBorder.TextColor;


                Console.Write("│");


                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((transaction.MoneyIn?.ToString("C") ?? "").PadLeft(12, ' '));
                Console.ForegroundColor = Styles.MainBorder.TextColor;

                Console.Write("│");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write((transaction.MoneyOut?.ToString("C") ?? "").PadLeft(12, ' '));
                Console.ForegroundColor = Styles.MainBorder.TextColor;


                Console.Write("│");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(transaction.Balance.ToString("C").PadLeft(12, ' '));
                Console.BackgroundColor = Styles.MainBorder.FillColor;
                Console.ForegroundColor = Styles.MainBorder.TextColor;
                Console.WriteLine("║");
            }
        }

        Console.CursorLeft = left;
        Console.Write("╚");
        Console.Write("".PadLeft(23, '═'));
        Console.Write("╧");
        Console.Write("".PadLeft(15, '═'));
        Console.Write("╧");
        Console.Write("".PadLeft(12, '═'));
        Console.Write("╧");
        Console.Write("".PadLeft(12, '═'));
        Console.Write("╧");
        Console.Write("".PadLeft(12, '═'));
        Console.WriteLine("╝");

        Console.ReadLine();
    }
}
