using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Procad.DataAccess.Interfaces
{
    public interface IDataAccessService : IDisposable
    {
        #region Properties

        string DataBaseName
        {
            get;
            set;
        }

        bool IsTransactionOpen
        {
            get;
        }

        #endregion

        #region Methods

        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
        SqlDataReader ExecuteReader(string storedProcedure);
        SqlDataReader ExecuteReader(string storedProcedure, params SqlParameter[] parameters);
        SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters);
        void ExecuteNonQuery(string commandText);
        void ExecuteNonQuery(string commandText, params SqlParameter[] parameters);
        object ExecuteScalar(string commandText, params SqlParameter[] parameters);
        object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters);
        SqlParameter CreateParameter(string parameterName, object value);
        SqlParameter CreateParameter(string parameterName, object value, int size);
        SqlParameter CreateParameter(string parameterName, object value, SqlDbType type);
        SqlParameter CreateParameter(string parameterName, object value, SqlDbType type, int size);
        SqlParameter CreateParameter(string parameterName, SqlDbType type, ParameterDirection direction);
        SqlParameter CreateParameter(string parameterName, SqlDbType type, int size, ParameterDirection direction);
        SqlParameter CreateParameter(string parameterName, object value, SqlDbType type, int size, ParameterDirection direction);

        #endregion
    }
}