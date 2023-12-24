class Program
{
    static void Main(String [] args)
    {
    
        string filePath = "COM314.txt";
    // binary tree object
     BinaryTree<Person> tree = new BinaryTree<Person>();

     //writing personal details into a file  
         try
             {
                        // Assume you have a collection of Person objects
                    List<Person> people = new List<Person>
                    {
                        new Person("James","Smith",28,"56CD78"),
                        new Person("John", "Doe", 35, "12AB34")
                       
                    };
                            // Pass the filepath and filename to the StreamWriter Constructor
                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                
                                foreach (Person onePerson in people)
                                            {
                                                // Write details of each person on a new line, separated by white space
                                                sw.WriteLine($"{onePerson.GetFirstName()} {onePerson.GetLastName()} {onePerson.GetAge()} {onePerson.GetUniqueId()}\n");                   
                                            }
                            }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

              List<Person> personFromFile = ReadPeopleFromFile(filePath);

                foreach (Person eachPerson in personFromFile)
                {
                    tree.Insert(eachPerson);
                }
        
        

    // decided by a user 
     int choice;

     do{

        Console.WriteLine("BINARY SEARCH TREE");
        Console.WriteLine("1.Inorder traversal of personal details");
        Console.WriteLine("2.postorder traversal of personal details");
        Console.WriteLine("3.Search for a particular person");
        Console.WriteLine("4.press 4 to exit");
        Console.WriteLine();
		Console.WriteLine("Enter your choice");
		choice = Convert.ToInt32(Console.ReadLine());

        if (choice==1)
        {
                
                    foreach (Person value in tree.InOrderTraversal())
                    {
                        Console.WriteLine(value);
                    }  
                
        }

        else if(choice==2)
        {
                 Console.WriteLine("Post-Order Traversal");
                 foreach (Person value in tree.PostOrderTraversal())
                    {
                        Console.WriteLine(value);
                    }

        }
                         else if(choice==3)
                    {
                    // Search for a person using the unique ID
                        Console.WriteLine("Enter unique id here");
                        string uniqueIdToSearch = Console.ReadLine();
                    
                    // Pass the Person object to the Search method
                    BinaryTreeNode<Person> person = tree.Search(uniqueIdToSearch);
                      if (person != null)
                            {
                                Console.WriteLine($"Person with unique ID {uniqueIdToSearch} found: {person.Data}");
                            }
                            else
                            {
                                Console.WriteLine($"Person with unique ID {uniqueIdToSearch} not found in the tree.");
                            }
                  }
        
     }while(choice!=4);
  }

  
   public static List<Person> ReadPeopleFromFile(string filePath)
{
    List<Person> people = new List<Person>();

    try
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;

            while ((line = sr.ReadLine()) != null)
            {
               
                string [] personLines = line.Split(' ');
                // Check if we've read four lines for a person
                if (personLines.Length == 4)
                {
                    string firstName = personLines[0];
                    string lastName = personLines[1];

                    if (int.TryParse(personLines[2].Trim(), out int age))
                    {
                        string uniqueId = personLines[3];
                        // Create a new Person and add it to the list
                        Person newPerson = new Person(firstName, lastName, age, uniqueId);
                        people.Add(newPerson);
                    }
                    else
                    {
                        Console.WriteLine("Invalid age format");
                    }
                }
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }

    return people;
   }
} 
