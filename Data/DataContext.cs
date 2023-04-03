using System;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }    

        public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();


        static readonly string connectionString = "Server=localhoset; User ID=root; Password=password; Database=superhero";
        public static MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "password";
            conn_string.Database = "SuperHeroData";


            return new MySqlConnection(conn_string.ToString());

        }
    }
}
