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
    public class CustomerRepository
    {
        public IEnumerable<Customer> getCustomerList()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            string sql = "select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone, TotalRewardsPoints , ConsumedRewardsPoints, LeftRewardsPoints, CreatedOn from customermaster";
            var customers = db.ExecuteSqlStringAccessor<Customer>(sql);


            return customers;


        }

        public int saveCustomer(Customer customer, string operation)
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
                sqlCommand.CommandText = "sp_SaveCustomer";

                SqlParameter p_OperationFlag = new SqlParameter("@p_OperationFlag ", SqlDbType.VarChar, 1);
                p_OperationFlag.Direction = ParameterDirection.Input;
                p_OperationFlag.Value = operation;
                sqlCommand.Parameters.Add(p_OperationFlag);


                SqlParameter p_CustomerId = new SqlParameter("@p_customerId ", SqlDbType.BigInt);
                p_CustomerId.Direction = ParameterDirection.Input;
                p_CustomerId.Value = customer.CustID;
                sqlCommand.Parameters.Add(p_CustomerId);

                SqlParameter p_CustomerName = new SqlParameter("@p_customerName ", SqlDbType.VarChar, 200);
                p_CustomerName.Direction = ParameterDirection.Input;
                p_CustomerName.Value = customer.Name;
                sqlCommand.Parameters.Add(p_CustomerName);

                SqlParameter p_CustomerAddress = new SqlParameter("@p_customerAddress", SqlDbType.VarChar, 500);
                p_CustomerAddress.Direction = ParameterDirection.Input;
                p_CustomerAddress.Value = customer.Address;
                sqlCommand.Parameters.Add(p_CustomerAddress);

                //SqlParameter P_productDescripton = new SqlParameter("@productDescripton ", SqlDbType.VarChar, 200);
                //P_productDescripton.Direction = ParameterDirection.Input;
                //p_ProductName.Value = product.Description;
                //sqlCommand.Parameters.Add(P_productDescripton);

                SqlParameter p_ItemBarCodeId = new SqlParameter("@p_BarCodeId", SqlDbType.BigInt);
                p_ItemBarCodeId.Direction = ParameterDirection.Input;
                p_ItemBarCodeId.Value = customer.Customer_barcode;
                sqlCommand.Parameters.Add(p_ItemBarCodeId);


                SqlParameter p_MobileNo1 = new SqlParameter("@p_MobileNo", SqlDbType.BigInt);
                p_MobileNo1.Direction = ParameterDirection.Input;
                p_MobileNo1.Value = customer.Phone;
                sqlCommand.Parameters.Add(p_MobileNo1);


                SqlParameter OutputParam = new SqlParameter("@O_CustomerIdOut", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(OutputParam);


                // Open the connection, execute the command and close the connection.
                //
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.ExecuteNonQuery();

                var out_CustomerId = sqlCommand.Parameters["@O_CustomerIdOut"].Value;
                outputParam = Convert.ToInt32(out_CustomerId);

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }

            }
            return outputParam;
        }

        public IEnumerable<Customer> getCustomerByName(string customerSearchCriteria)
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            string sql = "select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone, TotalRewardsPoints , ConsumedRewardsPoints, LeftRewardsPoints, CreatedOn from customermaster where Name like '%" + customerSearchCriteria + "%'";
            var customers = db.ExecuteSqlStringAccessor<Customer>(sql);


            return customers;
        }
        
    }
}
