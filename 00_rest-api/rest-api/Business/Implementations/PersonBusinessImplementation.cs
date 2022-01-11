using rest_api.Data.Converter.Implementations;
using rest_api.Data.VO;
using rest_api.Hypermedia.Utils;
using rest_api.Model;
using rest_api.Repository;
using System.Collections.Generic;

namespace rest_api.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;
        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        
        public List<PersonVO> FindAll()
        {
            var peopleEntity = _repository.FindAll();

            return _converter.Parse(peopleEntity);
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            var peopleEntity = _repository.FindByName(firstName, lastName);

            return _converter.Parse(peopleEntity);
        }
        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            int currentPage = (page > 0) ? page : 1;
            int size = (pageSize < 1) ? 10 : pageSize;
            int offset = (currentPage - 1) * size;
            string sort = (!string.IsNullOrWhiteSpace(sortDirection) && (!sortDirection.Equals("desc"))) ? "asc" : "desc";

            string query = @"SELECT * FROM person p WHERE 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) query += $" AND p.first_name LIKE '%{name}%' ";
            query += $" ORDER BY p.first_name {sort} LIMIT {size} OFFSET {offset}";

            string countQuery = @"SELECT COUNT(*) FROM person p WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $" AND p.first_name LIKE '%{name}%'";

            List<Person> people = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(people),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
