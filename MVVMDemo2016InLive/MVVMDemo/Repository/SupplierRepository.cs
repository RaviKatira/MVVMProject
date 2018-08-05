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
    public class SupplierRepository
    {
        public IEnumerable<Supplier> getSuppliers()
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            var supplierInfo = db.ExecuteSqlStringAccessor<Supplier>("SELECT SupplierId, Name as SupplierName, IsActive FROM Supplier");


            return supplierInfo;
        }

        public int saveSupplier(Supplier supplier, string operation)
        {

            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");

            int outputParam;
            using (SqlConnection sqlConnection = (SqlConnection)db.CreateConnection())
            {
                // Define a command object for calling the stored procedure.
                // Note: The Parameters collection of the SqlCommand object automatically assigns the
                // DbType property of each parameter to Object, and the SqlDbType property to Structured.
                //
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_SaveSupplier";

                SqlParameter p_OperationFlag = new SqlParameter("@p_OperationFlag ", SqlDbType.VarChar, 1);
                p_OperationFlag.Direction = ParameterDirection.Input;
                p_OperationFlag.Value = operation;
                sqlCommand.Parameters.Add(p_OperationFlag);


                SqlParameter p_SupplierId = new SqlParameter("@p_supplierId ", SqlDbType.BigInt);
                p_SupplierId.Direction = ParameterDirection.Input;
                p_SupplierId.Value = supplier.SupplierId;
                sqlCommand.Parameters.Add(p_SupplierId);

                SqlParameter p_SupplierName = new SqlParameter("@p_supplierName ", SqlDbType.VarChar, 200);
                p_SupplierName.Direction = ParameterDirection.Input;
                p_SupplierName.Value = supplier.SupplierName;
                sqlCommand.Parameters.Add(p_SupplierName);

                SqlParameter p_IsActive = new SqlParameter("@p_IsActive", SqlDbType.Bit);
                p_IsActive.Direction = ParameterDirection.Input;
                p_IsActive.Value = supplier.IsActive;
                sqlCommand.Parameters.Add(p_IsActive);

                SqlParameter OutputParam = new SqlParameter("@O_SupplierIdOut", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(OutputParam);


                // Open the connection, execute the command and close the connection.
                //
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.ExecuteNonQuery();

                var out_SupplierId = sqlCommand.Parameters["@O_SupplierIdOut"].Value;
                outputParam = Convert.ToInt32(out_SupplierId);

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }
            }
            return outputParam;
        }
    }
}
