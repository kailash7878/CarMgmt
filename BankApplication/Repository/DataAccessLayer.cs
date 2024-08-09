using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CarMgmt.Repository
{
    public class DataAccessLayer : IDataAccessLayer
    {
        IConfiguration _configuration;

        public DataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ExecuteNonQuery(string SpName, List<SqlParameter> parameters)
        {
            using (var _conn = new SqlConnection(_configuration.GetConnectionString("connString")))
            {
                SqlTransaction _transaction = null;
                try
                {
                    if (_conn.State != ConnectionState.Open)
                    {
                        _conn.Open();
                    }
                    _transaction = _conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand(SpName, _conn, _transaction))
                    {
                        if (parameters.Any())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(parameters);
                            cmd.ExecuteNonQuery();
                            _transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw;
                }
                finally
                {
                    parameters.Clear();
                    _conn.Close();
                }
            }        
        }


        public DataTable GetData(string SpName, List<SqlParameter> parameters)
        {
            DataTable dt = new DataTable();
            using (var _conn = new SqlConnection(_configuration.GetConnectionString("connString")))
            {
                try
                {
                    if (_conn.State != System.Data.ConnectionState.Open)
                    {
                        _conn.Open();
                    }                    
                    using (SqlCommand cmd = new SqlCommand(SpName, _conn))
                    {
                        if (parameters.Any())
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(parameters);
                            cmd.ExecuteNonQuery();
                        }
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
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

                return dt;
            }
        }
    }
}
