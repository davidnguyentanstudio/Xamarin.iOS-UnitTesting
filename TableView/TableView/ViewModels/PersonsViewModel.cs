using System;
using System.Collections.Generic;
using TableView.Abtractions;
using TableView.Models;

namespace TableView.ViewModels
{
    public class PersonsViewModel : IBaseViewModel
    {
        public PersonsViewModel()
        {
        }

        public PersonsViewModel(List<Person> persons, List<Person> detailedPersons)
        {
            this.persons = persons;
            this.detailedPersons = detailedPersons;
        }

        public void TogglePersonDetail(Person person, Action<Person> didTogglePersonDetail)
        {
            var matchedIndex = detailedPersons.IndexOf(person);
            var isShowingPersonDetail = matchedIndex != -1;
            if (isShowingPersonDetail)
            {
                detailedPersons.RemoveAt(matchedIndex);
            }
            else
            {
                detailedPersons.Add(person);
            }

            didTogglePersonDetail?.Invoke(person);
        }

        public string GetDetailForPerson(Person person)
        {
            return person.Gender.ToString() + ": " + person.Age.ToString() + " year olds.";
        }

        public bool IsShowingDetailForPerson(Person person)
        {
            return detailedPersons.Contains(person);
        }

#if UI_TESTING && UI_TESTING_MOCK
        private List<Person> persons = new List<Person> {
            new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male)
        };
#else
        private List<Person> persons = new List<Person>();
#endif
        public List<Person> Persons { get => persons; set => persons = value; }

        protected List<Person> detailedPersons = new List<Person>();
    }
}
