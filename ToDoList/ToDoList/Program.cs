using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoList
{
    class Program
    {
        public static List<Item> lista = new List<Item>();
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Lista Rzeczy do zrobienia");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Zobacz liste");
            Console.WriteLine("2. Posortuj liste");
            Console.WriteLine("3. Dodaj zadanie do listy");
            Console.WriteLine("4. Usun zadanie z listy");
            Console.WriteLine("5. Zmien zadanie");
            Console.WriteLine("Wpisz nr zadania ktore chcesz wykonac: ");
            char inChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (inChar)
            {
                case '1':
                    lista.ToList().ForEach(x => x.PokazNaKonsoli());
                    Console.ReadKey();
                    break;
                case '2':
                    Console.WriteLine("Posortuj liste wzgledem: ");
                    Console.WriteLine("1. Nazwy");
                    Console.WriteLine("2. Stopnia Pilnosci");
                    Console.WriteLine("3. Deadline'u");
                    char sort = Console.ReadLine()[0];
                    Console.WriteLine("1. Rosnaco");
                    Console.WriteLine("2. Malejaco");
                    bool descending = Console.ReadLine()[0] == '2';
                    switch (sort)
                    {
                        case '1':
                            lista.ToList(); if (descending)
                                lista.OrderByDescending(x => x.Nazwa);
                            else
                                lista.OrderBy(x => x.Nazwa);
                            break;
                        case '2':
                            lista.ToList(); if (descending)
                                lista.OrderByDescending(x => x.Pilnosc);
                            else
                                lista.OrderBy(x => x.Pilnosc);
                            break;
                        case '3':
                            lista.ToList(); if (descending)
                                lista.OrderByDescending(x => x);
                            else
                                lista.OrderBy(x => x);
                            break;
                        default: break;
                    }
                    Console.WriteLine("Wyświetlić lise: (y/n)");
                    if (Console.ReadLine()[0] == 'y')
                        lista.ToList().ForEach(x => x.PokazNaKonsoli());
                    Console.ReadKey();
                    break;
                case '3':
                    Console.WriteLine("Podaj nazwe: ");
                    string name = Console.ReadLine();
                    if (name == "" || name == null)
                        break;
                    Console.WriteLine("Podaj pilnosc zadania(0-3): ");
                    int priority = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj date deadline'u");
                    Console.WriteLine("Dzien: ");
                    int Day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Miesiac: ");
                    int Month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Rok: ");
                    int Year = int.Parse(Console.ReadLine());

                    if (Day < 1 || Day > 31)
                        break;
                    if (Month < 1 || Month > 12)
                        break;
                    if (Year < 2022)
                        break;
                    lista.Add(new Item(name, priority, new DateTime(Year, Month, Day)));
                    Console.WriteLine("Pomyslnie utworzono nowy obiekt!");
                    Console.ReadKey();
                    break;
                case '4':
                    lista.ToList().ForEach(x => x.PokazNaKonsoli());
                    Console.WriteLine("Podaj nr zadania ktroe chcesz usunac z listy: ");
                    int DeleteNum = int.Parse(Console.ReadLine());
                    lista.RemoveAt(DeleteNum - 1); Console.ReadKey(); break;
                case '5':
                    lista.ToList().ForEach(x => x.PokazNaKonsoli());
                    Console.WriteLine("Podaj nr zadania do zmiany: ");
                    int doZmiany = int.Parse(Console.ReadLine()) - 1;
                    if (doZmiany < 0 || doZmiany > lista.Count - 1)
                        break;
                    lista[doZmiany].Zmien();
                    break;
                default:
                    break;
            }
        }
        
    }
}

