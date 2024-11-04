using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfoByClassID(int LicenseClassID, 
            ref string ClassName, ref string ClassDescription, ref byte MinAge,
            ref byte DefaultValidityLength, ref float Fees)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
            {
                string query = 
                    "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = LicenseClassID;

                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                ClassName = (string)reader["ClassName"];
                                ClassDescription = (string)reader["ClassDescription"];
                                MinAge = (byte)reader["MinimumAllowedAge"];
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                Fees = Convert.ToSingle(reader["ClassFees"]);

                                isFound = true;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return isFound;
        }


        public static bool GetLicenseClassInfoByClassName(string ClassName,
            ref int LicenseClassID,ref string ClassDescription, ref byte MinAge,
            ref byte DefaultValidityLength, ref float Fees)
        {
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;

                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                LicenseClassID = (int)reader["LicenseClassID"];
                                ClassDescription = (string)reader["ClassDescription"];
                                MinAge = (byte)reader["MinimumAllowedAge"];
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                                Fees = Convert.ToSingle(reader["ClassFees"]);

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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses";

                using(SqlCommand command = new SqlCommand (query , connection))
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
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }
        public static int AddNewLicenseClass( string ClassName,  string ClassDescription, 
            byte MinAge,byte DefaultValidityLength,float Fees)
        {
            int? LicenseClassID = null;

            using(SqlConnection connection = new SqlConnection (clsDataAccessSettings.ConnectionString)) 
            {
                string query = @"INSERT INTO LicenseClasses
                                    VALUES( @ClassName,
                                            @ClassDescription,
                                            @MinAge,
                                            @DefaultValidityLength,
                                            @Fees);
                                 SELECT SCOPE_IDENTITY()";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.Add("@ClassName",SqlDbType.NVarChar).Value = ClassName;
                    command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar).Value = ClassDescription;
                    command.Parameters.Add("@MinAge", SqlDbType.TinyInt).Value = MinAge;
                    command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = DefaultValidityLength;
                    command.Parameters.Add("@Fees", SqlDbType.SmallMoney).Value = Fees;

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int newID))
                        {
                            LicenseClassID = newID;
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return LicenseClassID??-1;
        }


        public static bool UpdateLicenseClass(int LicenseClassID,string ClassName, 
            string ClassDescription, byte MinAge, byte DefaultValidityLength, float Fees)
        {
            int AffectedRows = 0;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE LicenseClasses 
                                    SET ClassName = @ClassName,
                                        ClassDescription = @ClassDescription,
                                        MinimumAllowedAge = @MinAge,
                                        DefaultValidityLength = @DefaultValidityLength,
                                        ClassFees = @Fees
                                    WHERE LicenseClassID = @LicenseClassID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@LicenseClassID",SqlDbType.Int).Value = LicenseClassID;
                    command.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = ClassName;
                    command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar).Value = ClassDescription;
                    command.Parameters.Add("@MinAge", SqlDbType.TinyInt).Value = MinAge;
                    command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = DefaultValidityLength;
                    command.Parameters.Add("@Fees", SqlDbType.SmallMoney).Value = Fees;

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


    }
}
