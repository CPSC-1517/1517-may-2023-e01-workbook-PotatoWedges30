using FluentAssertions;
using OOPsReview;

namespace TDDUintTestDemo
{
    public class Person_Should
    {

        #region Valid Data
        // Attribute title
        // [Fact] which does one test and is usually setup and coded within the test
        // [Theory] which allows for multiple test data stream applied to the same test

        [Fact]
        public void Create_an_Instance_Using_Default_Constructor()
        {
            //Arrange (Setup)
            string expectedfirstname = "unknown";
            string expectedlastname = "unknown";

     

            //Act (execution) (sut : subject under test)
            Person sut = new Person();

            //Assert (Testing of the action)

            //  sut.FirstName.Should().BeNull();
            //  sut.LastName.Should().BeNull();

            sut.FirstName.Should().Be(expectedfirstname);
            sut.LastName.Should().Be(expectedlastname);
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

        [Fact]
        public void Change_FirstName_To_New_Name()
        {
            //Arrange (Setup)
            string firstname = "fardosa";
            string lastname = "kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedfirstname = "bob";

            // Act
            me.FirstName = expectedfirstname;

            //Assert
            me.FirstName.Should().Be(expectedfirstname);
        }

        [Fact]
        public void Change_LastName_To_New_Name()
        {
            //Arrange (Setup)
            string firstname = "fardosa";
            string lastname = "kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedlastname = "smith";

            // Act
            me.LastName = expectedlastname;

            //Assert
            me.LastName.Should().Be(expectedlastname);
        }

        #endregion



        #region Invalid Data
          [Theory]
          [InlineData(null,"kito")]
          [InlineData("fardosa",null)]
          [InlineData("", "kito")]
          [InlineData("fardosa", "")]
          [InlineData("    ", "kito")]
          [InlineData("fardosa", "   ")]
          // [InlineData(null,null)]
          public void Create_an__Greedy_Instancen_With_No_Name_Throws_Expection(string firstname, string lastname)
          {
              //Arrange (Setup)
              
              Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
              string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";

              //Act (execution) (sut : subject under test)
              Action action = () => new Person(firstname, lastname, address, null);

              //Assert (Testing of the action)
              action.Should().Throw<ArgumentNullException>();

          }

        // changing the firstname via the FirstName property
        // validation: firstname is required.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Expection_When_Setting_FirstName_To_Missing_Data(string changename)
        {
            //Arrange (Setup)
            string firstname = "fardosa";
            string lastname = "kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);
          

            //Act (execution) (testing will the property capture an invalid name change)
            Action action = () => me.FirstName = changename;

            //Assert (Testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }


        // changing the lastname via the LastName property
        // validation: lastname is required.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]

        public void Throw_Expection_When_Setting_LastName_To_Missing_Data(string changename)
        {
            //Arrange (Setup)
            string firstname = "fardosa";
            string lastname = "kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);


            //Act (execution) (testing will the property capture an invalid name change)
            Action action = () => me.LastName = changename;

            //Assert (Testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }


        #endregion
    }
}