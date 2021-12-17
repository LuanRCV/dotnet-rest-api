using rest_api.Model;
using System;
using System.Collections.Generic;

namespace rest_api.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }


        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Luan",
                LastName = "Vieira",
                Address = "Petrópolis - Rio de Janeiro - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Luan " + i,
                LastName = "Vieira " + i,
                Address = "Petrópolis - Rio de Janeiro - Brasil " + i,
                Gender = "Male " + i
            };
        }
    }
}
