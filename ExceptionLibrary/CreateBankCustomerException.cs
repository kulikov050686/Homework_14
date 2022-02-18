using System;

namespace ExceptionLibrary
{
    /// <summary>
    /// Исключения происходящие при создании клиента банка
    /// </summary>
    public class CreateBankCustomerException : Exception
    {
        public CreateBankCustomerException(string msg) : base(msg) {}
    }
}
