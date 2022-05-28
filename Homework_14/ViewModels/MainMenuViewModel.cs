using BaseClassesLibrary;
using CommandLibrary;
using FileIOLibrary;
using Homework_14.Services;
using ModelLibrary;
using System.Collections.Generic;
using System.Windows.Input;
using System;

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
        private IList<IBankDepartment> _bankDepartments;

        #endregion

        /// <summary>
        /// Путь до файла
        /// </summary>
        public string PathToFile { get; set; }

        #region Комманда сохранить в файл

        private ICommand _saveFile = default;
        public ICommand SaveFile
        {
            get => _saveFile ??= new RelayCommand((obj) =>
            {
                if (string.IsNullOrWhiteSpace(PathToFile)) return;

                _departmentJSONFileIOService.Save(PathToFile, _bankDepartments);
            },(obj) => _bankDepartments != null);
        }

        #endregion

        #region Комманда открыть файл

        private ICommand _openFile = default;
        public ICommand OpenFile
        {
            get => _openFile ??= new RelayCommand((obj) =>
            {
                if (string.IsNullOrWhiteSpace(PathToFile)) return;

                var tempBankDepartment = _departmentJSONFileIOService.Open(PathToFile);
                if (tempBankDepartment is null) return;

                _managerLocatorService.BankDepartmentManager.SetAll(tempBankDepartment);
            });
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>        
        public MainMenuViewModel(DepartmentJSONFileIOService departmentJSONFileIOService,
                                 ManagerLocatorService managerLocatorService)
        {
            if (departmentJSONFileIOService is null)
                throw new ArgumentNullException(nameof(departmentJSONFileIOService), "Cервис загрузки и выгрузки департаментов из файла json не может быть null!!!");
            if (managerLocatorService is null)
                throw new ArgumentNullException(nameof(managerLocatorService), "Локатор менеджеров не может быть null!!!");

            _departmentJSONFileIOService = departmentJSONFileIOService;
            _managerLocatorService = managerLocatorService;

            _bankDepartments = _managerLocatorService.BankDepartmentManager.Departments;
        }
    }
}
