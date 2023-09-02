using ATM.Library.Models;

namespace ATM.Views.Member;

public interface IMemberView
{
    int DisplayView(CardHolder model, bool beep = true);
}