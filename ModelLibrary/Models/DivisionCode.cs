using System;
using System.Text.Json.Serialization;

namespace ModelLibrary
{
    /// <summary>
    /// Класс код подразделения
    /// </summary>
    public class DivisionCode : IDivisionCode
    {
        /// <summary>
        /// Левая часть кода подразделения
        /// </summary>
        [JsonPropertyName("Left")]
        public uint? Left { get; }

        /// <summary>
        /// Правая часть кода подразделения
        /// </summary>
        [JsonPropertyName("Right")]
        public uint? Right { get; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="left"> Левая часть кода </param>
        /// <param name="right"> Правая часть кода </param>
        public DivisionCode(uint? left, uint? right)
        {
            if (left == 0 || left is null)
                throw new ArgumentException("Невозможное значение!!!");
            Left = left;

            if (right == 0 || right is null)
                throw new ArgumentException("Невозможное значение!!!");
            Right = right;
        }        
    }
}
