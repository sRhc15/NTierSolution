using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataManagement.model;

namespace DataManagement.access
{
    public class DBManager
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-367IV5TH\\SQLEXPRESS;Initial Catalog=school;MultipleActiveResultSets=true;Integrated Security=True");
        
        public Response openConnection()
        {
            Response response = new Response();

            try
            {
                connection.Open();
                response.success = true;
                response.message = "DB connection open";
            }
            catch (SqlException ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public Response closeConnection()
        {
            Response response = new Response();

            try
            {
                connection.Close();
                response.success = true;
                response.message = "DB connection closed";
            }
            catch (SqlException ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }

        public Response insertNewStudent(String identifier, String firstName, String lastName)
        {
            Response response = new Response();
            try
            {
                String check_id = "SELECT identifier FROM Student WHERE identifier='"+identifier+"'";
                SqlCommand cmd = new SqlCommand(check_id, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (identifier.Equals(""))
                {
                    response.success = false;
                    response.message = "Debe ingresar un Carnet para poder registrarse";
                }
                else if (reader.HasRows)
                {
                    response.success = false;
                    response.message = "Este Carnet ya ha sido registrado, por favor ingrese otro Carnet";
                }
                else { 
                    String query = "INSERT INTO Student (identifier, first_name, last_name) VALUES (@identifier, @firstName, @lastName)";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@identifier", identifier);
                    sqlCommand.Parameters.AddWithValue("@firstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", lastName);

                    sqlCommand.ExecuteNonQuery();

                    response.success = true;
                    response.message = "Estudiante creado con exito!";
                } 
            }
            catch (SqlException ex)
            {
                response.success = false;
                response.message = ex.Message;
            }

            return response;
        }
    }
}
