using rest_api.Model;
using System.Collections.Generic;

namespace rest_api.Business
{
    public interface IPersonBusiness
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
