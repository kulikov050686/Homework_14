using EnumLibrary;

namespace ModelLibrary
{
    /// <summary>
    /// Интерфейс депозитарный счёт
    /// </summary>
    public interface IDepositoryAccount : IBankAccount
    {
        /// <summary>
        /// Статус депозита
        /// </summary>
        public DepositStatus DepositStatus { get; set; }
    }
}
