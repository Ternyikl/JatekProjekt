using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "Server=localhost;Database=jatekdb;User Id=root;Pwd='';";
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            var karakterek = new List<Karakter>();
            try
            {
                using(MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM karakterek";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            Karakter karakter = new Karakter(
                                reader.GetInt32("id"),
                                reader.GetString("nev"),
                                reader.GetString("osztaly"),
                                reader.GetInt32("szint"),
                                reader.GetInt32("arany"),
                                reader.GetString("szerver")
                                );
                            karakterek.Add(karakter);
                        }
                    }
                }
            } 
            catch(MySqlException ex)
            {
                Console.WriteLine("Hiba az adatbázis betöltése során: " + ex.Message);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nem az adatbázis köthető hiba történt: " + ex.Message);
                Environment.Exit(1);
            }

            return karakterek;
        }
    }
}
