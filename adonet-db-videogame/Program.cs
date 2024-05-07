using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace adonet_db_videogame
{
    internal class Program
    {
    public const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=db_videogame;Integrated Security=True";   
        static void Main(string[] args)
        {
            VideogameManager manager = new VideogameManager();
            int scelta;
            do
            {
                Console.WriteLine("Seleziona un'opzione");
                Console.WriteLine("1. Inserire un nuovo videogioco");
                Console.WriteLine("2. Ricercare un videogioco per ID");
                Console.WriteLine("3. Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa");
                Console.WriteLine("4. Cancellare un videogioco");
                Console.WriteLine("5. Chiudere il programma");
                Console.Write("Seleziona un numero per scegliere cosa fare: ");

                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida. Riprova");
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        InsertNewVideogame();
                        break;
                    case 2:
                        Console.Write("Inserisci l'ID del videogioco da cercare: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("ID deve essere un numero. Riprova.");
                            continue;
                        }
                        manager.GetVideogameById(id);
                        break;
                    case 3:
                        Console.Write("Inserisci il nome del videogame da cercare: ");
                        string searchString = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(searchString))
                        {
                            List<Videogame> foundGames = manager.GetVideogameByString(searchString);
                            if (foundGames.Count > 0)
                            {
                                Console.WriteLine("Videogiochi trovati:");
                                foreach (var game in foundGames)
                                {
                                    Console.WriteLine($"ID: {game.Id}, Nome: {game.Name}, Descrizione: {game.Overview}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogame trovato con il nome specificato.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Il nome inserito non è valido.");
                        }
                        break;
                    case 4:
                        Console.Write("Inserisci l'ID del videogioco da cancellare: ");
                        if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            Console.WriteLine("ID non valido. Riprova.");
                            break;
                        }
                        manager.DeleteVideogameById(idToDelete);
                        break;
                    case 5:
                        Console.WriteLine("Programma chiuso.");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova");
                        break;
                }
            } while (scelta != 5);
        }
    public static void InsertNewVideogame()
        {
            Console.WriteLine("Inserimento di un nuovo videogioco:");

            Console.Write("Nome del videogioco: ");
            string name = Console.ReadLine();

            Console.Write("Descrizione: ");
            string overview = Console.ReadLine();

            Console.Write("Data di uscita (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime releaseDate))
            {
                Console.WriteLine("Formato data non valido. Riprova.");
                return;
            }

            Console.Write("Quale software house ha prodotto il gioco?");
            Console.WriteLine("Seleziona un'opzione");
            Console.WriteLine("1. Nintendo");
            Console.WriteLine("2. Rockstar Games");
            Console.WriteLine("3. Valve Corporation");
            Console.WriteLine("4. Electronic Arts");
            Console.WriteLine("5. Ubisoft");
            Console.WriteLine("6. Konami");
            Console.Write("Seleziona un numero per indicare la Software House: ");

            int softwareHouseId;
            
            if (!int.TryParse(Console.ReadLine(), out softwareHouseId) || softwareHouseId < 1 || softwareHouseId > 6)
            {
                Console.WriteLine("Scelta non valida. Riprova");
                return;
            }

            switch (softwareHouseId)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    break;
                default:
                    Console.WriteLine("Scelta non valida. Riprova");
                    return;
            }

            VideogameManager manager = new VideogameManager();
            manager.InsertVideogame(new Videogame(name, overview, releaseDate, softwareHouseId));

            Console.WriteLine("Videogioco inserito con successo!");
        }
    }
}
