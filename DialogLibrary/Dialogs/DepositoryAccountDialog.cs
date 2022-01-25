using ModelLibrary;
using System;

namespace DialogLibrary
{
    /// <summary>
    /// Класс диалогового окна отображения депозитарных счетов
    /// </summary>
    public class DepositoryAccountDialog
    {
        public void OpenDialog(IBankCustomer bankCustomer)
        {
            if(bankCustomer is null)
                throw new ArgumentNullException("Клиент банка не может быть null!!!");

            var dialog = new DepositoryAccountWindow();

            dialog.Title = "Список депозитарных счетов";
            dialog.DepositoryAccounts = bankCustomer.DepositoryAccounts;

            if (dialog.ShowDialog() != true) return;
        }
    }
}
