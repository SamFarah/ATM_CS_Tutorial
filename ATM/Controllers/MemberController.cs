using ATM.Library.Models;
using ATM.Library.Services;
using ATM.Models;
using ATM.Views;
using ATM.Views.Member;

namespace ATM.Controllers;
public class MemberController : IMemberController
{
    private readonly IMemberView _memerView;
    private readonly IAmountView _amountView;
    private readonly IOperationSuccessfullView _successfullView;
    private readonly IOperationFailedView _failedView;
    private readonly ITransactionsView _transactionsView;
    private readonly IAtmService _atm;

    public MemberController(IMemberView memerView,
                            IAmountView amountView,
                            IOperationSuccessfullView successfullView,
                            IOperationFailedView failedView,
                            ITransactionsView transactionsView,
                            IAtmService atm)
    {
        _memerView = memerView;
        _amountView = amountView;
        _successfullView = successfullView;
        _failedView = failedView;
        _transactionsView = transactionsView;
        _atm = atm;
    }
    public void MemberMenu(CardHolder cardHolder)
    {
        bool isExist = false;
        bool beep = true;
        while (!isExist)
        {
            var selectedOption = _memerView.DisplayView(cardHolder, beep);
            beep = false;// only beep first time;
            switch (selectedOption)
            {
                case 0: // deposit
                    var depositeAmount = _amountView.DisplayView();

                    if (depositeAmount != null)
                    {
                        if (_atm.AddTransaction(cardHolder.CardNum, cardHolder.Pin, depositeAmount.Value))
                        {
                            cardHolder = _atm.GetCardHolder(cardHolder.CardNum, cardHolder.Pin) ?? cardHolder;
                            _successfullView.DisplayView();
                        }
                        else
                        {
                            _failedView.DisplayView();
                        }
                    }
                    break;
                case 1: // withdraw
                    var withdrawamount = _amountView.DisplayView();
                    if (withdrawamount != null)
                    {
                        if (withdrawamount <= _atm.GetBalance(cardHolder.CardNum, cardHolder.Pin)) // get a fresh balance
                        {
                            if (_atm.AddTransaction(cardHolder.CardNum, cardHolder.Pin, -withdrawamount.Value))
                            {
                                cardHolder = _atm.GetCardHolder(cardHolder.CardNum, cardHolder.Pin) ?? cardHolder;
                                _successfullView.DisplayView();
                            }
                            else
                            {
                                _failedView.DisplayView();
                            }
                        }
                        else
                        {
                            _failedView.DisplayView("Insufficient Funds");
                        }
                    }
                    else
                    {
                        _failedView.DisplayView();
                    }
                    break;
                case 2:  // view Transactions
                    var model = new TransactionViewModel
                    {
                        CardHolder = cardHolder,
                        Transactions = _atm.GetTransactions(cardHolder.CardNum, cardHolder.Pin)
                    };

                    _transactionsView.DisplayView(model);

                    break;
                case 3: isExist = true; break;
            }
        }
    }
}
