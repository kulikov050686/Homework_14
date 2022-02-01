using System;
using System.Text.Json.Serialization;

namespace ModelLibrary
{
    /// <summary>
    /// Класс паспорт для парсинга файлов Json
    /// </summary>
    public class JsonPassport
    {
        /// <summary>
        /// Номер
        /// </summary>
        [JsonPropertyName("Number")]
        public uint? Number { get; set; }

        /// <summary>
        /// Серия
        /// </summary>
        [JsonPropertyName("Series")]
        public uint? Series { get; set; }

        /// <summary>
        /// Место выдачи
        /// </summary>
        [JsonPropertyName("PlaceOfIssue")]
        public string PlaceOfIssue { get; set; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        [JsonPropertyName("DateOfIssue")]
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        [JsonPropertyName("DivisionCode")]
        public DivisionCode DivisionCode { get; set; }

        /// <summary>
        /// Владелец
        /// </summary>
        [JsonPropertyName("Holder")]
        public JsonPerson Holder { get; set; }
    }
}
