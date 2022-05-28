using ModelLibrary;
using System.Collections.Generic;
using System;

namespace ServiceLibrary
{
    /// <summary>
    /// Менеджер отдела банка
    /// </summary>
    public class BankDepartmentManager
    {
        #region Закрытые поля

        private readonly BankDepartmentRepository _bankDepartmentRepository;

        #endregion

        /// <summary>
        /// Cписок всех департаментов
        /// </summary>
        public IList<IBankDepartment> Departments => _bankDepartmentRepository.GetAll();

        /// <summary>
        /// Получить департамент по имени
        /// </summary>
        /// <param name="name"> Имя департамента </param>
        public IBankDepartment Get(string name) => _bankDepartmentRepository.Get(name);

        /// <summary>
        /// Задать список департаментов
        /// </summary>
        /// <param name="items"> Список департаментов </param>
        public void SetAll(IEnumerable<IBankDepartment> items) => _bankDepartmentRepository.SetAll(items);

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="bankDepartmentRepository"> Хранилище департаментов банка </param>
        public BankDepartmentManager(BankDepartmentRepository bankDepartmentRepository)
        {
            if(bankDepartmentRepository is null)
                throw new ArgumentOutOfRangeException(nameof(bankDepartmentRepository), "Хранилище департаментов банка не может быть null!!!");

            _bankDepartmentRepository = bankDepartmentRepository;
        }
    }
}
