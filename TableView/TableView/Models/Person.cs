using System;
namespace TableView.Models
{
    public class Person
    {
        public Person(string firstName,
                      string lastName,
                      DateTime birthday,
                      Gender gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthday = birthday;
            _gender = gender;
        }

        DateTime _birthday;
        public DateTime Birthday { get => _birthday; set => _birthday = value; }

        public int Age => CalculateAge();

        string _firstName;
        public string FirstName { get => _firstName; set => _firstName = value; }

        string _lastName;
        public string LastName { get => _lastName; set => _lastName = value; }

        public string FullName => GetFullName();

        Gender _gender;
        public Gender Gender { get => _gender; set => _gender = value; }

        protected string GetFullName()
        {
            var fullName = FirstName + " " + LastName;
            return fullName;
        }

        protected int CalculateAge()
        {
            var age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear) {
                age -= 1;
            }
            return age;
        }
    }
}
