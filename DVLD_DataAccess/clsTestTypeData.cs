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
    public class clsTestTypeData
    {

        public static bool GetTestTypeInfo(int ID,ref string Title,
            ref string Description,ref float Fees)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestTypes 
                                    WHERE TestTypeID = @TestTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", ID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {

                                Title = (string)reader["TestTypeTitle"];
                                Description = (string)reader["TestTypeDescription"];
                                Fees = Convert.ToSingle(reader["TestTypeFees"]);
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


        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypes";

                using( SqlCommand command = new SqlCommand(query,connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }

            }

            return dt;
        }


        public static int AddNewTestType(string Title,string Description,float Fees)
        {
            int newID = -1;

            using(SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO 
                                    TestTypes(TestTypeTitle, TestTypeDescription, TestTypeFees)
                                    VALUES(@Title,@Description,@Fees);
                                    SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);

                    try
                    {
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(),out int id))
                        {
                            newID = id;
                        }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            
            return newID;
        }


        public static bool UpdateTestType(int ID, string Title, string Description, float Fees)
        {
            int AffectedRows = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE TestTypes
                                    SET TestTypeTitle = @Title,
                                        TestTypeDescription = @Description,
                                        TestTypeFees = @Fees
                                    WHERE TestTypeID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Fees", Fees);
                    command.Parameters.AddWithValue("@ID", ID);

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
