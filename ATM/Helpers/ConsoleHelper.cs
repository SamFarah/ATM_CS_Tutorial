namespace ATM.Helpers;


public static class ConsoleHelper
{

    private static readonly string[] _borderStyles =
    {
        "┌─┐│└┘├┤┬┴┼",
        "╔═╗║╚╝╠╣╦╩╬",
        "╒═╕│╘╛╞╡╤╧╪",
        "╓─╖║╙╜╟╢╥╨╫",
        "+-+|+++++"
    };


    public class ConsoleConfig
    {
        public ConsoleColor ForgroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public int CurserTop { get; set; }
        public int CurserLeft { get; set; }
        public bool CurserVisible { get; set; }
    }

    private static readonly Stack<ConsoleConfig> _consoleConfigStack = new();

    public static void PushConfig()
    {
        _consoleConfigStack.Push(new ConsoleConfig
        {
            ForgroundColor = Console.ForegroundColor,
            BackgroundColor = Console.BackgroundColor,
            CurserTop = Console.CursorLeft,
            CurserLeft = Console.CursorTop,
            CurserVisible = !OperatingSystem.IsWindows() || Console.CursorVisible
        });
    }

    public static void PopConfig()
    {
        var consoleConfig = _consoleConfigStack.Pop();
        Console.CursorTop = consoleConfig.CurserLeft;
        Console.ForegroundColor = consoleConfig.ForgroundColor;
        Console.BackgroundColor = consoleConfig.BackgroundColor;
        Console.CursorLeft = consoleConfig.CurserTop;
        Console.CursorVisible = consoleConfig.CurserVisible;
    }

    public static void WriteAt(string text, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }



    public static void WriteBordered(string text, Style? style = null)
    {
        style ??= new Style();

        var orgForColor = Console.ForegroundColor;
        var orgBackColor = Console.BackgroundColor;
        int orgCursLeft = Console.CursorLeft;
        int orgCursTop = Console.CursorTop;

        string border = _borderStyles[(int)style.LineStyle];




        var splitText = text.Trim().Replace("\r", "").Split('\n');
        var maxLineLength = splitText.Max(x => x.Length);
        int boxWidth = maxLineLength + style.PaddingRight + style.PaddingLeft;
        string blankPad = "".PadRight(boxWidth, ' ');



        Console.SetCursorPosition(style.Left, style.Top);
        Console.ForegroundColor = style.BorderColor;
        Console.BackgroundColor = style.FillColor;
        Console.Write(border[0]);
        for (var i = 0; i < boxWidth; i++)
        {
            Console.Write(border[1]);
        }
        Console.WriteLine(border[2]);

        for (var i = 0; i < style.PaddingTop; i++)
        {
            Console.CursorLeft = style.Left;
            Console.WriteLine($"{border[3]}{blankPad}{border[3]}");
        }


        for (var i = 0; i < splitText.Length; i++)
        {
            Console.CursorLeft = style.Left;
            Console.Write($"{border[3]}{"".PadLeft(style.PaddingLeft, ' ')}");
            Console.ForegroundColor = style.TextColor;
            Console.Write(splitText[i]);
            Console.ForegroundColor = style.BorderColor;
            Console.WriteLine($"{"".PadLeft(style.PaddingRight + (maxLineLength - splitText[i].Length), ' ')}{border[3]}");
        }



        for (var i = 0; i < style.PaddingBottom; i++)
        {
            Console.CursorLeft = style.Left;
            Console.WriteLine($"{border[3]}{blankPad}{border[3]}");
        }
        Console.CursorLeft = style.Left;
        Console.Write(border[4]);
        for (var i = 0; i < boxWidth; i++)
        {
            Console.Write(border[1]);
        }
        Console.WriteLine(border[5]);

        Console.ForegroundColor = orgForColor;
        Console.BackgroundColor = orgBackColor;
        Console.SetCursorPosition(orgCursLeft + 3, orgCursTop + 3);

    }

    public static void DrawBorder(Style? style = null)
    {

        int orgCursLeft = Console.CursorLeft;
        int orgCursTop = Console.CursorTop;

        style ??= new Style();

        string border = _borderStyles[(int)style.LineStyle];

        Console.SetCursorPosition(style.Left, style.Top);
        Console.ForegroundColor = style.BorderColor;
        Console.BackgroundColor = style.FillColor;
        Console.Write(border[0]);

        Console.Write("".PadLeft(Console.WindowWidth - 2 - (style.Left * 2), border[1]));

        Console.WriteLine(border[2]);

        for (int i = 0; i < Console.WindowHeight - 2 - (style.Top * 2); i++)
        {
            Console.CursorLeft = style.Left;
            Console.Write(border[3]);
            Console.Write("".PadLeft(Console.WindowWidth - 2 - (style.Left * 2), ' '));
            Console.WriteLine(border[3]);
        }
        Console.CursorLeft = style.Left;
        Console.Write(border[4]);
        Console.Write("".PadLeft(Console.WindowWidth - 2 - (style.Left * 2), border[1]));
        Console.WriteLine(border[5]);

        Console.SetCursorPosition(orgCursLeft + 3, orgCursTop + 3);

    }
}

public enum LineStyle
{
    Single,
    Double,
    DHSV,
    SHDV,
    OldSchoole
}
public class Style
{
    public LineStyle LineStyle { get; set; } = LineStyle.Single;

    public int Top { get; set; } = Console.CursorTop;
    public int Left { get; set; } = Console.CursorLeft;
    public ConsoleColor BorderColor { get; set; } = Console.ForegroundColor;
    public ConsoleColor TextColor { get; set; } = Console.ForegroundColor;
    public ConsoleColor FillColor { get; set; } = Console.BackgroundColor;
    public int PaddingTop { get; set; } = 1;
    public int PaddingBottom { get; set; } = 1;
    public int PaddingLeft { get; set; } = 2;
    public int PaddingRight { get; set; } = 2;
    public int Padding
    {
        set
        {
            PaddingTop = value;
            PaddingBottom = value;
            PaddingLeft = value;
            PaddingRight = value;
        }
    }
    public int PaddingX
    {
        set
        {
            PaddingLeft = value;
            PaddingRight = value;
        }
    }

    public int PaddingY
    {
        set
        {
            PaddingTop = value;
            PaddingBottom = value;
        }
    }
}


