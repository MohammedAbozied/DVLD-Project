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
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID,ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus,ref DateTime LastStatusDate, 
            ref float PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                isFound = true;
                            }

                        }
                        
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Applications";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
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


        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            int? ApplicationID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Applications
                                  VALUES( @ApplicantPersonID, 
                                    @ApplicationDate,
                                    @ApplicationTypeID,
                                    @ApplicationStatus, 
                                    @LastStatusDate, 
                                    @PaidFees,
                                    @CreatedByUserID);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar(); // return the new ID
                        if (result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            ApplicationID = newID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return ApplicationID??-1;   
        }

        public static bool UpdateApplication(int? ApplicationID,int ApplicantPersonID, 
            DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int AffectedRow = 0;
            
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Applications
                                    SET ApplicantPersonID= @ApplicantPersonID,
                                        ApplicationDate = @ApplicationDate,
                                        ApplicationTypeID = @ApplicationTypeID,
                                        ApplicationStatus = @ApplicationStatus,
                                        LastStatusDate = @LastStatusDate,
                                        PaidFees = @PaidFees,
                                        CreatedByUserID = @CreatedByUserID
                                    WHERE ApplicationID = @ApplicationID";


                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("PaidFees", PaidFees);
                    command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);
                    
                    try
                    {
                        connection.Open();
                        AffectedRow = command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return AffectedRow > 0;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int AffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT ISFOUND = 1 FROM Applications WHERE ApplicationID =@ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        isFound = reader.HasRows;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static int? GetActiveApplicationIDForLicenseClass(int personID,int applicationTypeID,int licenseClassID)
        {
            int? applicationID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                                    From Applications INNER JOIN
                                        LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                                    WHERE ApplicantPersonID = @ApplicantPersonID 
                                        and ApplicationTypeID=@ApplicationTypeID 
				                        and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                                        and ApplicationStatus=1";// active

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = personID;
                    command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                    try
                    {
                        connection.Open();
                        applicationID = (int)command.ExecuteScalar();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return applicationID;
        }


    }
}
