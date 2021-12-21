﻿using System;

namespace ModelLibrary
{
    /// <summary>
    /// Интерейс адрес
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Дата регистрации
        /// </summary>
        DateTime? RegistrationDate { get; }

        /// <summary>
        /// Область или регион
        /// </summary>
        string Region { get; }

        /// <summary>
        /// Название города
        /// </summary>
        string City { get; }

        /// <summary>
        /// Район города
        /// </summary>
        string District { get; }

        /// <summary>
        /// Название улицы
        /// </summary>
        string Street { get; }

        /// <summary>
        /// Номер дома
        /// </summary>
        uint? HouseNumber { get; }

        /// <summary>
        /// Корпус дома
        /// </summary>
        string Housing { get; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        uint? ApartmentNumber { get; }

        /// <summary>
        /// Метод сравнения
        /// </summary>
        /// <param name="obj"> Сравниваемый объект </param>        
        bool Equals(IAddress obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;

            return RegistrationDate == obj.RegistrationDate &&
                   Region == obj.Region &&
                   City == obj.City &&
                   District == obj.District &&
                   Street == obj.Street &&
                   HouseNumber == obj.HouseNumber &&
                   Housing == obj.Housing &&
                   ApartmentNumber == obj.ApartmentNumber;
        }
    }
}
