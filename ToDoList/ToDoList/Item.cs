using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class Item
    {
        public Item(string name, int StopienPilnosci, DateTime dataKoncowa)
        {
            nazwa = name;
            Pilnosc = StopienPilnosci;
            deadline = dataKoncowa;
        }
        #region Operatory

        public static bool operator <(Item a,Item b)
        {
            return (a.deadline < b.deadline);
        }
        public static bool operator >(Item a, Item b)
        {
            return (a.deadline > b.deadline);
        }
        public static bool operator <=(Item a, Item b)
        {
            return (a.deadline <= b.deadline);
        }
        public static bool operator >=(Item a, Item b)
        {
            return (a.deadline >= b.deadline);
        }

        #endregion
        private string nazwa { get; set; }
        public string Nazwa
        {
            get { return nazwa; }
            set { if (value != "" && value != null)nazwa = value;}
        }
        private int pilnosc;

        public int Pilnosc
        {
            get { return pilnosc; }
            set { if (value < 0)
                    pilnosc = 0;
                else if (value > 3) pilnosc = 3;
                else pilnosc = value;
            }
        }

        // nice to do > potrzebne > pilne > bardzo pilne 
        private DateTime deadline { get; set; }
        public void PokazNaKonsoli()
        {
            string output;
            switch (Pilnosc)
            {
                case 0:output = "nice to do"; break;
                case 1:output = "potrzebne"; break;
                case 2:output = "pilne"; break;
                case 3:output = "bardzo pilne"; break;
                default:output = "brak stopnia pilnosci";break;
            }
            Console.WriteLine(nazwa + " " + output + " do: " + Data());
        }
        public void Zmien()
        {
            Console.Clear();
            char input;
            while (true)
            {
                Console.WriteLine("1. Zmien nazwe, aktualna nazwa: " + nazwa);
                Console.WriteLine("2. Zmien stopien pilnosci, aktualny: " + pilnosc);
                Console.WriteLine("(0 - minimum, 3 - maximum)");
                Console.WriteLine("3. Zmien deadline, aktualny: " + deadline);
                Console.WriteLine("4. Nic ");
                Console.WriteLine("Podaj nr czego chcesz zmienic: ");
                input = Console.ReadLine()[0];
                if (input == '1' || input == '2' || input == '3' || input == '4')
                    break;
            }
            Console.Clear();
            switch(input)
            {
                case '1':
                    Console.WriteLine("Podaj nowa nazwe: ");
                    Nazwa = Console.ReadLine();
                    break;
                case '2':
                    Console.WriteLine("Podaj nowy stopien pilnosci(0-3): ");
                    Pilnosc = int.Parse(Console.ReadLine());
                    break;
                case '3':
                    Console.WriteLine("Podaj nowa date: ");
                    Console.WriteLine("Dzien: "); int day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Miesciac: "); int month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Rok: "); int year = int.Parse(Console.ReadLine());
                    deadline = new DateTime(year, month, day);
                    break;
                case '4': break;
            }
            Console.ReadKey();
        }
        public string Data()
        {
            return $"{deadline.Day}/{deadline.Month}/{deadline.Year}";
        }
    }
}
