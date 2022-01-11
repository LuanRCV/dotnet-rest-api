using rest_api.Data.Converter.Implementations;
using rest_api.Data.VO;
using rest_api.Hypermedia.Utils;
using rest_api.Model;
using rest_api.Repository;
using System.Collections.Generic;

namespace rest_api.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public PagedSearchVO<BookVO> FindWithPagedSearch(string author, string sortDirection, int pageSize, int page)
        {
            int currentPage = (page > 0) ? page : 1;
            int size = (pageSize < 1) ? 10 : pageSize;
            int offset = (currentPage - 1) * size;
            string sort = (!string.IsNullOrWhiteSpace(sortDirection) && (!sortDirection.Equals("desc"))) ? "asc" : "desc";

            string query = @"SELECT * FROM books b WHERE 1 = 1";
            if (!string.IsNullOrWhiteSpace(author)) query += $" AND b.author LIKE '%{author}%' ";
            query += $" ORDER BY b.author {sort} LIMIT {size} OFFSET {offset}";

            string countQuery = @"SELECT COUNT(*) FROM books b WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(author)) countQuery += $" AND b.author LIKE '%{author}%'";

            List<Book> books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
