using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace specific_test_bootcamp.Pages.Clients
{
    public class createModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public string error = "";
        public string success = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        { 
            //Receving the data from form
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];
            clientInfo.phone = Request.Form["phone"];
            clientInfo.address = Request.Form["address"];
            
            if(clientInfo.name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.phone.Length == 0 || clientInfo.address.Length == 0)
            {
                error = "Preencha todos os campos";
                return;
            }

            //Saving the data from form
            try
            {
                string connectionDB = "Data Source=.\\sqlexpress;Initial Catalog=dbstore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionDB))
                {
                    connection.Open();
                    string sql = "INSERT INTO clients " +
                                 "(name, email, phone, address) VALUES " +
                                 "(@name, @email, @phone, @address);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@phone", clientInfo.phone);
                        command.Parameters.AddWithValue("@address", clientInfo.address);

                        command.ExecuteNonQuery();  
                    }
                }
            } catch (Exception ex)
            {
                error = ex.Message;
                return;
            }
            clientInfo.name = "";
            clientInfo.email = "";
            clientInfo.phone = "";
            clientInfo.address = "";
            success = "Cadastro feito com Sucesso!";

            //Redirect User after create a client
            Response.Redirect("/Clients/Index");
        }
    }
}
