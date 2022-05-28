using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ModelLibrary;
using System;

namespace FileIOLibrary
{
    /// <summary>
    /// Класс сервиса загрузки и выгрузки департаментов из файла
    /// </summary>    
    public class DepartmentJSONFileIOService : IFileIOService<IList<IBankDepartment>>
    {
        #region Закрытые поля

        EntityCreator _entityCreator;

        #endregion

        /// <summary>
        /// Сохранить данные в файл формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>        
        public void Save(string pathFile, IList<IBankDepartment> data)
        {
            using (StreamWriter writer = new StreamWriter(pathFile, false))
            {
                writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
            }
        }

        /// <summary>
        /// Загрузить данные из файла формата JSON
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        public IList<IBankDepartment> Open(string pathFile)
        {
            using (var reader = File.OpenText(pathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                var dataTemp = JsonConvert.DeserializeObject<ObservableCollection<JsonDepartment>>(fileTaxt);
                var departments = ConverterDepartments(dataTemp);

                int i = 0;

                foreach (var item in dataTemp)
                {
                    if (item.BankCustomers != null && item.BankCustomers.Count != 0)
                    {
                        departments[i].BankCustomers = ConverterBankCustomers(item.BankCustomers);

                        int k = 0;
                        foreach (var p in item.BankCustomers)
                        {
                            if (p.DepositoryAccounts != null && p.DepositoryAccounts.Count != 0)
                            {
                                departments[i].BankCustomers[k].DepositoryAccounts = ConverterDepositoryAccount(p.DepositoryAccounts);
                            }
                            k++;
                        }
                    }
                    i++;
                }

                return departments;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="entityCreator"> Создатель сущностей </param>
        public DepartmentJSONFileIOService(EntityCreator entityCreator)
        {
            if(entityCreator is null) 
                throw new ArgumentNullException(nameof(entityCreator), "Создатель сущностей не может быть null!!!");

            _entityCreator = entityCreator;
        }

        #region Закрытые методы

        /// <summary>
        /// Конвертер листа департаментов
        /// </summary>
        /// <param name="data"> Лист департаментов </param>
        private IList<IBankDepartment> ConverterDepartments(ObservableCollection<JsonDepartment> data)
        {
            if (data is null) return null;

            ObservableCollection<IBankDepartment> departments = new ObservableCollection<IBankDepartment>();
            foreach (var item in data)
            {
                IBankDepartment department = _entityCreator.CreateBankDepartment(item.Id, item.Name, item.StatusDepartment);
                departments.Add(department);
            }

            return departments;
        }

        /// <summary>
        /// Конвертер листа клиентов банка
        /// </summary>
        /// <param name="data"> Лист клиентов банка </param>        
        private IList<IBankCustomer> ConverterBankCustomers(ObservableCollection<JsonBankCustomer> data)
        {
            if (data is null) return null;

            ObservableCollection<IBankCustomer> bankCustomers = new ObservableCollection<IBankCustomer>();
            foreach (var item in data)
            {
                IAddress placeOfResidence = _entityCreator.CreateAddress(item.Passport.Holder.PlaceOfResidence.RegistrationDate,
                                                                         item.Passport.Holder.PlaceOfResidence.Region,
                                                                         item.Passport.Holder.PlaceOfResidence.City,
                                                                         item.Passport.Holder.PlaceOfResidence.Street,
                                                                         item.Passport.Holder.PlaceOfResidence.HouseNumber,
                                                                         item.Passport.Holder.PlaceOfResidence.ApartmentNumber,
                                                                         item.Passport.Holder.PlaceOfResidence.Housing,
                                                                         item.Passport.Holder.PlaceOfResidence.District);

                IAddress placeOfRegistration = null;
                if (item.Passport.Holder.PlaceOfRegistration != null)
                {
                    placeOfRegistration = _entityCreator.CreateAddress(item.Passport.Holder.PlaceOfRegistration.RegistrationDate,
                                                                       item.Passport.Holder.PlaceOfRegistration.Region,
                                                                       item.Passport.Holder.PlaceOfRegistration.City,
                                                                       item.Passport.Holder.PlaceOfRegistration.Street,
                                                                       item.Passport.Holder.PlaceOfRegistration.HouseNumber,
                                                                       item.Passport.Holder.PlaceOfRegistration.ApartmentNumber,
                                                                       item.Passport.Holder.PlaceOfRegistration.Housing,
                                                                       item.Passport.Holder.PlaceOfRegistration.District);
                }

                IPerson person = _entityCreator.CreatePerson(item.Passport.Holder.Surname,
                                                             item.Passport.Holder.Name,
                                                             item.Passport.Holder.Patronymic,
                                                             item.Passport.Holder.Gender,
                                                             item.Passport.Holder.Birthday,
                                                             item.Passport.Holder.PlaceOfBirth,
                                                             placeOfResidence,
                                                             placeOfRegistration);

                IPassport passport = _entityCreator.CreatePassport(item.Passport.Series,
                                                                   item.Passport.Number,
                                                                   item.Passport.PlaceOfIssue,
                                                                   item.Passport.DateOfIssue,
                                                                   item.Passport.DivisionCode,
                                                                   person);

                IBankCustomer bankCustomer = _entityCreator.CreateBankCustomer(item.Id,
                                                                               passport,
                                                                               item.ClientStatus,
                                                                               item.Reliability,
                                                                               item.PhoneNumber,
                                                                               item.Email);

                bankCustomers.Add(bankCustomer);
            }

            return bankCustomers;
        }

        /// <summary>
        /// Конвертер листа депозитарных счетов
        /// </summary>
        /// <param name="data"> Лист депозитарных счетов </param>
        private IList<IDepositoryAccount> ConverterDepositoryAccount(ObservableCollection<DepositoryAccount> data)
        {
            if (data is null) return null;

            ObservableCollection<IDepositoryAccount> depositoryAccounts = new ObservableCollection<IDepositoryAccount>();
            foreach (var item in data)
            {
                depositoryAccounts.Add(item);
            }

            return depositoryAccounts;
        }

        #endregion
    }
}
