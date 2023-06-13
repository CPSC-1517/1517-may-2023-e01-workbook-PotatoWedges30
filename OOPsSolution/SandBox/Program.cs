
using OOPsReview;
using System;
using System.Text.Json; //For Json Serialization name

// driver code
//RecordSamples()
//RefactorSample()
//FileIOCSV();


//explore JSon files writing and reading
//create a Person instance with name, address and employments
//Person me = CreatePerson();
//DisplayPerson(me);
////file path C:\Temp\PersonData.json
//string filepathname = @"C:\Temp\PersonData.json";
//SaveAsJson(me, filepathname);
//Person jsonMe = ReadAsJson(filepathname);
//DisplayPerson(jsonMe);

AccessorReview ar = new AccessorReview();
Random rnd = new Random();
for (int i = 0; i < 10; i++ )
{
    ar.Number1 = rnd.Next( 1, 11 );
   // ar.Number2 = rnd.Next(1, 11);
    ar.SetNumber2(rnd.Next(1, 11));
    ar.Add = 0;

    Console.WriteLine( $"Number1: {ar.Number1} Number2: {ar.Number2} Add: {ar.Add}" );
}
Person CreatePerson()
{
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    List<Employment> employments = Read_Employment_Collection_From_CSV();
    Person person = new Person("fardoa", "kito", myHome, employments);
    return person;
}

void DisplayPerson(Person person)
{
    Console.WriteLine("\nPerson Date\n");
    Console.WriteLine($"Name: {person.FullName}");
    Console.WriteLine($"Residence: {person.Address.ToString()}");
    Console.WriteLine("\nEmployments");
    foreach(var item in person.EmploymentPositions)
    {
        Console.WriteLine($"\t{item.ToString()}");
    }
}


void SaveAsJson(Person person, string filepathname)
{
    /**
     * the term used to write Json files is Serialization
     * the classes used are referred to as serializers
     *with writing we can make the file produce more readble format
     *   us
     */
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true //this is for the public non property fields of a class
    };


    string jsonstring = JsonSerializer.Serialize<Person>(person, options);

    File.WriteAllText(filepathname, jsonstring);

}
Person ReadAsJson(string filepathname)
{
    Person person = null;
    try
    {
        //bring in the json text file
        string jsonstring = File.ReadAllText(filepathname);

        //use the deseralizer
        // the expected structure <Person.
        // it is IMPORTANT that the greedy constructor parameter names
        // 
        person = JsonSerializer.Deserialize<Person>(jsonstring);
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }
    
    return person;
}
void FileIOCSV()
{
    //create a coolection of Employment instances to write out the data
    List<Employment> employments = new List<Employment>();
    employments.Add(new Employment("SAS Member",(SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel),"TeamMember"),DateTime.Parse("2015/06/14"),3.8));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamLeader"), DateTime.Parse("2020/01/24"), 2.8));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "Supervisor"), DateTime.Parse("2020/10/24"), 1.8));

    DumpEmployments(employments);
    Write_Employment_Collection_To_CSV(employments);
    List<Employment> employmentsRead = new List<Employment>();
    employmentsRead = Read_Employment_Collection_From_CSV();
    DumpEmployments(employmentsRead);
}



List<Employment> Read_Employment_Collection_From_CSV()
{
    //use the File class to append text records into a file
    //by using the File class one does not need to setup file IO stream
    //  File IO streams (Writer and Reader) are built into the methods of the Fiel class


    //feile path C:\Temp\EmploymentData.txt
    string filepathname = @"C:\Temp\EmploymentData.txt";

    //convert List<Employment>  into List<string>
    Employment employmentInstance = null;
   List<Employment> employmentCollection = new List<Employment>();

    try
    {
        //ReadAllLines
        //returns an array of all lines from a file as strings
        string[] employmentCSVStrings = File.ReadAllLines(filepathname);

        //convert each strings from the CSV data into Employment app instance
        // use the .Parse for this action

        foreach (string line in employmentCSVStrings)
        {


            try
            {
                employmentInstance = Employment.Parse(line);
                employmentCollection.Add(employmentInstance);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }

        }

    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }

                // OR  

    ////ReadAllLines
    ////returns an array of all lines from a file as strings
    
    //string[] employmentCSVStrings = File.ReadAllLines(filepathname);

    ////convert each strings from the CSV data into Employment app instance
    //// use the .Parse for this action

    //foreach (string line in employmentCSVStrings)
    //{
        

    //    try
    //    {
    //        employmentInstance = Employment.Parse(line);
    //        employmentCollection.Add(employmentInstance);

    //    }
    //    catch(ArgumentNullException ex) 
    //    { 
    //        Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
    //    } 
    //    catch (ArgumentOutOfRangeException ex)
    //    {
    //        Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
    //    } 
    //    catch (ArgumentException ex)
    //    {
    //        Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
    //    }

    //}

    return employmentCollection;
    //File.AppendAllLines(filepathname, );

    //.AppendAllLines
    //File.AppendAllLines(filepathname, employmentCollectionAsStrings);
}


void Write_Employment_Collection_To_CSV(List<Employment> employments)
{
    //use the File class to append text records into a file
    //by using the File class one does not need to setup file IO stream
    //  File IO streams (Writer and Reader) are built into the methods of the Fiel class


    //feile path C:\Temp\EmploymentData.txt
    string filepathname = @"C:\Temp\EmploymentData.txt";
    
    //convert List<Employment>  into List<string>
    List<string> employmentCollectionAsStrings = new List<string>();
    foreach(Employment employment in employments)
    {
        employmentCollectionAsStrings.Add(employment.ToString());

    }
    //File.AppendAllLines(filepathname, );

    //.AppendAllLines
    File.AppendAllLines(filepathname, employmentCollectionAsStrings);
}



void DumpEmployments(List<Employment> employments)
{
    Console.WriteLine("\n\t\tDump of employments instances\n");
    for (int i = 0; i < employments.Count; i++)
    {
        Console.WriteLine($"Instance {i}:\t {employments[i].ToString()}");
    }
}
void RecordSamples()
{
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());

    /** 
     * Can I change a value in the record instance? NO
     * myHome.Number = 321;
     */

    // to alter a value in the record instance you MUST create a neew instance
    myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());



}
void RefactorSample()
{
    
    Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());


    myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
    Console.WriteLine(myHome.ToString());

    // Example of refactoring
    // Refactoring is the process of restructing code, while not 
    // changing the original functionality. The goal of refactoring
    // is to improve internal code by making small changes without altering
    // the codes external behaviour

    // orignal code
    bool flag = false;

    if (myHome.Province.ToLower() == "ab")
    {
        flag = true;
    }

    if (myHome.Province.ToLower() == "bc")
    {
        flag = true;
    }

    if (myHome.Province.ToLower() == "sk")
    {
        flag = true;
    }

    if (myHome.Province.ToLower() == "mn")
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

}
   




