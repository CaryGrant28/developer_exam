using System.Data;
using System.Data.SqlClient;

namespace Developer_Exam.Helpers.DataAccess
{
    public static class MSSQL
    {
        #region DataSet

        public static DataSet GetDataSet(
           string commandText,
           CommandType commandType,
           string connectionString,
           params SqlParameter[] parameters)
        {
            return GetDataSet(commandText, commandType, connectionString, "dataSet1", 30, parameters);
        }

        public static DataSet GetDataSet(
            string commandText,
            CommandType commandType,
            string connectionString,
            int commandTimeout,
            params SqlParameter[] parameters)
        {
            return GetDataSet(commandText, commandType, connectionString, "dataSet1", commandTimeout, parameters);
        }

        public static DataSet GetDataSet(
            string commandText,
            CommandType commandType,
            string connectionString,
            string dataSetName,
            int CommandTimeout,
            params SqlParameter[] parameters)
        {
            SqlConnection Con = new SqlConnection(connectionString);
            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            SqlCommand Command = new SqlCommand(commandText);
            DataSet ReturnDataSet = new DataSet(dataSetName);
            Con.Open();
            Command.Connection = Con;
            Command.CommandType = commandType;
            Command.CommandTimeout = CommandTimeout;
            Command.Parameters.AddRange(parameters);
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ReturnDataSet);
            Con.Close();

            if (DataAdapter != null)
                DataAdapter.Dispose();

            if (Command != null)
                Command.Dispose();

            if (Con != null)
                Con.Dispose();

            return ReturnDataSet;
        }

        #endregion

        #region DataTable

        public static DataTable GetDataTable(
            string commandText,
            CommandType commandType,
            string connectionString,
            params SqlParameter[] parameters)
        {
            return GetDataTable(commandText, commandType, connectionString, "table1", parameters);
        }

        public static DataTable GetDataTable(
            string commandText,
            CommandType commandType,
            string connectionString,
            string tableName,
            params SqlParameter[] parameters)
        {
            SqlConnection Con = new SqlConnection(connectionString);
            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            SqlCommand Command = new SqlCommand(commandText);
            DataTable ReturnDataTable = new DataTable(tableName);

            Con.Open();

            Command.Connection = Con;
            Command.CommandType = commandType;

            if (parameters != null)
                Command.Parameters.AddRange(parameters);

            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ReturnDataTable);

            Con.Close();

            if (DataAdapter != null)
                DataAdapter.Dispose();

            if (Command != null)
                Command.Dispose();

            if (Con != null)
                Con.Dispose();

            return ReturnDataTable;
        }

        #endregion

        #region ExecuteCommand
        public static int ExecuteCommand(
            string commandText,
            CommandType commandType,
            string connectionString,
            params SqlParameter[] parameters)
        {
            return ExecuteCommand(commandText, commandType, connectionString, 30, parameters);
        }

        public static int ExecuteCommand(
            string commandText,
            CommandType commandType,
            string connectionString,
            int connectionTimeout,
            params SqlParameter[] parameters)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command = new SqlCommand(commandText);
            Connection.Open();
            Command.Connection = Connection;
            Command.CommandType = commandType;
            Command.CommandTimeout = connectionTimeout;
            Command.Parameters.AddRange(parameters);
            int RecordsAffected = Command.ExecuteNonQuery();
            Connection.Close();

            if (Connection != null)
                Connection.Dispose();

            if (Command != null)
                Command.Dispose();

            return RecordsAffected;
        }

        #endregion

        #region Scalar
        public static T ExecuteScalar<T>(
            string commandText,
            CommandType commandType,
            string connectionString,
            params SqlParameter[] parameters)
        {

            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();

                SqlCommand Command = Connection.CreateCommand();
                Command.CommandText = commandText;
                Command.Connection = Connection;
                Command.CommandType = commandType;
                Command.Parameters.AddRange(parameters);

                T returnObject = (T)Command.ExecuteScalar();

                if (Command != null)
                    Command.Dispose();

                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }

                return returnObject;
            }

            #endregion
        }

    }
}
