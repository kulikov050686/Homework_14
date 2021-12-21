using EnumLibrary;
using System.Collections.Generic;

namespace ModelLibrary
{
    /// <summary>
    /// Интерфейс Клиет Банка
    /// </summary>
    public interface IBankCustomer : IElement
    {
        /// <summary>
        /// Паспорт
        /// </summary>
        IPassport Passport { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        Status ClientStatus { get; set; }

        /// <summary>
        /// Надёжность
        /// </summary>
        Reliability Reliability { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Лист депозитарных счетов
        /// </summary>
        IList<IDepositoryAccount> DepositoryAccounts { get; set; }

        /// <summary>
        /// Количество депозитарных счетов
        /// </summary>
        int DepositoryAccountCount { get; }

        /// <summary>
        /// Метод сравнения
        /// </summary>
        /// <param name="obj"> Сравниваемый объект </param>
        bool Equals(IBankCustomer obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;

            bool key = true;

            if((DepositoryAccounts == null && obj.DepositoryAccounts != null) ||
               (DepositoryAccounts != null && obj.DepositoryAccounts == null))
            {
                key = false;
            }

            if((DepositoryAccounts != null) && (obj.DepositoryAccounts != null) && key)
            {
                if(DepositoryAccounts.Count == obj.DepositoryAccounts.Count)
                {
                    for(int i = 0; i < DepositoryAccounts.Count && key; i++)
                    {
                        key = key && DepositoryAccounts[i].Equals(obj.DepositoryAccounts[i]);
                    }
                }
                else
                {
                    key = false;
                }
            }

            if (!key) return false;

            return (Id == obj.Id) &&
                   Passport.Equals(obj.Passport) &&
                   ClientStatus == obj.ClientStatus &&
                   Reliability == obj.Reliability &&
                   PhoneNumber == obj.PhoneNumber &&
                   Email == obj.Email;
        }
    }
}
