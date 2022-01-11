using rest_api.Model;
using System.Collections.Generic;

namespace rest_api.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
