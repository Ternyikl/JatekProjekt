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
                            while (reader.Read())
                            {
                                Karakter karakter = new Karakter(
                                    reader.GetInt32("Id"),
                                    reader.GetString("Nev"),
                                    reader.GetString("Osztaly"),
                                    reader.GetInt32("Szint"),
                                    reader.GetInt32("Arany"),
                                    reader.GetString("Szerver")
                                );
                                karakterek.Add(karakter);
                            }
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
