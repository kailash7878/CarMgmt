using Microsoft.Data.SqlClient;
using System.Data;

namespace CarMgmt.Repository
{
    public interface IDataAccessLayer
    {
        void ExecuteNonQuery(string SpName, List<SqlParameter> parameters);
        DataTable GetData(string SpName, List<SqlParameter> parameters);
    }
}
