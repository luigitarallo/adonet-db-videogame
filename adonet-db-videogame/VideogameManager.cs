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
       public void InsertVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(Program.STRINGA_DI_CONNESSIONE))
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
    }
}
