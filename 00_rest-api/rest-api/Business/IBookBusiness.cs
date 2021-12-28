using rest_api.Model;
using System.Collections.Generic;

namespace rest_api.Business
{
    public interface IBookBusiness
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
