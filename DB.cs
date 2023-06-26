using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreation
{
    internal class DB
    {
        SqlConnection cfx = new SqlConnection();
        public DB() 
        {
            try
            {
                if(cfx.State == System.Data.ConnectionState.Closed) 
                {
                    cfx.ConnectionString = ConfigurationManager.AppSettings["DbStringConnection"];
                    cfx.Open();
                }

            } 
            catch (Exception ex)
            {
                Console.WriteLine($"è stato riscontrato il seguente errore: {ex.Message}");
            }
        }

        public void GetEmployee()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                SqlCommand cmd = cfx.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                SqlDataReader dr = cmd.ExecuteReader();
                using(SqlDataReader reader = dr) 
                while (dr.Read())
                {
                    list.Add(new Employee()
                    {
                        Id = reader["Id"].ToString(),
                        FullName = reader["Fullname"].ToString(),
                        Role = reader["Role"].ToString(),
                        Job= reader["Job"].ToString()

                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"qualcosa è andato storto nella creazione del db : {ex.Message}");
            }
        }
    }
}
