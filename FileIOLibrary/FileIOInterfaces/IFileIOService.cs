namespace FileIOLibrary
{
    /// <summary>
    /// Интерфейс сервиса загрузки и выгрузки данных из файла
    /// </summary>
    public interface IFileIOService<T>
    {
        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        /// <param name="data"> Сохраняемые данные </param>       
        void Save(string pathFile, T data);

        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        /// <param name="pathFile"> Путь к файлу </param>
        T Open(string pathFile);
    }
}
