using ModelsLibrary;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ChatDAL.Data
{
    /// <summary>
    /// This class represent common data provider to connect to database
    /// </summary>
    public class DataProvider
    {
        private DataBaseProvider _dataBaseProvider;
        private DbConnection _connecton;

        public DataProvider(DataBaseProvider dataProvider, string connectionString)
        {
            _dataBaseProvider = dataProvider;
            _connecton = DbFactory.GetConnecton(dataProvider);
            _connecton.ConnectionString = connectionString;
        }//c-tor

        public DbCommand CreateCommand(string commandText)
        {
            return CreateCommand(commandText, null, CommandType.StoredProcedure);
        }

        public DbCommand CreateCommand(string commandText, DbParameter[] parameters)
        {
            return CreateCommand(commandText, parameters, CommandType.StoredProcedure);
        }

        public DbCommand CreateCommand(string commandText, DbParameter[] parameters, CommandType commandType)
        {
            var cmd = DbFactory.GetCommand(_dataBaseProvider);
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            cmd.Connection = _connecton;
            if (parameters != null)
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            return cmd;
        }

        public object ExecuteScalar(string commandText, DbParameter[] parameters)
        {
            object result = null;

            try
            {
                var cmd = CreateCommand(commandText, parameters);
                _connecton.Open();
                result = cmd.ExecuteScalar();
                _connecton.Close();
            }
            catch (SqlException )
            {
                _connecton.Close();
                throw;
            }
            return result;
        }

        public int ExecuteNonQuery(string commandText, DbParameter[] parameters, CommandType commandType)
        {
            int result = 0;
            try
            {
                var cmd = CreateCommand(commandText, parameters, commandType);
                _connecton.Open();
                result = cmd.ExecuteNonQuery();
                _connecton.Close();
            }
            catch (Exception)
            {
                _connecton.Close();
                throw;
            }
            return result;
        }

        public int ExecuteNonQuery(string commandText, DbParameter[] parameters)
        {
            return ExecuteNonQuery(commandText, parameters, CommandType.StoredProcedure);
        }

        public DbDataReader ExecuteReader(string command, DbParameter[] parameters)
        {
            DbDataReader dataReader;

            var cmd = CreateCommand(command, parameters);
            _connecton.Open();
            dataReader = cmd.ExecuteReader();

            return dataReader;
        }

        internal DbDataReader ExecuteReader(string command, DbParameter[] parameters, CommandType text)
        {
            DbDataReader dataReader;
            var cmd = CreateCommand(command, parameters,text);
            _connecton.Open();
            dataReader = cmd.ExecuteReader();

            return dataReader;
        }

        public void CloseConnection()
        {
            _connecton.Close();
        }
    }
}
