using rest_api.Data.VO;
using rest_api.Hypermedia.Utils;
using System.Collections.Generic;

namespace rest_api.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        PagedSearchVO<BookVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
