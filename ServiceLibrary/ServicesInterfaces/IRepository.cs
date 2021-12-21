using EnumLibrary;
using ModelLibrary;
using System.Collections.Generic;

namespace ServiceLibrary
{
    /// <summary>
    /// Обработчик событий репозитория
    /// </summary>
    /// <param name="sender"> Параметр события </param>
    /// <param name="args"> Действия в репозитории </param>
    public delegate void RepositoryEventHandler(object sender, RepositoryArgs args);

    /// <summary>
    /// Интерфейс репозиторий
    /// </summary>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Событие возникающее при действиях в репозитории
        /// </summary>
        event RepositoryEventHandler RepositoryEvent;

        /// <summary>
        /// Добавить сущность в репозиторий
        /// </summary>
        /// <param name="item"> Добавляемая сущность </param>
        void Add(T item);

        /// <summary>
        /// Удаление сущности из репозитория
        /// </summary>
        /// <param name="item"> Удаляемая сущность </param>
        bool Remove(T item);

        /// <summary>
        /// Обновление сущности в репозитории
        /// </summary>        
        /// <param name="item"> Обноляемая сущность </param>
        void Update(T item);

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор сущности </param>
        T Get(ulong id);

        /// <summary>
        /// Получить все сущности
        /// </summary>
        IList<T> GetAll();

        /// <summary>
        /// Задать список сущностей в репозитории
        /// </summary>
        /// <param name="items"> Список сущностей  </param>
        void SetAll(IList<T> items);
    }
}
