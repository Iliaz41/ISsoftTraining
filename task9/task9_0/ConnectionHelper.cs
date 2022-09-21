using Microsoft.Data.SqlClient;

namespace task9_0
{
    public class ConnectionHelper
    {
        private SqlConnection connect = null;
        private string connectionString;


        public ConnectionHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void OpenConnection()
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void Insert(Training training)
        {
            string sqlTraining = string.Format("Insert Into Training" + "(Id, Name, StartDate, EndDate, Description) Values(@Id, @Name, @StartDate, @EndDate, @Description)");

            using (SqlCommand cmd = new SqlCommand(sqlTraining, this.connect))
            {
                cmd.Parameters.AddWithValue("@Id", training.Id);
                cmd.Parameters.AddWithValue("@Name", training.Name);
                cmd.Parameters.AddWithValue("@StartDate", training.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", training.EndDate);
                cmd.Parameters.AddWithValue("@Description", training.Description);
                cmd.ExecuteNonQuery();
            }
        }    

        public void CloseConnection()
        {
            connect.Close();
        }
    }
}
