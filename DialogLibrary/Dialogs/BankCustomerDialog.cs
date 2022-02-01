using EnumLibrary;
using ModelLibrary;
using System;

namespace DialogLibrary
{
    /// <summary>
    /// Класс сервиса диалоговых окон по работе с клиентом банка
    /// </summary>
    public class BankCustomerDialog
    {
        #region Закрытые поля

        private AddEditBankCustomerWindow _dialog;

        #endregion

        /// <summary>
        /// Создание нового клиента банка
        /// </summary>
        /// <param name="clientStatus"> Статус клиента банка </param>        
        public IBankCustomer Create(Status clientStatus)
        {
            _dialog = new AddEditBankCustomerWindow();
            _dialog.Title = "Добавить нового клиента";

            if (_dialog.ShowDialog() != true) return null;

            return CreateBankCustomer(clientStatus);
        }

        /// <summary>
        /// Редактировать данные клиента банка
        /// </summary>
        /// <param name="bankCustomer"> Клиент банка </param>        
        public IBankCustomer Edit(IBankCustomer bankCustomer)
        {
            if (bankCustomer is null)
                throw new ArgumentNullException("Клиент банка не может быть null!!!");

            _dialog = new AddEditBankCustomerWindow();
            _dialog.Title = "Редактировать данные клиента";

            FillInWindows(bankCustomer);

            if (_dialog.ShowDialog() != true) return null;

            var tempBankCustomer = CreateBankCustomer(bankCustomer.ClientStatus);
            if (tempBankCustomer is null) return null;

            tempBankCustomer.Id = bankCustomer.Id;
            tempBankCustomer.DepositoryAccounts = bankCustomer.DepositoryAccounts;

            return tempBankCustomer;
        }

        #region Закрытые методы

        /// <summary>
        /// Создать клиента банка
        /// </summary>
        /// <param name="dialog"> Окно диалога </param>
        /// <param name="clientStatus"> Статус клиента </param>
        private IBankCustomer CreateBankCustomer(Status clientStatus)
        {
            if (_dialog is null)
                throw new ArgumentNullException(nameof(_dialog));

            var residenceAddress = CreateAddress(_dialog.RegistrationDatePlaceOfResidence,
                                                 _dialog.RegionPlaceOfResidence,
                                                 _dialog.CityPlaceOfResidence,
                                                 _dialog.StreetPlaceOfResidence,
                                                 _dialog.HouseNumberPlaceOfResidence,
                                                 _dialog.ApartmentNumberPlaceOfResidence,
                                                 _dialog.HousingPlaceOfResidence,
                                                 _dialog.DistrictPlaceOfResidence);

            if (residenceAddress is null) return null;

            var registrationAddress = CreateAddress(_dialog.RegistrationDateRegistration,
                                                    _dialog.RegionRegistration,
                                                    _dialog.CityRegistration,
                                                    _dialog.StreetRegistration,
                                                    _dialog.HouseNumberRegistration,
                                                    _dialog.ApartmentNumberRegistration,
                                                    _dialog.HousingRegistration,
                                                    _dialog.DistrictRegistration);

            var persone = CreatePersone(_dialog.SurnameBankCustomer,
                                        _dialog.NameBankCustomer,
                                        _dialog.PatronymicBankCustomer,
                                        _dialog.GenderBankCustomer,
                                        _dialog.BirthdayBankCustomer,
                                        _dialog.PlaceOfBirthBankCustomer,
                                        residenceAddress,
                                        registrationAddress);

            if (persone is null) return null;

            var divisionCode = CreateDivisionCode(_dialog.DivisionCodeLeftPassport,
                                                  _dialog.DivisionCodeRightPassport);

            if (divisionCode is null) return null;

            var passport = CreatePassport(_dialog.SeriesPassport,
                                          _dialog.NumberPassport,
                                          _dialog.PlaceOfIssuePassport,
                                          _dialog.DateOfIssuePassport,
                                          divisionCode,
                                          persone);

            if (passport is null) return null;

            return new BankCustomer(0,
                                    passport,
                                    clientStatus,
                                    _dialog.Reliability,
                                    _dialog.PhoneNumber,
                                    _dialog.Email);
        }

        /// <summary>
        /// Заполнение полей окна
        /// </summary>
        /// <param name="dialog"> Окно диалога </param>
        /// <param name="bankCustomer"> Клиент банка </param>
        private void FillInWindows(IBankCustomer bankCustomer)
        {
            if (_dialog is null)
                throw new ArgumentNullException(nameof(_dialog));
            if (bankCustomer is null)
                throw new ArgumentNullException(nameof(bankCustomer));

            _dialog.PhoneNumber = bankCustomer.PhoneNumber;
            _dialog.Email = bankCustomer.Email;
            _dialog.Reliability = bankCustomer.Reliability;

            _dialog.NameBankCustomer = bankCustomer.Passport.Holder.Name;
            _dialog.SurnameBankCustomer = bankCustomer.Passport.Holder.Surname;
            _dialog.PatronymicBankCustomer = bankCustomer.Passport.Holder.Patronymic;
            _dialog.BirthdayBankCustomer = bankCustomer.Passport.Holder.Birthday;
            _dialog.GenderBankCustomer = bankCustomer.Passport.Holder.Gender;
            _dialog.PlaceOfBirthBankCustomer = bankCustomer.Passport.Holder.PlaceOfBirth;

            _dialog.SeriesPassport = bankCustomer.Passport.Series;
            _dialog.NumberPassport = bankCustomer.Passport.Number;
            _dialog.DivisionCodeLeftPassport = bankCustomer.Passport.DivisionCode.Left;
            _dialog.DivisionCodeRightPassport = bankCustomer.Passport.DivisionCode.Right;
            _dialog.DateOfIssuePassport = bankCustomer.Passport.DateOfIssue;
            _dialog.PlaceOfIssuePassport = bankCustomer.Passport.PlaceOfIssue;

            _dialog.RegionPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Region;
            _dialog.CityPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.City;
            _dialog.DistrictPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.District;
            _dialog.StreetPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Street;
            _dialog.HouseNumberPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.HouseNumber;
            _dialog.HousingPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.Housing;
            _dialog.ApartmentNumberPlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.ApartmentNumber;
            _dialog.RegistrationDatePlaceOfResidence = bankCustomer.Passport.Holder.PlaceOfResidence.RegistrationDate;

            if (bankCustomer.Passport.Holder.PlaceOfRegistration != null)
            {
                _dialog.RegionRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Region;
                _dialog.CityRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.City;
                _dialog.DistrictRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.District;
                _dialog.StreetRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Street;
                _dialog.HouseNumberRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.HouseNumber;
                _dialog.HousingRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.Housing;
                _dialog.ApartmentNumberRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.ApartmentNumber;
                _dialog.RegistrationDateRegistration = bankCustomer.Passport.Holder.PlaceOfRegistration.RegistrationDate;
            }
        }

        /// <summary>
        /// Создание адреса
        /// </summary>
        /// <param name="registrationDate"> Дата регистрации </param>
        /// <param name="region"> Регион или Область </param>
        /// <param name="city"> Город </param>
        /// <param name="street"> Улица </param>
        /// <param name="houseNumber"> Дом </param>
        /// <param name="apartmentNumber"> Номер квартиры </param>
        /// <param name="housing"> Корпус дома </param>
        /// <param name="district"> Район города </param>        
        private IAddress CreateAddress(DateTime? registrationDate,
                                       string region,
                                       string city,
                                       string street,
                                       uint? houseNumber,
                                       uint? apartmentNumber,
                                       string housing,
                                       string district)
        {
            try
            {
                return new Address(registrationDate,
                                   region,
                                   city,
                                   street,
                                   houseNumber,
                                   apartmentNumber,
                                   housing,
                                   district);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Создание гражданина
        /// </summary>
        /// <param name="surname"> Фамилия </param>
        /// <param name="name"> Имя </param>
        /// <param name="patronymic"> Отчество </param>
        /// <param name="gender"> Пол </param>
        /// <param name="birthday"> День рождения </param>
        /// <param name="placeOfBirth"> Место рождения </param>
        /// <param name="placeOfResidence"> Место жительства (прописка) </param>
        /// <param name="placeOfRegistration"> Место регистрации </param>
        private IPerson CreatePersone(string surname,
                                      string name,
                                      string patronymic,
                                      Gender gender,
                                      DateTime? birthday,
                                      string placeOfBirth,
                                      IAddress placeOfResidence,
                                      IAddress placeOfRegistration)
        {
            try
            {
                return new Person(surname,
                                  name,
                                  patronymic,
                                  gender,
                                  birthday,
                                  placeOfBirth,
                                  placeOfResidence,
                                  placeOfRegistration);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Создание паспорта
        /// </summary>
        /// <param name="series"> Серия </param>
        /// <param name="number"> Номер </param>
        /// <param name="placeOfIssue"> Место выдачи </param>
        /// <param name="dateOfIssue"> Дата выпуска </param>
        /// <param name="divisionCode"> Код подразделения </param>
        /// <param name="holder"> Владелец </param>
        private IPassport CreatePassport(uint? series,
                                         uint? number,
                                         string placeOfIssue,
                                         DateTime? dateOfIssue,
                                         IDivisionCode divisionCode,
                                         IPerson holder)
        {
            try
            {
                return new Passport(series,
                                    number,
                                    placeOfIssue,
                                    dateOfIssue,
                                    divisionCode,
                                    holder);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Создать Код подразделения
        /// </summary>
        /// <param name="left"> Левая чать кода </param>
        /// <param name="right"> Правая часть кода </param>        
        private IDivisionCode CreateDivisionCode(uint? left, uint? right)
        {
            try
            {
                return new DivisionCode(left, right);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
