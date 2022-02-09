using EnumLibrary;
using Homework_14.Services;
using ServiceLibrary;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление страницы департамента с обычными клиентами
    /// </summary>
    public class UsualBankDepartmentPageViewModel : BaseBankDepartmentPageViewModel
    {
        #region Конструктор

        public UsualBankDepartmentPageViewModel(ManagerLocatorService managerLocatorService,
                                                PageLocatorService pageLocatorService,
                                                PageNavigator pageNavigator,
                                                DialogLocatorService dialogLocatorService) : base(managerLocatorService,
                                                                                                  pageLocatorService,
                                                                                                  pageNavigator,
                                                                                                  dialogLocatorService,
                                                                                                  BankDepartmentPage.USUAL)
        {

        }

        #endregion
    }
}
