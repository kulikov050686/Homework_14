namespace ModelLibrary
{
    /// <summary>
    /// Интрефейс элемент
    /// </summary>
    public interface IElement : IEntity
    {
        /// <summary>
        /// Блокировка
        /// </summary>
        bool Blocking { get; set; }
    }
}
