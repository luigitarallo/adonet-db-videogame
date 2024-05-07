using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
    public const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=db_videogame;Integrated Security=True;Trust Server Certificate=True";   
        static void Main(string[] args)
        {
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
                        //InsertVideogioco();
                        break;
                    case 2:
                        //GetVideogiocoById();
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
    public static void InsertVideogioco()
    }
}
