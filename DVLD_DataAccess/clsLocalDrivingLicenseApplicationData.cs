using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LicenseID,
            ref int ApplicationID,ref int LicenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                                    WHERE LocalDrivingLicenseApplicationID = @LicenseID";

                using (SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetLocalDrivingLicenseApplicationInfoByAppID(int ApplicationID,
            ref int LicenseID, ref int LicenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                                    WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseID = (int)reader["LicenseID"];
                                LicenseClassID = (int)reader["LicenseClassID"];
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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int? LicenseID = null;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications
                                    VALUES(@ApplicationID,@LicenseClassID);
                                 SELECT SCOPE_IDENTITY()"; 

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", SqlDbType.Int).Value = ApplicationID; // chat gpt : it's good practice
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newID))
                            LicenseID = newID;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return LicenseID??-1;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LicenseID,
             int ApplicationID,  int LicenseClassID)
        {
            int AffectedRows = 0;

            using( SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE LocalDrivingLicenseApplications
                                    SET ApplicationID = @ApplicationID,
                                        LicenseClassID = @LicenseClassID
                                    WHERE LocalDrivingLicenseApplicationID = @LicenseID";

                using(SqlCommand command = new SqlCommand (query , connection))
                {
                    command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                    command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = ApplicationID;
                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                    try
                    {
                        connection.Open();
                        AffectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine(ex.Message); 
                    }
                }
            }

            return AffectedRows > 0;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LicenseID)
        {
            int AffectedRows = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"DELETE FROM LocalDrivingLicenseApplications
                                 WHERE LocalDrivingLicenseApplicationID = @LicenseID";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("@LicenseID",SqlDbType.Int).Value = LicenseID;

                    try
                    {
                        connection.Open();
                        AffectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine(ex.Message.ToString()); 
                    }
                }
            }

            return AffectedRows > 0;
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection())
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplications_View";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }

            return dt;
        }

    }
}
