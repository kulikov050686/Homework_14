using EnumLibrary;
using ModelLibrary;
using ServiceLibrary;
using System;

namespace DialogLibrary
{
    /// <summary>
    /// Класс сервиса диалоговых окон по работе с клиентом банка
    /// </summary>
    public class BankCustomerDialog
    {
        #region Закрытые поля

        private EntityCreator _entityCreator;
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

        public BankCustomerDialog(EntityCreator entityCreator)
        {
            _entityCreator = entityCreator;
        }

        #region Закрытые методы

        /// <summary>
        /// Создать клиента банка
        /// </summary>        
        /// <param name="clientStatus"> Статус клиента </param>
        private IBankCustomer CreateBankCustomer(Status clientStatus)
        {
            if (_dialog is null)
                throw new ArgumentNullException(nameof(_dialog));

            IAddress residenceAddress = null;
            IAddress registrationAddress = null;
            IPerson person = null;
            IDivisionCode divisionCode = null;
            IPassport passport = null;

            residenceAddress = _entityCreator.CreateAddress(_dialog.RegistrationDatePlaceOfResidence,
                                                            _dialog.RegionPlaceOfResidence,
                                                            _dialog.CityPlaceOfResidence,
                                                            _dialog.StreetPlaceOfResidence,
                                                            _dialog.HouseNumberPlaceOfResidence,
                                                            _dialog.ApartmentNumberPlaceOfResidence,
                                                            _dialog.HousingPlaceOfResidence,
                                                            _dialog.DistrictPlaceOfResidence);

            try
            {
                registrationAddress = _entityCreator.CreateAddress(_dialog.RegistrationDateRegistration,
                                                                   _dialog.RegionRegistration,
                                                                   _dialog.CityRegistration,
                                                                   _dialog.StreetRegistration,
                                                                   _dialog.HouseNumberRegistration,
                                                                   _dialog.ApartmentNumberRegistration,
                                                                   _dialog.HousingRegistration,
                                                                   _dialog.DistrictRegistration);
            }
            catch (Exception)
            {}

            person = _entityCreator.CreatePerson(_dialog.SurnameBankCustomer,
                                                 _dialog.NameBankCustomer,
                                                 _dialog.PatronymicBankCustomer,
                                                 _dialog.GenderBankCustomer,
                                                 _dialog.BirthdayBankCustomer,
                                                 _dialog.PlaceOfBirthBankCustomer,
                                                 residenceAddress,
                                                 registrationAddress);

            divisionCode = _entityCreator.CreateDivisionCode(_dialog.DivisionCodeLeftPassport,
                                                             _dialog.DivisionCodeRightPassport);

            passport = _entityCreator.CreatePassport(_dialog.SeriesPassport,
                                                     _dialog.NumberPassport,
                                                     _dialog.PlaceOfIssuePassport,
                                                     _dialog.DateOfIssuePassport,
                                                     divisionCode,
                                                     person);

            return _entityCreator.CreateBankCustomer(0,
                                                     passport,
                                                     clientStatus,
                                                     _dialog.Reliability,
                                                     _dialog.PhoneNumber,
                                                     _dialog.Email);
        }

        /// <summary>
        /// Заполнение полей окна
        /// </summary>        
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

        #endregion
    }
}
