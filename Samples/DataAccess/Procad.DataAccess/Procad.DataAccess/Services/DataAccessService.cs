using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Procad.DataAccess.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Procad.DataAccess.Services
{
    public class DataAccessService : IDataAccessService
    {
        #region Constructor

        public DataAccessService()
        {

        }

        #endregion

        #region Private Fields

        private SqlTransaction m_transaction = null;

        private SqlConnection m_connection = null;
        private SqlConnection Connection
        {
            get
            {
                if (this.m_connection == null) this.m_connection = this.GetConnection();
                return this.m_connection;
            }
        }

        #endregion

        #region Public Properties

        private string m_dataBaseName = "procadCorporeRM";
        public string DataBaseName
        {
            get
            {
                return this.m_dataBaseName;
            }
            set
            {
                if (string.Compare(this.m_dataBaseName, value, true) == 0) return;
                this.m_dataBaseName = value;
            }
        }

        public bool IsTransactionOpen
        {
            get
            {
                return this.m_transaction == null ? false : true;
            }
        }

        #endregion

        #region Public Methods

        public void BeginTransaction()
        {
            this.OpenConnection();
            this.m_transaction = this.Connection.BeginTransaction();
        }

        public void RollBackTransaction()
        {
            if (this.m_transaction == null) return;
            this.EndTransaction(false);
        }

        public void CommitTransaction()
        {
            if (this.m_transaction == null) return;
            this.EndTransaction(true);
        }

        public SqlDataReader ExecuteReader(string storedProcedure)
        {
            return this.ExecuteReader(storedProcedure, null);
        }
        public SqlDataReader ExecuteReader(string storedProcedure, params SqlParameter[] parameters)
        {
            return this.ExecuteReader(storedProcedure, CommandType.StoredProcedure, parameters);
        }
        public SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlCommand sqlCommand = this.GetSqlCommand(commandText, commandType, parameters);
            return sqlCommand.ExecuteReader();
        }

        public void ExecuteNonQuery(string commandText)
        {
            this.ExecuteNonQuery(commandText, null);
        }
        public void ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand sqlCommand = this.GetSqlCommand(commandText, CommandType.StoredProcedure, parameters);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (this.m_transaction == null) this.CloseConnection();
            }
        }

        public object ExecuteScalar(string commandText, params SqlParameter[] parameters)
        {
            return this.ExecuteScalar(commandText, CommandType.StoredProcedure, parameters);
        }
        public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand sqlCommand = this.GetSqlCommand(commandText, commandType, parameters);
                return sqlCommand.ExecuteScalar();
            }
            finally
            {
                if (this.m_transaction == null) this.CloseConnection();
            }
        }

        public SqlParameter CreateParameter(string parameterName, object value)
        {
            return this.CreateParameter(parameterName, value, SqlDbType.VarChar);
        }
        public SqlParameter CreateParameter(string parameterName, object value, int size)
        {
            return this.CreateParameter(parameterName, value, SqlDbType.VarChar, size);
        }
        public SqlParameter CreateParameter(string parameterName, object value, SqlDbType type)
        {
            return this.CreateParameter(parameterName, value, type, 0);
        }
        public SqlParameter CreateParameter(string parameterName, object value, SqlDbType type, int size)
        {
            return this.CreateParameter(parameterName, value, type, size, ParameterDirection.Input);
        }
        public SqlParameter CreateParameter(string parameterName, SqlDbType type, ParameterDirection direction)
        {
            return this.CreateParameter(parameterName, type, 0, direction);
        }
        public SqlParameter CreateParameter(string parameterName, SqlDbType type, int size, ParameterDirection direction)
        {
            return this.CreateParameter(parameterName, null, type, size, direction);
        }
        public SqlParameter CreateParameter(string parameterName, object value, SqlDbType type, int size, ParameterDirection direction)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = type;
            parameter.Size = size;
            parameter.Value = value;
            parameter.ParameterName = parameterName;
            parameter.Direction = direction;
            return parameter;
        }

        #endregion

        #region Private Methods

        private SqlCommand GetSqlCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            this.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = commandText;
            sqlCommand.CommandType = commandType;
            sqlCommand.Connection = this.m_connection;
            sqlCommand.Transaction = this.m_transaction;
            sqlCommand.CommandTimeout = 300;

            if (parameters != null && parameters.Length > 0)
                foreach (SqlParameter parameter in parameters)
                    sqlCommand.Parameters.Add(parameter);

            sqlCommand.Prepare();

            return sqlCommand;
        }

        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString)) return null;
            return new SqlConnection(connectionString);
        }

        private void OpenConnection()
        {
            if (this.Connection == null) return;
            if (this.Connection.State == ConnectionState.Closed) this.Connection.Open();

            this.ChangeDataBase();
        }

        private void CloseConnection()
        {
            if (this.m_transaction != null) return;
            if (this.Connection == null) return;

            if (this.Connection.State == ConnectionState.Open) this.Connection.Close();
        }

        private void ChangeDataBase()
        {
            if (this.Connection == null) return;
            if (this.Connection.State != ConnectionState.Open) return;
            if (string.IsNullOrEmpty(this.DataBaseName)) throw new ArgumentNullException("DataBaseName:", "The property is null");

            string dataBase = ConfigurationManager.AppSettings[this.DataBaseName];
            if (string.IsNullOrEmpty(dataBase)) throw new ArgumentNullException("dataBase:", " it has not value to the key " + this.DataBaseName);

            if (string.Compare(this.Connection.Database, dataBase, true) == 0) return;

            this.Connection.ChangeDatabase(dataBase);
        }

        private void EndTransaction(bool commit)
        {
            if (commit)
            {
                this.m_transaction.Commit();
            }
            else
            {
                this.m_transaction.Rollback();
            }
            this.m_transaction = null;

            this.CloseConnection();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.DataBaseName = string.Empty;
            if (this.m_transaction != null) this.EndTransaction(false);
            else this.CloseConnection();
        }

        #endregion
    }
}
