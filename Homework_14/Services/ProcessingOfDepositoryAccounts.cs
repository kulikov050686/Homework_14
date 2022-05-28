using EnumLibrary;
using ModelLibrary;
using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace Homework_14.Services
{
    /// <summary>
    /// Обработка депозитарных счетов
    /// </summary>
    public class ProcessingOfDepositoryAccounts
    {
        #region Закрытые поля

        private readonly DepositoryAccountManager _depositoryAccountManager;        
        private DispatcherTimer _timer;
        private byte _k = 1;

        #endregion

        /// <summary>
        /// Список всех депозитарных счетов
        /// </summary>
        public IList<IDepositoryAccount> DepositoryAccounts => _depositoryAccountManager.DepositoryAccounts;

        /// <summary>
        /// Начать расчёт по счетам
        /// </summary>
        public void StartCalculate()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 2);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        /// <summary>
        /// Остановить расчёт по счетам
        /// </summary>
        public void StopCalculate()
        {
            _timer.Stop();
            _timer.Tick -= TimerTick;
            _timer = null;
        }

        /// <summary>
        /// Конструктор
        /// </summary>        
        public ProcessingOfDepositoryAccounts(DepositoryAccountManager depositoryAccountsManager)
        {
            if(depositoryAccountsManager is null) 
                throw new ArgumentNullException(nameof(depositoryAccountsManager), "Менеджер депозитарных счетов не может быть null!!!");

            _depositoryAccountManager = depositoryAccountsManager;                        
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>        
        private void TimerTick(object sender, EventArgs e)
        {
            foreach (var item in DepositoryAccounts)
            {
                if(!item.Blocking)
                {
                    if ((item.DepositStatus == DepositStatus.WITHOUTCAPITALIZATION) && _k == 12)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 100.0)), 2, MidpointRounding.AwayFromZero);
                    }

                    if (item.DepositStatus == DepositStatus.WITHCAPITALIZATION)
                    {
                        item.Amount = Math.Round((double)(item.Amount * (1 + item.InterestRate / 1200.0)), 2, MidpointRounding.AwayFromZero);
                    }
                }                               
            }

            if (_k == 12)
            {
                _k = 1;
            }
            else
            {
                _k++;
            }
        }        
    }
}
