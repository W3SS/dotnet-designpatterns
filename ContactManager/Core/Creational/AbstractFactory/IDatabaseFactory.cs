using System.Data.Common;

namespace ContactManager.Core
{
    public interface IDatabaseFactory
    {
        DbConnection GetConnection();
        DbCommand GetCommand();
        DbParameter GetParameter();
    }
}
