using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok
{
    class Program
    {
        public class Person
        {
            public string name, address, number, email;

            public Person(string name, string address, string number, string email)
            {
                this.name = name;
                this.address = address;
                this.number = number;
                this.email = email;
            }
            public string GetData()
            {
                return $"Namn: {this.name} adress: {this.address} telefonnr: {this.number} emailadress: {this.email}";
            }
            

        }
        static public void SavePerson(Person saved)
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\te16en2\exempelfil-sv.txt"))
            {
                file.WriteLine(saved.name + "," + saved.address + "," + saved.name + "," + saved.email);
            }
        }

        static void Main(string[] args)
        {
            
            string command;
            Console.WriteLine("Hej och välkommen till adressboken!");
            Console.WriteLine("Skriva sluta för att avsluta programmet.");

            List<Person> addressbook = new List<Person>();

                do
                {

                    Console.Write(">");
                    command = Console.ReadLine();
                    if (command == "ny")
                    {
                        
                        Console.Write("Ange namn: ");
                        string name = Console.ReadLine();
                        Console.Write("Ange adress: ");
                        string address = Console.ReadLine();
                        Console.Write("Ange telefon: ");
                        string number = Console.ReadLine();
                        Console.Write("Ange email: ");
                        string email = Console.ReadLine();
                        Person newContact = new Person(name, address, number, email);
                        addressbook.Add(newContact);
                        SavePerson(newContact);
                        Console.WriteLine("Person med {0} inlagd!", newContact.GetData());
                    }
                    else if (command == "visa")
                    {
                        for (int i = 0; i < addressbook.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}: {addressbook[i].GetData()}");
                        }
                    }
                    else if (command == "ta bort")
                    {
                        Console.Write("Ange nummer du vill ta bort: ");
                        int remove = int.Parse(Console.ReadLine());
                        Person saved = addressbook[remove - 1];
                        addressbook.RemoveAt(remove - 1);
                        Console.WriteLine("{0} togs bort", saved.GetData());
                    }
                } while (command != "sluta");
            

        }
    }
}
