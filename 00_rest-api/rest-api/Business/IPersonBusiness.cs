using rest_api.Data.VO;
using rest_api.Hypermedia.Utils;
using System.Collections.Generic;

namespace rest_api.Business
{
    public interface IPersonBusiness
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
