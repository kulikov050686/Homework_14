using EnumLibrary;
using Homework_14.Services;
using ServiceLibrary;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление страницы департамента юридических лиц
    /// </summary>
    public class JuridicalBankDepartmentPageViewModel : BaseBankDepartmentPageViewModel
    {
        #region Конструктор

        public JuridicalBankDepartmentPageViewModel(ManagerLocatorService managerLocatorService,
                                                    PageLocatorService pageLocatorService,
                                                    PageNavigator pageNavigator,
                                                    DialogLocatorService dialogLocatorService) : base(managerLocatorService,
                                                                                                      pageLocatorService,
                                                                                                      pageNavigator,
                                                                                                      dialogLocatorService,
                                                                                                      BankDepartmentPage.JURIDICAL)
        {

        }

        #endregion
    }
}
