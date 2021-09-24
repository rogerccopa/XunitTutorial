using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Roger", LastName = "Ccopa" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Roger", " ", "LastName")]
        [InlineData(" ", "Ccopa", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstname, string lastname, string badParamName)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstname, LastName = lastname };
            List<PersonModel> people = new List<PersonModel>();

            // Assert that ArgumentException occurs with parameter badParamName
            Assert.Throws<ArgumentException>(badParamName, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void SerializePeopleToAList_ShouldAdd2People()
        {
            List<PersonModel> people = new List<PersonModel>()
            {
                new PersonModel{ FirstName="Roger", LastName="Ccopa"},
                new PersonModel{ FirstName="Sonia", LastName="Quispe"}
            };

            List<string> result = DataAccess.SerializePeopleToAList(people);

            Assert.True(result.Count == 2);
            Assert.True(result[1] == "Sonia,Quispe");
        }
    }
}
