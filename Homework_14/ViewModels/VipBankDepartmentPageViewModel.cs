﻿using EnumLibrary;
using Homework_14.Services;
using ServiceLibrary;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление страницы департамента с vip клиентами
    /// </summary>
    public class VipBankDepartmentPageViewModel : BaseBankDepartmentPageViewModel
    {
        #region Конструктор

        public VipBankDepartmentPageViewModel(ManagerLocatorService managerLocatorService,
                                              PageLocatorService pageLocatorService,
                                              PageNavigator pageNavigator,
                                              DialogLocatorService dialogLocatorService) : base(managerLocatorService,
                                                                                                pageLocatorService,
                                                                                                pageNavigator,
                                                                                                dialogLocatorService, 
                                                                                                BankDepartmentPage.VIP)
        {

        }

        #endregion
    }
}
