using rest_api.Model;
using rest_api.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rest_api.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImplementation(MySQLContext context)
        {
           _context = context;
        }
        
        public List<Person> FindAll()
        {
            try
            {
                return _context.People.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person FindById(long id)
        {
            try
            {
                return _context.People.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        public Person Update(Person person)
        {
            try
            {
                var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

                if (result == null) throw new Exception("Person doesn't exists");

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

                if (result == null) throw new Exception("Person doesn't exists");

                _context.People.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
