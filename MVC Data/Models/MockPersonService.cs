using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Data.Models
{
    public class MockPersonService : IPersonService
    {
        PersonView pv = new PersonView();

        private int idCount = 1;

        public MockPersonService()
        {
            pv.persons.Add(new Person() { Id = 0, Name = "Nisse Person", Phone = 0731234567, City = "Växjö" });
            //pv.persons.Add(new Person() { Id = 1, Name = "Nisse Person", Phone = 0731234567, City = "Växjö" });
            //pv.persons.Add(new Person() { Id = 2, Name = "Kalle Nilsson", Phone = 0731234567, City = "Växjö" });
            //pv.persons.Add(new Person() { Id = 3, Name = "Kalle Karlsson", Phone = 0731234567, City = "Kalmar" });
            //pv.persons.Add(new Person() { Id = 4, Name = "Pelle Nilsson", Phone = 0731234567, City = "Kalmar" });
            //pv.persons.Add(new Person() { Id = 5, Name = "Pelle Person", Phone = 0731234567, City = "Lund" });
        }

        public List<Person> AllPersons()
        {
            return pv.persons;
        }

        public Person CreatePerson(string name, int phone, string city)
        {
            Person person = new Person() { Id = idCount, Name = name, Phone = phone, City = city };
            idCount++;
            pv.persons.Add(person);

            return person;
        }

        public bool DeletePerson(int id)
        {
            bool wasRemoved = false;

            foreach (Person item in pv.persons)
            {
                if (item.Id == id)
                {
                    pv.persons.Remove(item);

                    wasRemoved = true;
                    break;
                }
            }

            return wasRemoved;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in pv.persons)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        // Not in use yet
        public bool UpdatePerson(Person person)
        {
            bool wasUpdated = false;

            foreach (Person orginal in pv.persons)
            {
                if (orginal.Id == person.Id)
                {
                    orginal.Name = person.Name;
                    orginal.Phone = person.Phone;
                    orginal.City = person.City;

                    wasUpdated = true;
                    break;
                }
            }

            return wasUpdated;
        }

        public List<Person> FilterPersonCity(string searchString)
        {
            var people = pv.persons.Where(s => s.Name.Contains(searchString) || s.City.Contains(searchString)).ToList();

            return (people);
        }

    }
}
