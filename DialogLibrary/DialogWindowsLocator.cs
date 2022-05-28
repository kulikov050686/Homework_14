namespace DialogLibrary
{
    /// <summary>
    /// Локатор диалоговых окон
    /// </summary>
    public class DialogWindowsLocator
    {
        /// <summary>
        /// Получить Окно Добавления Редактирования Банковского счета
        /// </summary>
        public AddEditBankAccountWindow GetAddEditBankAccountWindow() => new AddEditBankAccountWindow();

        /// <summary>
        /// Получить Окно Добавить Редактировать Клиента Банка
        /// </summary>
        public AddEditBankCustomerWindow GetAddEditBankCustomerWindow() => new AddEditBankCustomerWindow();

        /// <summary>
        /// Получить Окно Депозитарного счета
        /// </summary>
        public DepositoryAccountWindow GetDepositoryAccountWindow() => new DepositoryAccountWindow();
    }
}
