using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName 
        {
           get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //  throw new ArgumentNullException(nameof(firstname),"First name is requried");
                    //                              or
                    throw new ArgumentNullException("first name is required");
                }
                _FirstName = value;
            }
        }
        public string LastName 
        {

            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("last name is required");
                }
                _LastName = value;
            }
        }

        public string FullName 
        {
            //get { return _FirstName + " " + _LastName; }
            get { return LastName + ", " + FirstName; }
        }

        public int NumberOfEmployments
        {
            get { return EmploymentPositions.Count(); }
        }

        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public Person(string firstname,string lastname, Residence address, List<Employment> employmentPositions)
        {
            //if (string.IsNullOrWhiteSpace(firstname))
            //{
            //    //  throw new ArgumentNullException(nameof(firstname),"First name is requried");
            //    //                              or
            //    throw new ArgumentNullException("First name is requried");
            //}

            //if (string.IsNullOrWhiteSpace(lastname))
            //{
            //    throw new ArgumentNullException("Last name is requried");
            //}

           
            FirstName = firstname;
            LastName = lastname;
            Address = address;

            if (employmentPositions != null )
            {
                EmploymentPositions = employmentPositions; // store the supplied list of employments
            }
            /**else
            {
                EmploymentPositions = new List<Employment>(); // create an empty instance of the list
            }*/
            
        }

        public Person()
        {
            //EmploymentPositions = new List<Employment>(); // create an empty instance of the list


            FirstName = "unknown";
            LastName = "unknown";
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
           
        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException("Employment record position is required.");
            }
            EmploymentPositions.Add(employment);
        }
    }
}
