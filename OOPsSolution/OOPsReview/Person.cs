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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public Person(string firstname,string lastname, Residence address, List<Employment> employmentPositions)
        {
            if(string.IsNullOrWhiteSpace(firstname))
            {
              //  throw new ArgumentNullException(nameof(firstname),"First name is requried");
              //                              or
                throw new ArgumentNullException( "First name is requried");
            }

            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException( "Last name is requried");
            }
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
    }
}
