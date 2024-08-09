using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Data.SqlClient;

namespace CarMgmt.Repository
{
    public class DataAccessLayer
    {
        SqlConnection _conn;
        public void ExecuteNonQuery(string SpName, List<SqlParameter> parameters)
        {
            using (_conn = new SqlConnection(""))
            {
                try
                {
                    if (_conn.State != System.Data.ConnectionState.Open)
                    {
                        _conn.Open();
                    }
                    SqlTransaction transaction = _conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand(SpName, _conn, transaction))
                    {
                        if (parameters.Any())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(parameters);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _conn.Close();
                }
            }        
        }
    }
}
