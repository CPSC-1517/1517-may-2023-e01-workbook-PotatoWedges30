
using OOPsReview;



Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

/** 
 * Can I change a value in the record instance? NO
 * myHome.Number = 321;
 */

// to alter a value in the record instance you MUST create a neew instance

 myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

// Example of refactoring
// Refactoring is the process of restructing code, while not 
// changing the original functionality. The goal of refactoring
// is to improve internal code by making small changes without altering
// the codes external behaviour

// orignal code
bool flag = false;

if (myHome.Province.ToLower()=="ab")
{
    flag = true;    
}

if (myHome.Province.ToLower()=="bc")
{
    flag = true;
}

if (myHome.Province.ToLower()=="sk")
{
    flag = true;
}

if (myHome.Province.ToLower()=="mn")
{
    flag = true;
}


if (myHome.Province.ToLower() == "ab" || 
    myHome.Province.ToLower() == "bc" || 
    myHome.Province.ToLower() == "sk" || 
    myHome.Province.ToLower() == "mn")
{
    flag = true;
}



//refactor using a switch statement

switch (myHome.Province.ToLower())
{
    case "ab":
    case "bc":
    case "sk":
    case "mn":
        {
            flag = true;
            break;
        }
    default:
        {
            flag = true;
            break;
        }
}

// what would a person need to do if unit testing does not exists
string firstname = "fardosa";
string lastname = "kito";
Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Person me = new Person(firstname, lastname, address, null);



//conside doing a loop where I make changes to the "changename", include try catch error handling
//also need a interface of Console prompt and read lines.

// me.FirstName = changename;