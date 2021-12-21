﻿using System;

namespace ModelLibrary
{
    /// <summary>
    /// Интерфейс паспорт
    /// </summary>
    public interface IPassport
    {
        /// <summary>
        /// Номер
        /// </summary>
        uint? Number { get; }

        /// <summary>
        /// Серия
        /// </summary>
        uint? Series { get; }

        /// <summary>
        /// Место выдачи
        /// </summary>
        string PlaceOfIssue { get; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        DateTime? DateOfIssue { get; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        IDivisionCode DivisionCode { get; }

        /// <summary>
        /// Владелец
        /// </summary>
        IPerson Holder { get; }

        /// <summary>
        /// Метод сравнения
        /// </summary>
        /// <param name="obj"> Сравниваемй объект </param>        
        bool Equals(IPassport obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;

            return Number == obj.Number &&
                   Series == obj.Series &&
                   PlaceOfIssue == obj.PlaceOfIssue &&
                   DateOfIssue == obj.DateOfIssue &&
                   DivisionCode.Equals(obj.DivisionCode) &&
                   Holder.Equals(obj.Holder);
        }
    }
}
