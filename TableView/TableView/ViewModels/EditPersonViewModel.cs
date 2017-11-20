using System;
using TableView.Abtractions;
using TableView.Models;

namespace TableView.ViewModels
{
    public class EditPersonViewModel : IEditPersonViewModel, IBaseViewModel
    {
        public EditPersonViewModel(Person person)
        {
            this.Person = person;
        }

        public Person Person { get; set; }

        public string SavePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
