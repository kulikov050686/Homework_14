using ModelLibrary;
using System.Linq;
using TestDataProject;

namespace ServiceLibrary
{
    /// <summary>
    /// Хранилище департаментов банка
    /// </summary>
    public class BankDepartmentRepository : RepositoryInMemory<IBankDepartment>
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankDepartmentRepository() : base(TestData.Departments) { }

        /// <summary>
        /// Поиск департамента по имени
        /// </summary>
        /// <param name="nameDepartment"> Имя департамента </param>
        public IBankDepartment Get(string nameDepartment) => GetAll().FirstOrDefault(d => d.Name == nameDepartment);
        
        /// <summary>
        /// Обновление данных департамента банка
        /// </summary>
        /// <param name="source"> Новые данные департамента </param>
        /// <param name="destination"> Обновляемый департамент </param>
        protected override void Update(IBankDepartment source, IBankDepartment destination)
        {
            destination.BankCustomers = source.BankCustomers;
            destination.Id = source.Id;
            destination.Name = source.Name;
        }
    }
}
