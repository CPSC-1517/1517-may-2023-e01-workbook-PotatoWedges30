using FluentAssertions;
using OOPsReview;
using System.Net;

namespace TDDUintTestDemo
{
    public class Person_Should
    {
        public Person Make_SUT_Instance()
        {
            string firstname = "Fardosa";
            string lastname = "Kito";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);
            return me;
        }

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
            Person me = Make_SUT_Instance();
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
           

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

            Person me = Make_SUT_Instance();
            string expectedlastname = "smith";

            // Act
            me.LastName = expectedlastname;

            //Assert
            me.LastName.Should().Be(expectedlastname);
        }

        [Fact]
        public void Change_Both_First_And_Last_Name_To_New_Name()
        {
            //Arrange (Setup)
            Person me = Make_SUT_Instance();

            
            string expectedfirstname = "pet";
            string expectedlastname = "smith";

            // Act
            me.ChangeName(expectedfirstname, expectedlastname);

            //Assert
            me.FirstName.Should().Be(expectedfirstname);
            me.LastName.Should().Be(expectedlastname);
        }


        [Fact]
        public void Return_The_Full_Name_Of_Prsone()
        {
            //Arrange (Setup)
            Person me = Make_SUT_Instance();

          
            string expectedfullname = "Kito, Fardosa";

            //string expectedfirstname = "pet";
            //string expectedlastname = "smith";
            //string expectedfullname = firstname + " " + lastname;

            // Act
            //me.ChangeName(expectedfirstname, expectedlastname);
            string actual = me.FullName;
            ////Assert
            //me.FirstName.Should().Be(expectedfirstname);
            //me.LastName.Should().Be(expectedlastname);
           // me.FullName.Should().Be(expectedfullname);
            actual.Should().Be(expectedfullname);
        }


        [Fact]
        public void Return_The_Number_Of_Employment_Instances_For_New_Person()
        {
            //Arrange (Setup)
            //no employment instances
            Person sut = Make_SUT_Instance();




            //string expectedfirstname = "pet";
            //string expectedlastname = "smith";
            //string expectedfullname = firstname + " " + lastname;

            // Act
            //me.ChangeName(expectedfirstname, expectedlastname);
            int actual = sut.NumberOfEmployments;

            ////Assert
            //me.FirstName.Should().Be(expectedfirstname);
            //me.LastName.Should().Be(expectedlastname);
            // me.FullName.Should().Be(expectedfullname);
            actual.Should().Be(0);
        }

        [Fact]
        public void Add_First_Employment_Instance()
        {
            //Arrange (Setup)
            //no employment instances
            Person sut = Make_SUT_Instance();
            int expectednumberofemployment = 1;

            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));

            //Act  (execution)
            sut.AddEmployment(employment);


            //Assert (testing of the action)
            sut.NumberOfEmployments.Should().Be(expectednumberofemployment);
            sut.EmploymentPositions[0].ToString().Should().Be(employment.ToString());

        }

        [Fact]
        public void Add_Another_Employment_Instance()
        {
            //Arrange (Setup)
            //no employment instances
            string firstname = "fardosa";
            string lastname = "kito";
             Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");

            List<Employment> employments = new List<Employment>();
            Employment emp1 = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2016, 03, 10));
            Employment emp2 = new Employment("TDD Lead", SupervisoryLevel.TeamLeader, new DateTime(2020, 03, 10));
            employments.Add(emp1);
            employments.Add(emp2);
            Person sut = new Person(firstname, lastname, address, employments);

            Employment employment = new Employment("TDD Supervisor", SupervisoryLevel.Supervisor, new DateTime(2023, 03, 10));

            int expectednumberofemployment = 3;
            List<Employment> expectedemployments = new List<Employment>()
            {
                emp1,
                emp2,
                employment
            };

            //Act  (execution)
            sut.AddEmployment(employment);


            //Assert (testing of the action)
            sut.NumberOfEmployments.Should().Be(expectednumberofemployment);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedemployments);
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
            Person me = Make_SUT_Instance();


            //Act (execution) (testing will the property capture an invalid name change)
            // Action is a special unit testing data type that records the results of the executed statement into variable action
            // assignment statement =
            // () =>  for the following code execution
            // me.FirstName = changename;  is the actual action that is being tested as if it were really in a program.

            Action action = () => me.FirstName = changename;

            //Assert (Testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*first name is required*"); ;
           
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
            Person me = Make_SUT_Instance();


            //Act (execution) (testing will the property capture an invalid name change)
            // Action is a special unit testing data type that records the results of the executed statement into variable action
            // assignment statement =
            // () =>  for the following code execution
            // me.LastName = changename;  is the actual action that is being tested as if it were really in a program.
            Action action = () => me.LastName = changename;

            //Assert (Testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*last name is required*");
        }

        [Theory]
        [InlineData(null, "kito")]
        [InlineData("fardosa", null)]
        [InlineData("", "kito")]
        [InlineData("fardosa", "")]
        [InlineData("    ", "kito")]
        [InlineData("fardosa", "    ")]
        public void Throw_Expection_When_Changing_First_And_Last_Name(string changefirstname, string changelastname)
        {
            //Arrange (Setup)
            Person me = Make_SUT_Instance();


            // Act  (execution) (sut subject under test)
            Action action = () =>  me.ChangeName(changefirstname,changelastname);

            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");
        }

        [Fact]
        public void Throw_Expection_When_Adding_Null_Employment_Instance()
        {
            //Arrange (setup)
            //no employment instances
            Person sut = Make_SUT_Instance();


            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));

            //Act (execution)
            Action action = () => sut.AddEmployment(null);


            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*required*");
        }



        #endregion
    }
}