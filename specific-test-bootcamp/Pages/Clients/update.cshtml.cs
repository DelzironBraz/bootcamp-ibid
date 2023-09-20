using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace specific_test_bootcamp.Pages.Clients
{
    public class updateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string error = "";
        public string success = "";
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionDB = "Data Source=.\\sqlexpress;Initial Catalog=dbstore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            //Receving the data from form
            clientInfo.id = Request.Form["id"];
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];

            if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                error = "Preencha todos os campos";
                return;
            }

            try
            {
                string connectionDB = "Data Source=.\\sqlexpress;Initial Catalog=dbstore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    connection.Open();
                    string sql = "UPDATE clients " +
                                 "SET name=@name, email=@email, phone=@phone, address=@address " +
                                 "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientInfo.id);
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return;
            }
            success = "Cliente Atualizado com Sucesso!";

            //Redirect User after create a client
            Response.Redirect("/Clients/Index");
        }
    }
}
