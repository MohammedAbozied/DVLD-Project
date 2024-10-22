using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsCountryData
    {

        public static bool GetCountryByID(int CountryID, ref string CountryName)
        {
            bool is_found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                    is_found = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetCountryByID() method: " + ex.ToString());
                is_found = false;
            }
            finally
            {
                connection.Close();
            }
            return is_found;

        }

        public static bool GetCountryByCountryName(string CountryName, ref int CountryID)
        {
            bool is_found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CountryID = (int)reader["CountryID"];
                    is_found = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetCountryByID() method: " + ex.ToString());
                is_found = false;
            }
            finally
            {
                connection.Close();
            }
            return is_found;

        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries ORDER BY CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllCountries() method: " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }



    }


}
