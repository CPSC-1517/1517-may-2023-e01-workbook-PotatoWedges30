using FluentAssertions;
using OOPsReview;

namespace TDDUintTestDemo
{
    public class Person_Should
    {
        // Attribute title
        // [Fact] which does one test and is usually setup and coded within the test
        // [Theory] which allows for multiple test data stream applied to the same test

        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name()
        {
            //Arrange (Setup)
            string firstName = "Fardosa";
            string lastName = "Kito";

            //Act (execution) (sut : subject under test)
            Person sut = new Person(firstName, lastName);

            //Assert (Testing of the action)
            sut.FirstName.Should().Be(firstName);
            sut.LastName.Should().Be(lastName);
        }
    }
}