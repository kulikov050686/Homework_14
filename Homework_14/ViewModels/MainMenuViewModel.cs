using BaseClassesLibrary;
using CommandLibrary;
using FileIOLibrary;
using Homework_14.Services;
using System.Windows.Input;

namespace Homework_14.ViewModels
{
    /// <summary>
    /// Модель-Представление главного меню
    /// </summary>
    public class MainMenuViewModel : BaseViewModel
    {
        #region Закрытые поля

        private DepartmentJSONFileIOService _departmentJSONFileIOService;
        private ManagerLocatorService _managerLocatorService;

        #endregion

        public string PathToFile { get; set; }

        #region Комманда сохранить в файл

        private ICommand _saveFile = default;
        public ICommand SaveFile
        {
            get => _saveFile ??= new RelayCommand((obj) =>
            {

            });
        }

        #endregion

        #region Комманда открыть файл

        private ICommand _openFile = default;
        public ICommand OpenFile
        {
            get => _openFile ??= new RelayCommand((obj) =>
            {

            });
        }

        #endregion

        public MainMenuViewModel(DepartmentJSONFileIOService departmentJSONFileIOService,
                                 ManagerLocatorService managerLocatorService)
        {
            _departmentJSONFileIOService = departmentJSONFileIOService;
            _managerLocatorService = managerLocatorService;
        }
    }
}
