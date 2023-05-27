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
        public void Create_an_Instance_Using_Default_Constructor()
        {
            //Arrange (Setup)
          

            //Act (execution) (sut : subject under test)
            Person sut = new Person();

            //Assert (Testing of the action)
            sut.FirstName.Should().BeNull();
            sut.LastName.Should().BeNull();
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_No_List_Of_Employment()
        {
            //Arrange (Setup)
            string firstName = "Fardosa";
            string lastName = "Kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

            //Act (execution) (sut : subject under test)
            Person sut = new Person(firstName, lastName, address, null);

            //Assert (Testing of the action)
            sut.FirstName.Should().Be(firstName);
            sut.LastName.Should().Be(lastName);
            sut.Address.ToString().Should().Be(expectedaddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }
    }
}