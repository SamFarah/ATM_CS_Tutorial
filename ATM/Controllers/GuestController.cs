using ATM.Library.Services;
using ATM.Views.Guest;

namespace ATM.Controllers;
public class GuestController : IGuestController
{
    private readonly IGuestView _guestView;
    private readonly IInvalidLoginView _invalidLoginView;
    private readonly IMemberController _memberController;
    private readonly IAtmService _atm;

    public GuestController(IGuestView guestView,
                           IInvalidLoginView invalidLoginView,
                           IMemberController memberController,
                           IAtmService atm)
    {
        _guestView = guestView;
        _invalidLoginView = invalidLoginView;
        _memberController = memberController;
        _atm = atm;
    }

    public void GuestMenu()
    {
        var model = _guestView.DisplayView();


        if (model?.CardNum != null && model?.Pin != null)
        {
            var cardHolder = _atm.SignIn(model.CardNum, model.Pin);
            if (cardHolder != null)
            {
                _memberController.MemberMenu(cardHolder);
            }
            else
            {
                _invalidLoginView.DisplayView();
            }
        }
    }



}
