using EnumLibrary;
using System;

namespace ModelLibrary
{
    /// <summary>
    /// Интерфейс создатель сущностей
    /// </summary>
    public interface IEntityCreator
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
        IAddress CreateAddress(DateTime? registrationDate,
                               string region,
                               string city,
                               string street,
                               uint? houseNumber,
                               uint? apartmentNumber,
                               string housing,
                               string district);

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
        IPerson CreatePerson(string surname,
                             string name,
                             string patronymic,
                             Gender gender,
                             DateTime? birthday,
                             string placeOfBirth,
                             IAddress placeOfResidence,
                             IAddress placeOfRegistration);

        /// <summary>
        /// Создание паспорта
        /// </summary>
        /// <param name="series"> Серия </param>
        /// <param name="number"> Номер </param>
        /// <param name="placeOfIssue"> Место выдачи </param>
        /// <param name="dateOfIssue"> Дата выпуска </param>
        /// <param name="divisionCode"> Код подразделения </param>
        /// <param name="holder"> Владелец </param>
        IPassport CreatePassport(uint? series,
                                 uint? number,
                                 string placeOfIssue,
                                 DateTime? dateOfIssue,
                                 IDivisionCode divisionCode,
                                 IPerson holder);

        /// <summary>
        /// Создать Код подразделения
        /// </summary>
        /// <param name="left"> Левая чать кода </param>
        /// <param name="right"> Правая часть кода </param>        
        IDivisionCode CreateDivisionCode(uint? left, uint? right);

        
        /// <summary>
        /// Создать клиента банка
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="passport"> Паспорт </param>
        /// <param name="clientStatus"> Статус </param>
        /// <param name="reliability"> Надёжность </param>
        /// <param name="phoneNumber"> Номер телефон </param>
        /// <param name="email"> Электронная почта </param>
        IBankCustomer CreateBankCustomer(ulong id,
                                         IPassport passport,
                                         Status clientStatus,
                                         Reliability reliability,
                                         string phoneNumber,
                                         string email = null);

        /// <summary>
        /// Создать департамент банка
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Название </param>
        /// <param name="statusDepartment"> Статус </param>
        IBankDepartment CreateBankDepartment(ulong id,
                                             string name,
                                             Status statusDepartment);

        /// <summary>
        /// Создать депозитарный счёт
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="amount"> Сумма </param>
        /// <param name="interestRate"> Процентная ставка </param>
        /// <param name="depositStatus"> Статус депозита </param>
        IDepositoryAccount CreateDepositoryAccount(ulong id,
                                                   double? amount,
                                                   double? interestRate,
                                                   DepositStatus depositStatus);
    }
}
