using EnumLibrary;
using ModelLibrary;
using System;

namespace ServiceLibrary
{
    /// <summary>
    /// Класс сервиса создателя сущностей
    /// </summary>
    public class EntityCreator : IEntityCreator
    {
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
        public IAddress CreateAddress(DateTime? registrationDate, 
                                      string region, 
                                      string city, 
                                      string street, 
                                      uint? houseNumber, 
                                      uint? apartmentNumber, 
                                      string housing, 
                                      string district)
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

        /// <summary>
        /// Создать клиента банка
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="passport"> Паспорт </param>
        /// <param name="clientStatus"> Статус </param>
        /// <param name="reliability"> Надёжность </param>
        /// <param name="phoneNumber"> Номер телефон </param>
        /// <param name="email"> Электронная почта </param>
        public IBankCustomer CreateBankCustomer(ulong id, 
                                                IPassport passport, 
                                                Status clientStatus, 
                                                Reliability reliability, 
                                                string phoneNumber, 
                                                string email = null)
        {
            return new BankCustomer(id, passport, clientStatus, reliability, phoneNumber, email);
        }

        /// <summary>
        /// Создать департамент банка
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Название </param>
        /// <param name="statusDepartment"> Статус </param>
        public IBankDepartment CreateBankDepartment(ulong id, string name, Status statusDepartment)
        {
            return new BankDepartment(id, name, statusDepartment);
        }
        
        /// <summary>
        /// Создать депозитарный счёт
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="amount"> Сумма </param>
        /// <param name="interestRate"> Процентная ставка </param>
        /// <param name="depositStatus"> Статус депозита </param>
        public IDepositoryAccount CreateDepositoryAccount(ulong id, 
                                                          double? amount, 
                                                          double? interestRate, 
                                                          DepositStatus depositStatus)
        {
            return new DepositoryAccount(id, amount, interestRate, depositStatus); 
        }

        /// <summary>
        /// Создать Код подразделения
        /// </summary>
        /// <param name="left"> Левая чать кода </param>
        /// <param name="right"> Правая часть кода </param>
        public IDivisionCode CreateDivisionCode(uint? left, uint? right)
        {
            return new DivisionCode(left, right);
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
        public IPassport CreatePassport(uint? series, 
                                        uint? number, 
                                        string placeOfIssue, 
                                        DateTime? dateOfIssue, 
                                        IDivisionCode divisionCode, 
                                        IPerson holder)
        {
            return new Passport(series, number, placeOfIssue, dateOfIssue, divisionCode, holder);
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
        public IPerson CreatePerson(string surname, 
                                    string name, 
                                    string patronymic, 
                                    Gender gender, 
                                    DateTime? birthday, 
                                    string placeOfBirth, 
                                    IAddress placeOfResidence, 
                                    IAddress placeOfRegistration)
        {
            return new Person(surname, name, patronymic, gender, birthday, placeOfBirth, placeOfResidence, placeOfRegistration);
        }
    }
}
