using System.Data;
using System.Data.SqlClient;

namespace CarMgmt.Repository
{
    public interface IDataAccessLayer
    {
        void ExecuteNonQuery(string SpName, List<SqlParameter> parameters);
        DataTable GetData(string SpName, List<SqlParameter> parameters);
    }
}
