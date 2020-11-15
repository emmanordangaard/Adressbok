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
                file.WriteLine(saved.name + "," + saved.address + "," + saved.number + "," + saved.email);
            }
        }
        static public List<Person> LoadFile()
        {
            // Create new list to return
            List<Person> List = new List<Person>();
            using (StreamReader file = new StreamReader(@"C:\Users\te16en2\exempelfil-sv.txt"))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    Person P = new Person(values[0], values[1], values[2], values[3]);
                    List.Add(P);
                }

            }
            return List;
        }

        static public void ResetFile()
        {
            FileStream fileStream = File.Open(@"C:\Users\te16en2\exempelfil-sv.txt", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();
        }

        static public void SaveToFile(List<Person> list)
        {
            ResetFile();
            using (StreamWriter file = new StreamWriter(@"C:\Users\te16en2\exempelfil-sv.txt"))
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    Person saved = list[i];
                    file.WriteLine(saved.name + "," + saved.address + "," + saved.number + "," + saved.email);
                }

            }
        }
        static public void Menu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Hej och välkommen till adressboken!                |");
            Console.WriteLine("Kommandon att använda                              |");
            Console.WriteLine("ny: för att lägga in ny person                     |");
            Console.WriteLine("visa: för att se vilka personer som är inlagda     |");
            Console.WriteLine("ta bort: radera person ur adressboken              |");
            Console.WriteLine("spara i fil: spara ned adressboken i textfil       |");
            Console.WriteLine("----------------------------------------------------");
        }


        static void Main(string[] args)
        {

            string command;
            Menu();

            List<Person> addressbook = LoadFile();

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
                    SaveToFile(addressbook);
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
                    SaveToFile(addressbook);
                    Console.WriteLine("{0} togs bort", saved.GetData());
                }
            } while (command != "sluta");


        }
    }
}
