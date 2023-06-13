using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class AccessorReview
    {
        //this class will be used to review how an accessor
        // can be used to control access to calculate a value

        //On a property 
        // the get returns a value to the calling client 
        //     the value is the data associated with the property
        // the set receives a value from the calling client
        //      the incoming value is placed into a data hold
        public int Number1 { get; set; } //auto implemented property
        public int Number2 { get; set; }
        public int Add
        {
            get
            {
                return Number1 + Number2;
            }
            set { }
        }

        public void SetNumber2(int value)
        {
            Number2 = value
        }
    }
}
