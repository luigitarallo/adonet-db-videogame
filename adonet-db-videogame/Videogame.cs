using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int SoftwareHouseId { get; set; }

        public Videogame(string name, string overview, DateTime releaseDate, int softwareHouseId)
        {

            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            SoftwareHouseId = softwareHouseId;
        }

        public Videogame(int id, string name, string overview, DateTime releaseDate, DateTime createdAt, DateTime updatedAt, int softwareHouseId)
        {
            Id = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftwareHouseId = softwareHouseId;
        }
    }
}
