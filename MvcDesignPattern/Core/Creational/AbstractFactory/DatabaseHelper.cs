using System.Data;
using System.Data.Common;

namespace MvcDesignPattern.Core
{
    public class DatabaseHelper
    {
        private IDatabaseFactory _factory;

        public DatabaseHelper(IDatabaseFactory factory)
        {
            _factory = factory;
        }

        public DbDataReader ExecuteSelect(string query)
        {
            var cnn = _factory.GetConnection();
            cnn.ConnectionString = AppSettings.ConnectionString;
            var cmd = _factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cnn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DbDataReader ExecuteSelect(string query, DbParameter[] parameters)
        {
            var cnn = _factory.GetConnection();
            cnn.ConnectionString = AppSettings.ConnectionString;
            var cmd = _factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(parameters);
            cnn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteAction(string query)
        {
            var cnn = _factory.GetConnection();
            cnn.ConnectionString = AppSettings.ConnectionString;
            var cmd = _factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }

        public int ExecuteAction(string query, DbParameter[] parameters)
        {
            var cnn = _factory.GetConnection();
            cnn.ConnectionString = AppSettings.ConnectionString;
            var cmd = _factory.GetCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddRange(parameters);
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }
    }
}
