using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {
        static public bool GetApplicationTypeInfoById(int ApplicationTypeID,
            ref string ApplicationTypeTitle, ref float ApplicationTypeFees)
        {

            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"SELECT * FROM ApplicationTypes 
                                    WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query ,connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeID",ApplicationTypeID );

                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationTypeFees = Convert.ToSingle(reader["ApplicationFees"]);
                                isFound = true;
                            }
                            else
                                isFound = false;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: "+ex.ToString());
                        isFound = false;

                    }
                }
            }

            return isFound;
        }

        static public DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        { 
                            dt.Load(reader);
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine ("error: "+ ex.ToString()); 
                    }
                }

            }

            return dt;
        }

        static public int AddNewApplicationType(string Title,float Fees)
        {
            int ID = -1;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO 
                                    ApplicationTypes(ApplicationTypeTitle,ApplicationFees)
                                 VALUES(@Title,@Fees);
                                 SELECT SCOPE_IDENTITY()";

                using(SqlCommand command = new SqlCommand (query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int newID))
                        {
                            ID = newID;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error: "+ex.ToString());   
                    }
                }

            }
            return ID;
        }

        static public bool UpdateApplicationType(int id,
            string title,float fees)
        {
            int AffectedRows = 0;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE ApplicationTypes
                                 SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                     ApplicationFees = @ApplicationFees
                                 WHERE ApplicationTypeID = @ApplicationTypeID";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID",id);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle",title);
                    command.Parameters.AddWithValue("@ApplicationFees", fees);

                    try
                    {
                        connection.Open();
                        AffectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine(ex.ToString()); 
                    }

                }


            }

            return AffectedRows > 0;
        }



    }





}
