using System;

namespace ModelLibrary
{
    /// <summary>
    /// Класс место жительства
    /// </summary>
    public class Address : IAddress
    {
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime? RegistrationDate { get; }

        /// <summary>
        /// Область или регион
        /// </summary>
        public string Region { get; }

        /// <summary>
        /// Название города
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Район города
        /// </summary>
        public string District { get; }

        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street { get; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public uint? HouseNumber { get; }
        
        /// <summary>
        /// Корпус дома
        /// </summary>
        public string Housing { get; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public uint? ApartmentNumber { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="registrationDate"> Дата регистрации </param>
        /// <param name="region"> Регион или Область </param>
        /// <param name="city"> Город </param>
        /// <param name="street"> Улица </param>
        /// <param name="houseNumber"> Дом </param>
        /// <param name="apartmentNumber"> Номер квартиры </param>
        /// <param name="housing"> Корпус дома </param>
        /// <param name="district"> Район города </param>
        public Address(DateTime? registrationDate,
                       string region,
                       string city,
                       string street,
                       uint? houseNumber,
                       uint? apartmentNumber = null,
                       string housing = null,
                       string district = null)
        {
            if (registrationDate is null)
                throw new ArgumentException("Дата регистрации не может быть null!!!");
            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentException("Регион или область не может быть пустым!!!");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Город не может быть пустым!!!");
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Улица не может быть пустой!!!");
            if (houseNumber == 0 || houseNumber is null)
                throw new ArgumentException("Номер дома не верен!!!");

            RegistrationDate = registrationDate;
            Region = region;
            City = city;
            Street = street;
            HouseNumber = houseNumber;

            ApartmentNumber = apartmentNumber;
            Housing = housing;
            District = district;
        }
    }
}
