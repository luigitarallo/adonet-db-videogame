using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        public const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=db_videogame;Integrated Security=True";

        public void InsertVideogame(Videogame videogame)
        {
            using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connection.Open();
                string query = @"INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id)
VALUES (@name, @overview, @release_date, @created_at, @updated_at, @sh_id)";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", videogame.Name);
                command.Parameters.AddWithValue("@overview", videogame.Overview);
                command.Parameters.AddWithValue("@release_date", videogame.ReleaseDate);
                command.Parameters.AddWithValue("@created_at", videogame.CreatedAt);
                command.Parameters.AddWithValue("@updated_at", videogame.UpdatedAt);
                command.Parameters.AddWithValue("@sh_id", videogame.SoftwareHouseId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante l'inserimento del videogioco:");
                Console.WriteLine(ex.ToString());
            }

        }

        public void GetVideogiocoById()
        {
            using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                Console.Write("Inserisci l'ID del videogioco da cercare: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("ID non valido. Riprova.");
                    return;
                }
                connection.Open();
                string query = "SELECT * FROM videogames WHERE id = @id";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}");
                        Console.WriteLine($"Nome: {reader["name"]}");
                        Console.WriteLine($"Descrizione: {reader["overview"]}");
                        Console.WriteLine($"Data di uscita: {reader["release_date"]}");
                        Console.WriteLine($"Data di creazione: {reader["created_at"]}");
                        Console.WriteLine($"Data di aggiornamento: {reader["updated_at"]}");
                        Console.WriteLine($"ID della casa software: {reader["software_house_id"]}");
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante la ricerca del videogame");
                Console.WriteLine(ex.ToString() );
            }

        }
    }
}
