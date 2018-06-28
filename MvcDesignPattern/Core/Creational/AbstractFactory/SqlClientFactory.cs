using System.Data.Common;
using System.Data.SqlClient;

namespace MvcDesignPattern.Core
{
    public class SqlClientFactory : IDatabaseFactory
    {
        public DbConnection GetConnection()
        {
            return new SqlConnection();
        }

        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public DbParameter GetParameter()
        {
            return new SqlParameter();
        }

    }
}
