using ModelsLibrary;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ChatDAL.Data
{
    /// <summary>
    /// This class represent common data layer to connecting to common databases
    /// </summary>
    public class DbFactory
    {
        //This method returns a specific connection object
        //based on the value of a DataBaseProvider enum
        public static DbConnection GetConnecton(DataBaseProvider dataProvider)
        {
            DbConnection connection = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataBaseProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataBaseProvider.Odbc:
                    connection = new OdbcConnection();
                    break;
                default:
                    break;
            }
            return connection;
        }

        //This method returns a specific command object
        //based on the value of a DataBaseProvider enum
        public static DbCommand GetCommand(DataBaseProvider dataProvider)
        {
            DbCommand command = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    command = new SqlCommand();
                    break;
                case DataBaseProvider.OleDb:
                    command = new OleDbCommand();
                    break;
                case DataBaseProvider.Odbc:
                    command = new OdbcCommand();
                    break;
                case DataBaseProvider.None:
                    break;
                default:
                    break;
            }
            return command;
        }

        //This method returns a specific parameter object
        //based on the value of a DataBaseProvider enum
        public static DbParameter GetParameter(DataBaseProvider dataProvider)
        {
            DbParameter parameter = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    parameter = new SqlParameter();
                    break;
                case DataBaseProvider.OleDb:
                    parameter = new OleDbParameter();
                    break;
                case DataBaseProvider.Odbc:
                    parameter = new OdbcParameter();
                    break;
                default:
                    break;
            }
            return parameter;
        }

        //This method returns a specific adapter object
        //based on the value of a DataBaseProvider enum
        public static DbDataAdapter GetDataAdapter(DataBaseProvider dataProvider,string commandText,string connectionString)
        {
            DbDataAdapter adapter = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    adapter = new SqlDataAdapter(commandText,connectionString);
                    break;
                case DataBaseProvider.OleDb:
                    adapter = new OleDbDataAdapter(commandText, connectionString);
                    break;
                case DataBaseProvider.Odbc:
                    adapter = new OdbcDataAdapter(commandText, connectionString);
                    break;
                default:
                    break;
            }
            return adapter;
        }

        //This method returns a specific reader object
        //based on the value of a DataBaseProvider enum
        public static DbDataReader GetReader(DataBaseProvider dataProvider)
        {
            DbDataReader reader = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    reader = GetCommand(dataProvider).ExecuteReader();
                    break;
                case DataBaseProvider.OleDb:
                    break;
                case DataBaseProvider.Odbc:
                    break;
                case DataBaseProvider.None:
                    break;
                default:
                    break;
            }
            return reader;
        }

        //This method returns a specific commandbuilder object
        //based on the value of a DataBaseProvider enum
        public static DbCommandBuilder GetCommandBuilder(DataBaseProvider dataProvider,IDataAdapter adapter)
        {
            DbCommandBuilder commandBuilder = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    commandBuilder = new SqlCommandBuilder((SqlDataAdapter)adapter);
                    break;
                case DataBaseProvider.OleDb:
                    commandBuilder = new OleDbCommandBuilder((OleDbDataAdapter)adapter);
                    break;
                case DataBaseProvider.Odbc:
                    commandBuilder = new OdbcCommandBuilder((OdbcDataAdapter)adapter);
                    break;
                default:
                    break;
            }
            return commandBuilder;
        }

        //This method returns a specific connectionstringbuilder object
        //based on the value of a DataBaseProvider enum
        public static DbConnectionStringBuilder GetConnectionStringBuilder(DataBaseProvider dataProvider, string connectionString)
        {
            DbConnectionStringBuilder stringBuilder = null;
            switch (dataProvider)
            {
                case DataBaseProvider.SqlServer:
                    stringBuilder = new SqlConnectionStringBuilder(connectionString);
                    break;
                case DataBaseProvider.OleDb:
                    stringBuilder = new OleDbConnectionStringBuilder(connectionString);
                    break;
                case DataBaseProvider.Odbc:
                    stringBuilder = new OdbcConnectionStringBuilder(connectionString);
                    break;
                case DataBaseProvider.None:
                    break;
                default:
                    break;
            }
            return stringBuilder;
        }
    }
}
