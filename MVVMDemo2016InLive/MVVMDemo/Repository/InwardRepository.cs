using Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InwardRepository
    {
        public Int64 saveInward(IEnumerable<InwardDetail> inward)
        {

            DataTable table = new DataTable();
            table.Columns.Add("InwardDetailId", typeof(Int64));
            
            table.Columns.Add("ProductId", typeof(int));
            
            
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("BillDate", typeof(DateTime));

            foreach (var inw in inward)
            {


                table.Rows.Add(
                        inw.InwardDetailId,
                        inw.ProductId,
                        inw.Quantity,
                        inw.Dated
                        );

            }


            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaster");
            //SqlParameter parameter = new SqlParameter();
            ////The parameter for the SP must be of SqlDbType.Structured
            //parameter.ParameterName = "@tvp";
            ////parameter.SqlDbType = System.Data.SqlDbType.Structured;

            //parameter.TypeName = "dbo.OrderDetailTableType";
            //parameter.Value = table;
            //parameter.SqlDbType = SqlDbType.Structured;
            //DbCommand dbCommand = db.GetStoredProcCommand("sp_OrderDetail");
            Int64 outputParam;
            using (SqlConnection sqlConnection = (SqlConnection)db.CreateConnection())
            {
                // Define a command object for calling the stored procedure.
                // Note: The Parameters collection of the SqlCommand object automatically assigns the
                // DbType property of each parameter to Object, and the SqlDbType property to Structured.
                //
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_InwardDetail";
                sqlCommand.Parameters.AddWithValue("@tvp", table);

                SqlParameter OutputParam = new SqlParameter("@O_InwardNo", SqlDbType.BigInt);
                OutputParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(OutputParam);

                // Open the connection, execute the command and close the connection.
                //
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.ExecuteNonQuery();
                var str = sqlCommand.Parameters["@O_InwardNo"].Value;
                outputParam = Convert.ToInt64(str);

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }
            }

            return outputParam;
        }

        public static implicit operator InwardRepository(OrderRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
