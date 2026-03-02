using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool GetDriverInfoByDriverID(int driverID, ref int personID, ref int createdByUserID,
            ref DateTime createdDate)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers_View WHERE DriverID = @driverID";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("@driverID", SqlDbType.Int).Value = driverID;
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = (int)reader["PersonID"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                createdDate = (DateTime)reader["CreatedDate"];

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int personID, ref int driverID, ref int createdByUserID,
            ref DateTime createdDate)
        {
            bool isFound = false;

            using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers_View WHERE PersonID = @personID";

                using(SqlCommand command = new SqlCommand (query , connection))
                {
                    command.Parameters.Add("@personID",SqlDbType.Int).Value = personID;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                driverID = (int)reader["DriverID"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                createdDate = (DateTime)reader["CreatedDate"];

                                isFound = true;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            
            using( SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers_View";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int? AddNewDriver( int personID, int createdByUserID,DateTime createdDate)
        {
            int? driverID = null;

            using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Drivers 
                                    VALUES(@personID,
                                           @createdByUserID,
                                           @createdDate);
                                    SELECT SCOPE_IDENTITY()";

                using(SqlCommand command = new SqlCommand (query , connection))
                {
                    command.Parameters.Add("@personID",SqlDbType.Int).Value = personID;
                    command.Parameters.Add("@createdByUserID", SqlDbType.Int).Value = createdByUserID;
                    command.Parameters.Add("@createdDate", SqlDbType.DateTime).Value = createdDate;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            driverID = newID;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return driverID;
        }

        public static bool UpdateDriver(int driverID,int personID,int createdByUserID) 
        {
            int affectedRows = 0;

            using( SqlConnection connection = new SqlConnection( clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Drivers
                                    SET PersonID = @personID,
                                    	CreatedByUserID = @createdByUserID
                                    WHERE DriverID = @driverID";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("@driverID", SqlDbType.Int).Value = driverID;
                    command.Parameters.Add("@personID", SqlDbType.Int).Value = personID;
                    command.Parameters.Add("@createdByUserID", SqlDbType.Int).Value = createdByUserID;

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message) ; 
                    }
                }
            }

            return affectedRows > 0;
        }


    }
}
