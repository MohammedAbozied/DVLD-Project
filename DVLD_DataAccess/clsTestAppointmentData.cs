using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentData
    {
        public static bool GetTestAppointmentInfoByID(int testAppointmentID, ref int testTypeID,
            ref int LDLApplicationID, ref DateTime appointmentDate, ref float paidFees,
            ref int createdByUserID, ref bool isLocked, ref int? retakeTestApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @testAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                testTypeID = (int)reader["TestTypeID"];
                                LDLApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                appointmentDate = (DateTime)reader["AppointmentDate"];
                                paidFees = Convert.ToSingle(reader["PaidFees"]);
                                createdByUserID = (int)reader["CreatedByUserID"];
                                isLocked = (bool)reader["IsLocked"];

                                //retake test app id is nullable
                                retakeTestApplicationID = reader["RetakeTestApplicationID"] == DBNull.Value ?
                                    null : (int?)reader["RetakeTestApplicationID"];

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return isFound;
        }

        public static bool GetLastTestAppointment(int LDLApplicationID,ref int testAppointmentID,
            int testTypeID, ref DateTime appointmentDate,ref float paidFees, 
            ref int createdByUserID, ref bool isLocked, ref int? retakeTestApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TOP 1 * FROM TestAppointments 
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID
                                    AND TestTypeID = @testTypeID
								ORDER BY TestAppointmentID DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
                    command.Parameters.AddWithValue("@testTypeID", testTypeID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                testAppointmentID = (int)reader["TestAppointmentID"];
                                testTypeID = (int)reader["TestTypeID"];
                                appointmentDate = (DateTime)reader["AppointmentDate"];
                                paidFees = Convert.ToSingle(reader["PaidFees"]);
                                createdByUserID = (int)reader["CreatedByUserID"];
                                isLocked = (bool)reader["IsLocked"];

                                retakeTestApplicationID = reader["TestAppointmentID"] == DBNull.Value ?
                                    null : (int?)reader["TestAppointmentID"];

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
            return isFound;
        }
       
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestAppointments_View ORDER BY AppointmentDate DESC";

                using(SqlCommand command = new SqlCommand(query, connection))
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
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }

            return dt;  
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LDLAppID,int testTypeID)
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments	
                            WHERE LocalDrivingLicenseApplicationID = @LDLAppID
                                        AND TestTypeID = @testTypeID";

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                    command.Parameters.AddWithValue("@testTypeID", testTypeID);

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
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }

            return dt;
        }


        public static int AddNewTestAppointment( int testTypeID,int LDLApplicationID,
            DateTime appointmentDate, float paidFees,int createdByUserID,int? retakeTestApplicationID)
        {
            int? testAppointmentID = null;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO TestAppointments
                                VALUES(@testTypeID,
                                        @LDLApplicationID,
                                        @appointmentDate,
                                        @paidFees,
                                        @createdByUserID,
                                        @isLocked,
                                        @retakeTestApplicationID);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testTypeID", testTypeID);
                    command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
                    command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@paidFees", paidFees);
                    command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@isLocked", 0);

                    command.Parameters.AddWithValue("@retakeTestApplicationID",
                        retakeTestApplicationID ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if(result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            testAppointmentID = newID;
                        }

                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine(ex.Message); 
                    }
                }
            }

            return testAppointmentID ?? -1;
        }
        public static bool UpdateTestAppointment(int testAppointmentID, int testTypeID,
            int LDLApplicationID, DateTime appointmentDate, float paidFees, int createdByUserID,
            bool isLocked, int? retakeTestApplicationID)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TestAppointments
                                SET TestTypeID = @testTypeID,
                                     LocalDrivingLicenseApplicationID = @LDLApplicationID,
                                     AppointmentDate = @appointmentDate,
                                     PaidFees = @paidFees,
                                     CreatedByUserID = @createdByUserID,
                                     IsLocked = @isLocked,
                                     RetakeTestApplicationID = @retakeTestApplicationID
                                WHERE TestAppointmentID = @testAppointmentID";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testTypeID", testTypeID);
                    command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
                    command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
                    command.Parameters.AddWithValue("@paidFees", paidFees);
                    command.Parameters.AddWithValue("@createdByUserID", createdByUserID);
                    command.Parameters.AddWithValue("@isLocked", isLocked);
                    command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

                    command.Parameters.AddWithValue("@retakeTestApplicationID", retakeTestApplicationID ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString()); // we can replace with log :)
                        return false;
                    }
                }
            }

            return affectedRows > 0;
        }

        public static int? GetTestID(int testAppointmentID)
        {
            int? testID = null;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT TestID FROM Tests WHERE TestAppointmentID = @testAppointmentID";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        /*if(result !=null && int.TryParse(result.ToString(), out int outTestID))
                        {
                            testID = outTestID;
                        }*/

                        // Using the 'as' keyword for casting, returns null if the cast fails.
                        testID = result as int? ?? null; //  If result is null or cannot be cast, return null.
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }

            return testID;
        }


    }
}
