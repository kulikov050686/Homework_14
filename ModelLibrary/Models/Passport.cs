using System;

namespace ModelLibrary
{
    /// <summary>
    /// Класс паспорт
    /// </summary>
    public class Passport : IPassport
    {
        /// <summary>
        /// Номер
        /// </summary>
        public uint? Number { get; }
        
        /// <summary>
        /// Серия
        /// </summary>
        public uint? Series { get; }

        /// <summary>
        /// Место выдачи
        /// </summary>
        public string PlaceOfIssue { get; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime? DateOfIssue { get; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        public IDivisionCode DivisionCode { get; }

        /// <summary>
        /// Владелец
        /// </summary>
        public IPerson Holder { get; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="series"> Серия </param>
        /// <param name="number"> Номер </param>
        /// <param name="placeOfIssue"> Место выдачи </param>
        /// <param name="dateOfIssue"> Дата выпуска </param>
        /// <param name="divisionCode"> Код подразделения </param>
        /// <param name="holder"> Владелец </param>
        public Passport(uint? series,
                        uint? number,
                        string placeOfIssue,
                        DateTime? dateOfIssue,
                        IDivisionCode divisionCode,
                        IPerson holder)
        {
            if(holder is null)
                throw new ArgumentException("Владелец не может быть null!!!");
            if (divisionCode is null)
                throw new ArgumentException("Код подразделения не может быть null!!!");
            if(string.IsNullOrWhiteSpace(placeOfIssue))
                throw new ArgumentException("Место выдачи не может быть null!!!");
            if(series == 0 || series is null)
                throw new ArgumentException("Серия не может быть null!!!");
            if (number == 0 || number is null)
                throw new ArgumentException("Номер не может быть null!!!");

            Series = series;
            Number = number;
            PlaceOfIssue = placeOfIssue;
            DateOfIssue = dateOfIssue;
            DivisionCode = divisionCode;
            Holder = holder;
        }
    }
}
