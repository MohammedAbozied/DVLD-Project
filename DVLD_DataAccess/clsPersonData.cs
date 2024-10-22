using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccess
{
    public class clsPersonData
    {

        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
    ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
    ref byte Gendor, ref string Address, ref string Phone, ref string Email,
    ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    // ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    NationalNo = (string)reader["NationalNo"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    // Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    // ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
            ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)

        {
            bool is_found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) // we now needn't to handle close reader
                {
                    if (reader.Read())
                    {
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];

                        if (reader["ThirdName"] != DBNull.Value)
                            ThirdName = (string)reader["ThirdName"];
                        else
                            ThirdName = "";

                        LastName = (string)reader["LastName"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Gendor = (byte)reader["Gendor"];
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];

                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        NationalityCountryID = (int)reader["NationalityCountryID"];

                        if (reader["ImagePath"] != DBNull.Value)
                            ImagePath = (string)reader["ImagePath"];
                        else
                            ImagePath = "";

                        is_found = true;

                    }
                    else
                        is_found = false;

                }




            }
            catch (Exception ex)
            {
                is_found = false;
                Console.WriteLine("Error in getPersonInfo by nationalNo: " + ex.Message.ToString());

            }
            finally
            {
                connection.Close();
            }

            return is_found;
        }


        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
             string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address,
             string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO People VALUES(@NationalNo,@FirstName,@SecondName, 
                                @ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,
                                @Email,@NationalityCountryID,@ImagePath);
                             SELECT CAST(SCOPE_IDENTITY() AS int);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (!string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (!string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int newID))
                {
                    PersonID = newID;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in add new person: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }


        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
   string ThirdName, string LastName, DateTime DateOfBirth,
   short Gendor, string Address, string Phone, string Email,
    int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  People  
                    set FirstName = @FirstName,
                        SecondName = @SecondName,
                        ThirdName = @ThirdName,
                        LastName = @LastName, 
                        NationalNo = @NationalNo,
                        DateOfBirth = @DateOfBirth,
                        Gendor=@Gendor,
                        Address = @Address,  
                        Phone = @Phone,
                        Email = @Email, 
                        NationalityCountryID = @NationalityCountryID,
                        ImagePath =@ImagePath
                        where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            // Use Add instead of AddWithValue for more control over data types
            command.Parameters.Add(new SqlParameter("@PersonID", SqlDbType.Int) { Value = PersonID });
            command.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = FirstName });
            command.Parameters.Add(new SqlParameter("@SecondName", SqlDbType.NVarChar, 50) { Value = SecondName });

            // Handle ThirdName nullable
            command.Parameters.Add(new SqlParameter("@ThirdName", SqlDbType.NVarChar, 50)
            {
                Value = string.IsNullOrWhiteSpace(ThirdName) ? (object)DBNull.Value : ThirdName
            });

            command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = LastName });
            command.Parameters.Add(new SqlParameter("@NationalNo", SqlDbType.NVarChar, 20) { Value = NationalNo });
            command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = DateOfBirth });

            // Ensure correct type for Gendor
            command.Parameters.Add(new SqlParameter("@Gendor", SqlDbType.TinyInt) { Value = Gendor });

            command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 100) { Value = Address });
            command.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = Phone });

            // Handle Email nullable
            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100)
            {
                Value = string.IsNullOrWhiteSpace(Email) ? (object)DBNull.Value : Email
            });

            command.Parameters.Add(new SqlParameter("@NationalityCountryID", SqlDbType.Int) { Value = NationalityCountryID });

            // Handle ImagePath nullable
            command.Parameters.Add(new SqlParameter("@ImagePath", SqlDbType.NVarChar, 255)
            {
                Value = string.IsNullOrWhiteSpace(ImagePath) ? (object)DBNull.Value : ImagePath
            });

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (SqlException ex) // Specific exception handling
            {
                // Log exception or handle it properly
                return false;
            }
            finally
            {
                connection.Close();
            }

            // rowsAffected > 0 means update was successful
            return rowsAffected > 0;
        }



        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                SELECT 
                    People.PersonID, 
                    People.NationalNo, 
                    People.FirstName, 
                    People.SecondName, 
                    People.ThirdName, 
                    People.LastName, 
                    People.DateOfBirth,
                    People.Gendor,
                    CASE
                        WHEN People.Gendor = 0 THEN 'Male'
                        ELSE 'Female'
                    END AS GendorCaption,
                    People.Address,
                    People.Phone, 
                    People.Email, 
                    People.NationalityCountryID, 
                    Countries.CountryName,
                    People.ImagePath
                FROM 
                    People 
                INNER JOIN 
                    Countries ON People.NationalityCountryID = Countries.CountryID
                ORDER BY 
                    People.FirstName";

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
                Console.WriteLine("Error in getAllPeople method..." + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeletePerson(int PersonID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in deletePerson method: " + ex.Message.ToString());
            }
            finally
            {
                connection.Close();
            }

            return rowAffected > 0;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool is_found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PersonID FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    is_found = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in IsPersonExist() method: " + ex.Message.ToString());
                is_found = false;
            }
            finally
            {
                connection.Close();
            }

            return is_found;

        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool is_found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PersonID FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    is_found = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in IsPersonExist() method: " + ex.Message.ToString());
                is_found = false;
            }
            finally
            {
                connection.Close();
            }

            return is_found;

        }


    }




}
