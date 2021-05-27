using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace WebSklad2
{
    public class sqlRead
    {
        static SqlConnection connection = new SqlConnection();
        static SqlConnection connectionUGES = new SqlConnection();
        static string error;

        //public sqlRead()
        //{

        //}

        public void openConnection()
        {
            if (connection.State.ToString() != "Open")
            {
                try
                {
                    connection.ConnectionString = WebConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                }
            }
        }

        public void closeConnection()
        {
            if (connection.State.ToString() == "Open")
            {
                try
                {
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                }
            }
        }

        public void openConnectionUGES()
        {
            if (connectionUGES.State.ToString() != "Open")
            {
                try
                {
                    connectionUGES.ConnectionString = WebConfigurationManager.ConnectionStrings["DataConnectionUGES"].ConnectionString;
                    connectionUGES.Open();
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                }
            }
        }

        public void closeConnectionUGES()
        {
            if (connectionUGES.State.ToString() == "Open")
            {
                try
                {
                    connectionUGES.Close();
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                }
            }
        }

        public string getState()
        {
            return connection.State.ToString();
        }

        public DataTable getDataByQuery(string sqlQuery, bool NumberCol)
        {
            openConnection();
            DataSet data = new DataSet();
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            DataTable table = new DataTable();
            if (NumberCol)
                table.Columns.Add("#");
            table.Load(command.ExecuteReader());
            if (NumberCol)
            {
                int j = 1;
                foreach (DataRow r in table.Rows)
                {
                    r[0] = j;
                    j++;
                }
            }
            //table.Dispose();
            return table;
        }

        public DataTable GetDataBySP(string[] SPcommand, bool NumberCol)
        {
            openConnection();
            //DataSet data = new DataSet();
            
            SqlCommand command = new SqlCommand(SPcommand[0], connection);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < (SPcommand.Length); i+=2)
            {
                if (SPcommand[i + 1] != string.Empty)
                    command.Parameters.AddWithValue(SPcommand[i], SPcommand[i + 1]);
                else
                    command.Parameters.AddWithValue(SPcommand[i], DBNull.Value);
            }
            DataTable table = new DataTable();
            if(NumberCol)
                table.Columns.Add("#");
            table.Load(command.ExecuteReader());
            if (NumberCol)
            {
                int j = 1;
                foreach (DataRow r in table.Rows)
                {
                    r[0] = j;
                    j++;
                }
            }
            return table;
        }

        public DataTable GetDataBySPUGES(string[] SPcommand, bool NumberCol)
        {
            openConnectionUGES();
            //DataSet data = new DataSet();

            SqlCommand command = new SqlCommand(SPcommand[0], connectionUGES);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < (SPcommand.Length); i += 2)
            {
                if (SPcommand[i + 1] != string.Empty)
                    command.Parameters.AddWithValue(SPcommand[i], SPcommand[i + 1]);
                else
                    command.Parameters.AddWithValue(SPcommand[i], DBNull.Value);
            }
            DataTable table = new DataTable();
            if (NumberCol)
                table.Columns.Add("#");
            table.Load(command.ExecuteReader());
            if (NumberCol)
            {
                int j = 1;
                foreach (DataRow r in table.Rows)
                {
                    r[0] = j;
                    j++;
                }
            }
            return table;
        }

        public string getValue(string sqlQuery)
        {
            openConnection();
            string result = string.Empty;
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               result = reader[0].ToString();
            }
            reader.Close();
            return result;
        }

        public string getValueUGES(string sqlQuery)
        {
            openConnectionUGES();
            string result = string.Empty;
            SqlCommand command = new SqlCommand(sqlQuery, connectionUGES);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            reader.Close();
            return result;
        }

        public string[] parseString(string input)
        {
            string[] result = new string[2];
            Regex regex = new Regex(@"\d\w*");

            MatchCollection matches = regex.Matches(input);
            if (matches.Count > 3)
            {
                result[0] = matches[2].Value + "-" + matches[1].Value + "-" + matches[0].Value;
                result[1] = matches[5].Value + "-" + matches[4].Value + "-" + matches[3].Value;
                return result;
            }
            if (matches.Count < 4)
            {
                result[0] = matches[2].Value + "-" + matches[1].Value + "-" + matches[0].Value;
                result[1] = string.Empty;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}