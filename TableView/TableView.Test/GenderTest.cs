
using System;
using NUnit.Framework;
using TableView.Models;

namespace TableView.Test
{
    [TestFixture]
    public class GenderTest
    {
        [Test]
        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        [TestCase(Gender.Unspecific)]
        public void Extension_GenderToString_Correct(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    Assert.AreEqual(GenderExtension.ToString(gender), "Male");
                    break;
                case Gender.Female:
                    Assert.AreEqual(GenderExtension.ToString(gender), "Female");
                    break;
                default:
                    Assert.AreEqual(GenderExtension.ToString(gender), "Unspecific");
                    break;
            }
        }
    }
}
