using ATM.Helpers;

namespace ATM.Views;
public class Styles
{
    public static Style BorderedText = new()
    {
        Top = 0,
        Left = 43,
        PaddingX = 2,
        PaddingY = 0,
        TextColor = ConsoleColor.Yellow,
        LineStyle = LineStyle.Single,
        FillColor = ConsoleColor.DarkBlue
    };

    public static Style MainBorder = new()
    {
        Top = 1,
        Left = 2,
        LineStyle = LineStyle.Double
    };

    public static Style InnerBorder = new()
    {
        Top = 11,
        Left = 32,
        LineStyle = LineStyle.Single
    };

    public static Style InsertCard = new()
    {
        Top = 13,
        Left = 43,
        BorderColor = ConsoleColor.Red,
        TextColor = ConsoleColor.Red,
        Padding = 0,
        PaddingX = 1
    };

    public static Style PinBox = new()
    {
        Top = 12,
        Left = 49,
        BorderColor = ConsoleColor.Cyan,
        TextColor = ConsoleColor.Cyan,
        FillColor = ConsoleColor.DarkGray,
        Padding = 1,
    };

    public static Style MemberInfo = new()
    {
        Top = 3,
        Left = 6,
        TextColor = ConsoleColor.DarkBlue,
        BorderColor = ConsoleColor.DarkBlue,
        FillColor = ConsoleColor.Cyan,
        Padding = 0,
        PaddingX = 1

    };

    public static Style InvalidMessage = new()
    {
        Top = 13,
        Left = 48,
        BorderColor = ConsoleColor.Black,
        TextColor = ConsoleColor.Black,
        FillColor = ConsoleColor.Red,
        Padding = 0,
        PaddingX = 1,
    };

    public static Style SuccessMessage = new()
    {
        Top = 14,
        Left = 51,
        BorderColor = ConsoleColor.Black,
        TextColor = ConsoleColor.Black,
        FillColor = ConsoleColor.DarkGreen,
        Padding = 0,
        PaddingX = 1,
    };

    public static Style TableHeader = new()
    {

    };
}
