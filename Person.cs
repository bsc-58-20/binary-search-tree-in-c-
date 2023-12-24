using System;

public class Person : IComparable<Person>
{
    // these are only accessible in this clas but inaccessible outside of this class
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private int Age { get; set; }
    private string UniqueId { get; set; }


     // Constructor
    public Person(string firstName, string lastName, int age, string uniqueId)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
         SetUniqueId(uniqueId);
    }
   
    // Public method to set the first name
    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    // Public method to get the first name
    public string GetFirstName()
    {
        return FirstName;
    }

    // Public method to set the last name
    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    // Public method to get the last name
    public string GetLastName()
    {
        return LastName;
    }

    // Public method to set the age
    public void SetAge(int age)
    {
        if (age >= 0)
        {
            Age = age;
        }
        else
        {
            Console.WriteLine("Invalid age. Age must be a non-negative value.");
        }
    }

    // Public method to get the age
    public int GetAge()
    {
        return Age;
    }

    // Public method to set the unique ID
    public void SetUniqueId(string uniqueId)
    {
        if (uniqueId.Length == 6)
        {
            UniqueId = uniqueId;
        }
        else
        {
            Console.WriteLine("Invalid unique ID. It must be a string of length 6.");
        }
    }

    // Public method to get the unique ID
    public string GetUniqueId()
    {
        return UniqueId;
    }

    public int CompareTo(Person other)
    {
        return Age.CompareTo(other.Age);
    }

        // Compare persons based on unique ID
    public int CompareToByUniqueId(Person other)
    {
        return UniqueId.CompareTo(other.UniqueId);
    }
    
    // Override ToString method to provide a custom string representation of the Person
    public override string ToString()
    {
        return $"First name: {FirstName} Last name: {LastName}  Age: {Age} Unique Id: {UniqueId}\n";
    }
    
}
