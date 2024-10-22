using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseData 
    {
        public static bool GetLicenseInfoByID(int licenseID,ref int applicationID,ref int driverID, ref int licenseClass,
            ref DateTime issueDate, ref DateTime expirationDate,ref string notes, ref float paidFees,
            ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE LicenseID = @licenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@licenseID",System.Data.SqlDbType.Int).Value = licenseID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                driverID = (int)reader["DriverID"];
                                applicationID = (int)reader["ApplicationID"];
                                licenseClass = (int)reader["LicenseClass"];
                                issueDate = (DateTime)reader["IssueDate"];
                                expirationDate = (DateTime)reader["ExpirationDate"];
                                notes = (string)reader["Notes"];
                                paidFees = Convert.ToSingle(reader["PaidFees"]);
                                isActive = (bool)reader["IsActive"];
                                issueReason = (byte)reader["IssueReason"];
                                createdByUserID = (int)reader["CreatedByUserID"];

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses";

                using (SqlCommand command = new SqlCommand(query , connection))
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
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
                
            return dt;
        }

        public static int? AddNewLicense( int applicationID, int driverID, int licenseClass,DateTime issueDate,
            DateTime expirationDate, string notes,  float paidFees,bool isActive, 
            byte issueReason,int createdByUserID)
        {
            int? newLicenseID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Licenses
                                    VALUES(@applicationID,
                                            @driverID,
                                            @licenseClass,
                                            @issueDate,
                                            @expirationDate,
                                            @notes,
                                            @paidFees,
                                            @isActive,
                                            @issueReason,
                                            @createdByUserID);
                                    SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("applicationID", SqlDbType.Int).Value = applicationID;
                    command.Parameters.Add("driverID", SqlDbType.Int).Value = driverID;
                    command.Parameters.Add("licenseClass", SqlDbType.Int).Value = licenseClass;
                    command.Parameters.Add("issueDate", SqlDbType.DateTime).Value = issueDate;
                    command.Parameters.Add("expirationDate", SqlDbType.DateTime).Value = expirationDate;
                    command.Parameters.Add("notes", SqlDbType.NVarChar).Value = notes;
                    command.Parameters.Add("paidFees", SqlDbType.SmallMoney).Value = paidFees;
                    command.Parameters.Add("isActive", SqlDbType.TinyInt).Value = isActive;
                    command.Parameters.Add("issueReason", SqlDbType.TinyInt).Value = issueReason;
                    command.Parameters.Add("createdByUserID", SqlDbType.Int).Value = createdByUserID;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int id))
                        {
                            newLicenseID = id;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return newLicenseID;
        }

        public static bool UpdateLicense(int licenseID, int applicationID, int driverID, int licenseClass,
            DateTime issueDate, DateTime expirationDate, string notes, float paidFees, bool isActive,
            byte issueReason, int createdByUserID)
        {
            int affectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Licenses
                                    SET 
                                        ApplicationID = @applicationID ,
                                        DriverID = @driverID ,
                                        LicenseClass = @licenseClass ,
                                        IssueDate = @issueDate ,
                                        ExpirationDate = @expirationDate , 
                                        Notes = @notes ,
                                        PaidFees = @paidFees ,
                                        IsActive = @isActive ,
                                        IssueReason = @issueReason ,
                                        CreatedByUserID = @createdByUserID 
                                    WHERE   LicenseID = @licenseID";

                using (SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("LicenseID", SqlDbType.Int).Value = licenseID;
                    command.Parameters.Add("applicationID", SqlDbType.Int).Value = applicationID;
                    command.Parameters.Add("driverID", SqlDbType.Int).Value = driverID;
                    command.Parameters.Add("licenseClass", SqlDbType.Int).Value = licenseClass;
                    command.Parameters.Add("issueDate", SqlDbType.DateTime).Value = issueDate;
                    command.Parameters.Add("expirationDate", SqlDbType.DateTime).Value = expirationDate;
                    command.Parameters.Add("notes", SqlDbType.NVarChar).Value = notes;
                    command.Parameters.Add("paidFees", SqlDbType.SmallMoney).Value = paidFees;
                    command.Parameters.Add("isActive", SqlDbType.TinyInt).Value = isActive;
                    command.Parameters.Add("issueReason", SqlDbType.TinyInt).Value = issueReason;
                    command.Parameters.Add("createdByUserID", SqlDbType.Int).Value = createdByUserID;

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return affectedRows > 0;
        }

        // complete it after creating Drivers Class
        public static int? GetActiveLicenseIDByPersonID(int personID, int licenseClassID)
        {
            int? activeLicenseID = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"";

                using(SqlCommand command = new SqlCommand(query ,connection))
                {

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int id))
                        {
                            activeLicenseID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return activeLicenseID;
        }

        //GetDriverLicenses
        //DeactivateLicense


    }
}
