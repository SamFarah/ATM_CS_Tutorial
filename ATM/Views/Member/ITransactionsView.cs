using ATM.Models;

namespace ATM.Views.Member;
public interface ITransactionsView
{
    void DisplayView(TransactionViewModel model);
}