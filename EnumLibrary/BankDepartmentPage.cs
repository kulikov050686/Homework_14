namespace EnumLibrary
{
    /// <summary>
    /// Страница банковского департамента
    /// </summary>
    public enum BankDepartmentPage : byte
    {
        /// <summary>
        /// Департамент с обычными клиентами
        /// </summary>
        USUAL = 1,

        /// <summary>
        /// Департамент с Vip клиентами
        /// </summary>
        VIP = 2,

        /// <summary>
        /// Департамент с юридическими лицами
        /// </summary>
        JURIDICAL = 3
    }
}
