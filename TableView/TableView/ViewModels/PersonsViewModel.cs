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

        private List<Person> persons;
        private List<Person> persons = new List<Person>();
        public List<Person> Persons { get => persons; set => persons = value; }

        protected List<Person> detailedPersons = new List<Person>();
    }
}
