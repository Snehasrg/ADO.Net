using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNetDemo
{
    public class Customer
    {
        public static void CreateDatabase()
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            try
            {
                //writing sql query
                string query = "create database SampleDB287";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Database created successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { 
                con.Close();
            }
        }
        public static SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB; initial catalog=SampleDB287; integrated security=true");
        public static void CreateTable()
        {
            try
            {
                //writing sql query
                string query = "create table CustomerData(Id int identity(1,1)primary key, Name varchar(200), City varchar(200)) ";
                SqlCommand cm = new SqlCommand(query, con); //we can pass store procedure, query,cant inherit this class

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Table created successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        public static void InsertTable()
        {
            try
            {
                //writing sql query
                string query = " insert into CustomerData values ('priya','Mumbai',9420202020),('Priti','shrinagar',8667676767)";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Data inserted successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void UpdateTable()
        {
            try
            {
                //writing sql query
                string query = " update CustomerData set Phone_Number=9999999999 where Name='Priya' ";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Data Updated successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void DeleteTable()
        {
            try
            {
                //writing sql query
                string query = " Drop table CustomerData ";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Table Deleted successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void AlterTable()
        {
            try
            {
                //writing sql query
                string query = " Alter table CustomerData add Phone_Number bigint";
                SqlCommand cm = new SqlCommand(query, con);

                //opening connection
                con.Open();

                //Executing sql query
                cm.ExecuteNonQuery();

                //Displaying message
                Console.WriteLine("Data Altered successfully");
                Console.WriteLine("------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool Display()
        {
            try
            {
                using (con)
                {
                    CustomerMode model = new CustomerMode();
                    string query = "select * from CustomerData";
                    SqlCommand command = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("---------Data------");
                        while (sqlDataReader.Read())
                        {
                            model.Id = Convert.ToInt32(sqlDataReader["ID"]);
                            model.Name = Convert.ToString(sqlDataReader["Name"]);
                            model.City = Convert.ToString(sqlDataReader["city"]);
                            model.Phone_Number = (int)Convert.ToInt64(sqlDataReader["Phone_Number"]);
                            //Console.WriteLine(" Id: " + model.Id + " Name: " + model.Name + " City: " + model.City + " Phone_Number: " + model.Phone_Number);
                            Console.WriteLine("Id: {0}\nName: {1}\nCity: {2}\nPhoneNumber: {3}", model.Id, model.Name, model.City, model.Phone_Number);

                        }
                    }
                    return true;
                }
                //return false;
            }
            catch (Exception ex) { 
           
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public bool InsertStoreProcedure(CustomerMode model)
        {
            try
            {
                using(con)
                {
                    SqlCommand cmd = new SqlCommand("Sp_insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;//executing store procedure
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@City", model.City);
                    cmd.Parameters.AddWithValue("@Phone_Number", model.Phone_Number);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully");
                    Console.WriteLine("----------------------");
                    if(result != 0 )
                    {
                        return true;
                    }
                    //return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("something went wrong" +e);
            }
            //closing connection
            finally 
            { 
                con.Close();
            }
            return false;
        }

        public bool DisplayStoreProcedure(CustomerMode model)
        {
            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("sp_display", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    con.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("---------Data------");
                        while (sqlDataReader.Read())
                        {
                            model.Id = Convert.ToInt32(sqlDataReader["ID"]);
                            model.Name = Convert.ToString(sqlDataReader["Name"]);
                            model.City = Convert.ToString(sqlDataReader["city"]);
                            model.Phone_Number = (int)Convert.ToInt64(sqlDataReader["Phone_Number"]);
                            Console.WriteLine("Id: {0}\nName: {1}\nCity: {2}\nPhoneNumber: {3}"
                                              , model.Id, model.Name, model.City, model.Phone_Number);
                        }
                    }
                    return true;
                }
                //return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}
