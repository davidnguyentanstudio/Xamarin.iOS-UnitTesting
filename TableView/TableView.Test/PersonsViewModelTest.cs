
using System;
using System.Collections.Generic;
using NUnit.Framework;
using TableView.Models;
using TableView.ViewModels;

namespace TableView.Test
{
    [TestFixture]
    public class PersonsViewModelTest
    {
        [Test]
        public void TogglePersonDetail_InvoKeNullCallBack_NoException()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel();
            viewModel.TogglePersonDetail(person, null);
        }

        [Test]
        public void TogglePersonDetail_InvoKeCallBack_Success()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel();
            viewModel.TogglePersonDetail(person, (callbackPerson) =>
            {
                Assert.AreSame(person, callbackPerson);
            });
        }

        [Test]
        public void TogglePersonDetail_TurnPersonOnWithCallBack_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel(new List<Person> { person }, new List<Person>());
            viewModel.TogglePersonDetail(person, (callbackPerson) =>
            {
                Assert.AreSame(person, callbackPerson);
                Assert.True(viewModel.IsShowingDetailForPerson(callbackPerson));
            });
            Assert.True(viewModel.IsShowingDetailForPerson(person));
        }

        [Test]
        public void TogglePersonDetail_TurnPersonOnWithoutCallBack_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel(new List<Person> { person }, new List<Person>());
            viewModel.TogglePersonDetail(person, null);
            Assert.True(viewModel.IsShowingDetailForPerson(person));
        }

        [Test]
        public void TogglePersonDetail_TurnPersonOffWithCallBack_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel(new List<Person> { person }, new List<Person> { person });
            viewModel.TogglePersonDetail(person, (callbackPerson) =>
            {
                Assert.AreSame(person, callbackPerson);
                Assert.False(viewModel.IsShowingDetailForPerson(callbackPerson));
            });
            Assert.False(viewModel.IsShowingDetailForPerson(person));
        }

        [Test]
        public void TogglePersonDetail_TurnPersonOffWithoutCallBack_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var viewModel = new PersonsViewModel(new List<Person> { person }, new List<Person> { person });
            viewModel.TogglePersonDetail(person, null);
            Assert.False(viewModel.IsShowingDetailForPerson(person));
        }

        [Test]
        public void GetDetailForPerson_Result_Correct()
        {
            var person = new Person("David", "Nguyentan", new DateTime(1992, 08, 03), Gender.Male);
            var persons = new List<Person> { person };
            var emptyPersons = new List<Person>();
            var viewModel = new PersonsViewModel(persons, emptyPersons);
            Assert.AreEqual(viewModel.GetDetailForPerson(person), "Male: 25 year olds.");
        }
    }
}
