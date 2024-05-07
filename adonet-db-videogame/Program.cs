using System;
using System.Data.SqlClient;

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
                        manager.GetVideogiocoById();
                        break;
                    case 3:
                        //GetVideogiochiByString();
                        break;
                    case 4:
                        //CancellaVideogioco();
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

            // Per testare, potresti non dover inserire l'ID della casa software manualmente,
            // puoi impostarlo su un valore fisso o generarlo in qualche modo
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
