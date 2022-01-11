using rest_api.Model.Base;
using System.Collections.Generic;

namespace rest_api.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> FindAll();
        T FindById(long id);
        T Create(T item);
        T Update(T item);
        void Delete(long id);

        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
