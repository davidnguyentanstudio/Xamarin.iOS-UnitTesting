
using System;
using NUnit.Framework;
using TableView.Models;

namespace TableView.Test
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void Constructor_Properties_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            Assert.AreEqual(person.FirstName, "David");
            Assert.AreEqual(person.LastName, "Nguyentan");
            Assert.AreEqual(person.Birthday, new DateTime(1992, 08, 03));
            Assert.AreEqual(person.Gender, Gender.Male);
        }

        [Test]
        public void Age_BirthDayOn03Aug1992_Correct()
        {
            var birthDay = new DateTime(1992, 08, 03);
            var person = new Person("David", "Nguyentan", birthDay, Gender.Male);
            Assert.AreEqual(person.Age, 25);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Age_BirthdayGreaterThanNow_ExceptionThrown()
        {
            var invalidBirthDay = DateTime.Now.AddYears(10);
            var person = new Person("David", "Nguyentan", invalidBirthDay, Gender.Male);
        }

        [Test]
        [TestCase("David", "Nguyentan")]
        [TestCase("Scarlett", "Johansson")]
        public void FullName_JoiningFirstAndLastName_Correct(string firstName, string lastName)
        {
            var person = new Person(firstName, lastName, new DateTime(1992, 08, 03), Gender.Unspecific);
            Assert.AreEqual(person.FullName, String.Format("{0} {1}", firstName, lastName));
        }
    }
}
