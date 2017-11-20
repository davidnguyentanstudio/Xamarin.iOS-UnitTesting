using System;
using TableView.Models;

namespace TableView.Abtractions
{
    public interface IEditPersonViewModel
    {
        Person Person { get; set; }
        string SavePerson(Person person);
    }
}
