using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace task9_1
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

        public void Insert((Employee, List<Vacation>) pair)
        {
            string sqlEmployee = string.Format("Insert Into Employee" + "(Id, Email, FirstName, LastName) Values(@Id, @Email, @FirstName, @LastName)");

            using (SqlCommand cmd = new SqlCommand(sqlEmployee, this.connect))
            {
                cmd.Parameters.AddWithValue("@Id", pair.Item1.Id);
                cmd.Parameters.AddWithValue("@Email", pair.Item1.Email);
                cmd.Parameters.AddWithValue("@FirstName", pair.Item1.FirstName);
                cmd.Parameters.AddWithValue("@LastName", pair.Item1.LastName);
                cmd.ExecuteNonQuery();
            }

            string sqlVacation = string.Format("Insert Into Vacation" + "(Id, StartDate, EndDate) Values(@Id, @StartDate, @EndDate)");
            string sql = string.Format("Insert Into EmployeeVacation" + "(EmployeeId, VacationId) Values(@EmployeeId, @VacationId)");

            foreach (var vacation in pair.Item2)
            {
                using (SqlCommand cmd = new SqlCommand(sqlVacation, this.connect))
                {
                    cmd.Parameters.AddWithValue("@Id", vacation.Id);
                    cmd.Parameters.AddWithValue("@StartDate", vacation.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", vacation.EndDate);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", pair.Item1.Id);
                    cmd.Parameters.AddWithValue("@VacationId", vacation.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Clear()
        {
            using (SqlCommand cmd = new SqlCommand("Delete from Employee", this.connect))
            {
                cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmd = new SqlCommand("Delete from Vacation", this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void CloseConnection()
        {
            connect.Close();
        }
    }
}
