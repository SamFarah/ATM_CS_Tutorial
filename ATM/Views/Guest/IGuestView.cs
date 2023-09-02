using ATM.Models;

namespace ATM.Views.Guest;

public interface IGuestView
{
    LoginViewModel? DisplayView();
}