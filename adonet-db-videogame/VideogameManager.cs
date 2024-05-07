using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                int affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante l'inserimento del videogioco:");
                Console.WriteLine(ex.ToString());
            }

        }

        public void GetVideogameById(int id)
        {
            using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
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
        public List<Videogame> GetVideogameByString(string searchString)
        {
            using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            List<Videogame> videogames = new List<Videogame>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM videogames WHERE name LIKE @searchstring";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@searchstring", "%" + searchString + "%"));
                using SqlDataReader reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                       Videogame videogame = new Videogame(
                            id: Convert.ToInt32(reader["id"]),
                            name: (string)reader["name"],
                            overview: (string)reader["overview"],
                            releaseDate: (DateTime)reader["release_date"],
                            createdAt: (DateTime)reader["created_at"],
                            updatedAt: (DateTime)reader["updated_at"],
                            softwareHouseId: Convert.ToInt32(reader["software_house_id"])
                     );
                     videogames.Add(videogame);
                    }
                       
                }
                
            }catch (Exception ex) 
            {
                Console.WriteLine("Si è verificato un errore durante la ricerca del videogame");
                Console.WriteLine(ex.ToString());
            }
        return videogames;
        }
        public void DeleteVideogameById(int id)
        {
            using SqlConnection connection = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connection.Open();
                string query = "DELETE FROM videogames WHERE id = @id";
                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Videogioco eliminato con successo.");
                }
                else
                {
                    Console.WriteLine("Nessun videogioco trovato con l'ID specificato.");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore durante l'eliminazione del videogioco.");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
