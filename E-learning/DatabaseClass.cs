using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Data;
using System.Data;

namespace E_learning
{
    class DatabaseClass
    {
        private string conn;
        private MySqlConnection connect;

        private void db_connection()
        {
            try
            {
                conn = "Server=localhost;Database=e-learning;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        private bool validate_login(string user, string password)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from users where Username=@user and Password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }

        public string GetRol(string sUser)
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from users where Username='" + sUser + "'"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            string RolID = Convert.ToString(retValue.Rows[0]["RolID"]);
            return RolID;
        }

        public void try_login(string user, string password, MainWindow form)
        {

            if (user == "" || password == "")
            {
                MessageBox.Show("Vul uw gebruikersnaam en wachtwoord in");
                return;
            }
            bool r = validate_login(user, password);
            if (r)
            {
                string sRolID = GetRol(user).ToString();

                if (sRolID == "2")
                {
                    cmsmenu cms = new cmsmenu();
                    cms.Show();
                    form.Close();
                }

                else if (sRolID == "1")
                {
                    Keuzemenu_Leerling menu = new Keuzemenu_Leerling();
                    menu.Show();
                    form.Close();
                }

                else
                {
                    MessageBox.Show("whoops! Het lijkt erop dat er een fout is opgetreden, neem contact op met de beheerders van het systeem.", "WHOOPS!");
                }

            }

            else
            {
                MessageBox.Show("Uw gebruikersnaam of wachtwoord is onjuist", "Oh nee!");
            }
        }

        public DataTable GetVakken()
        {
            DataTable retValue = new DataTable();
            db_connection();
            using (MySqlCommand cmd = new MySqlCommand("Select * from vak"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;
        }

        public DataTable GetLesOnderwerp(string svakID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from lesonderwerp where VakID=" + svakID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;

        }

        public DataTable GetLes(string sLesonderwerpID)
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from Les where LesonderwerpID=" + sLesonderwerpID))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;

        }

        public DataTable GetAlleLesOnderwerp()
        {
            DataTable retValue = new DataTable();
            db_connection();

            using (MySqlCommand cmd = new MySqlCommand("Select * from lesonderwerp order by LesOmschrijving"))
            {
                cmd.Connection = connect;
                MySqlDataReader reader = cmd.ExecuteReader();
                retValue.Load(reader);
                connect.Close();
            }
            return retValue;

        }

        public void newLesOnderwerp(string sVakID, string sVakOmschrijving, RegLesOnd form)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into lesonderwerp (LesonderwerpID, LesOmschrijving, VakID) VALUES (NULL, @vakoms, @vakid);";
            cmd.Parameters.AddWithValue("@vakid", sVakID);
            cmd.Parameters.AddWithValue("@vakoms", sVakOmschrijving);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het lesonderwerp: " + sVakOmschrijving + " is succesvol aangemaakt.", "WOOHOO!");
                lesonderwerpbeheer lob = new lesonderwerpbeheer();
                lob.Show();
                form.Close();

            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van: " + sVakOmschrijving, "OOPSIE!");
            }
            finally
            {
                connect.Close();
            }
        }

        public void deleteLesOnderwerp(string sloID)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "delete from lesonderwerp where LesonderwerpID=@sloID";
            cmd.Parameters.AddWithValue("@sloID", sloID);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Het lesonderwerp is succesvol verwijderd.", "YAY!");
            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het vewijderen van het lesonderwerp, probeer later nog eens.", "Oh nee!");
            }
            finally
            {
                connect.Close();
            }

        }

        public void newLes(string sloID, string sLesNaam, string sUitleg, RegLes regform, LesonderwerpWijzig lesbeheerform)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into les (LesID, Uitleg, LesonderwerpID, lesNaam) VALUES (NULL, @sUitleg, @sloID, @sLesNaam);";
            cmd.Parameters.AddWithValue("@sloID", sloID);
            cmd.Parameters.AddWithValue("@sLesNaam", sLesNaam);
            cmd.Parameters.AddWithValue("@sUitleg", sUitleg);
            cmd.Connection = connect;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("De les: " + sLesNaam + " is succesvol aangemaakt.", "WOOHOO!");
                lesbeheerform.Show();
                regform.Close();

            }
            catch
            {
                MessageBox.Show("Er is iets mis gegaan met het opslaan van: ", "OOPSIE!");
            }
            finally
            {
                connect.Close();

            }
        }
    }
}

        