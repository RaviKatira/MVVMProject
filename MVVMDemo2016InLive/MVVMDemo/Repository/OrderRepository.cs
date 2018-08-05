using Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.Common;

namespace Repository
{
    public class OrderRepository
    {
        public IEnumerable<PaymentMode> getPaymentModes()
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");

            string sql = "SELECT PaymentModeId      ,Mode        FROM [dbo].[PaymentMode] where IsActive=1 ";
            var paymentMode = db.ExecuteSqlStringAccessor<PaymentMode>(sql);

            return paymentMode;

        }

        public IEnumerable<Product> getProductList()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //string sql = "SELECT	C.SupplierId, c.Name SupplierName, ItemBarCodeId as barCodeId, ProductId as productId, A.name + REPLICATE('*', 56-len(A.name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice,  " +
            //" A.name as productName, 		SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            //" B.CategoryId as productVatCategoryId,	A.IsOffer as OfferOption,	case when A.IsOffer =1 then 'Yes' else 'No' end OfferOptionStr, A.IsActive as IsActive, B.VATRate , " +
            //" A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit, 0 as TotalAvailQty, null as LastInwardDate" +
            //" FROM ProductMaster A, ProductCategory B, Supplier C " +
            //" where A.IsActive = 1 and A.CategoryId = B.CategoryId and A.SupplierId = C.SupplierId order by A.Name asc";
            string sql = "SELECT	C.SupplierId, c.Name SupplierName, ItemBarCodeId as barCodeId, A.ProductId as productId, A.name + REPLICATE('*', 56-len(A.name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice, " +
            " A.name as productName, 		MRP, SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            " B.CategoryId as productVatCategoryId,	A.IsOffer as OfferOption,	case when A.IsOffer = 1 then 'Yes' else 'No' end OfferOptionStr, A.IsActive as IsActive, B.VATRate , " +
            " A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit, A.MRP - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) ProfitOnMRP, D.QuantityAvail as TotalAvailQty, D.LastInwardDate as LastInwardDate " +
            " FROM ProductMaster A, ProductCategory B, Supplier C , Stock D " +
            " where A.IsActive = 1 " +
            " and A.CategoryId = B.CategoryId and A.SupplierId = C.SupplierId " +
            " and A.ProductId = D.ProductId " +
            " order by A.Name asc";
            var products = db.ExecuteSqlStringAccessor<Product>(sql);

            //foreach (var product in products)
            //{



            //}
            return products;
            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;




        }

        public IEnumerable<Product> getAllProductList()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //string sql = "SELECT	ItemBarCodeId as barCodeId, ProductId as productId, name + REPLICATE('*', 56-len(name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice,  " +
            //" name as productName, 		SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            //" B.CategoryId as productVatCategoryId,		A.IsActive as IsActive, B.VATRate , " +
            //" A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit " +
            //" FROM ProductMaster A, ProductCategory B " +
            //" where A.CategoryId = B.CategoryId order by Name asc";
            string sql = "SELECT	C.SupplierId, c.Name SupplierName, ItemBarCodeId as barCodeId, A.ProductId as productId, A.name + REPLICATE('*', 56-len(A.name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice, " +
            " A.name as productName, 		MRP, SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            " B.CategoryId as productVatCategoryId,	A.IsOffer as OfferOption,	case when A.IsOffer = 1 then 'Yes' else 'No' end OfferOptionStr, A.IsActive as IsActive, B.VATRate , " +
            " A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit, A.MRP - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) ProfitOnMRP, D.QuantityAvail as TotalAvailQty, D.LastInwardDate as LastInwardDate " +
            " FROM ProductMaster A, ProductCategory B, Supplier C , Stock D " +
            " where A.CategoryId = B.CategoryId and A.SupplierId = C.SupplierId " +
            " and A.ProductId = D.ProductId " +
            " order by A.Name asc";
            var products = db.ExecuteSqlStringAccessor<Product>(sql);

            //foreach (var product in products)
            //{



            //}
            return products;
            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;




        }

        public IEnumerable<ProductTreatmentLink> getProductTreatementList()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //string sql = "SELECT	ItemBarCodeId as barCodeId, ProductId as productId, name + REPLICATE('*', 56-len(name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice,  " +
            //" name as productName, 		SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            //" B.CategoryId as productVatCategoryId,		A.IsActive as IsActive, B.VATRate , " +
            //" A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit " +
            //" FROM ProductMaster A, ProductCategory B " +
            //" where A.CategoryId = B.CategoryId order by Name asc";
            string sql = "SELECT A.ProductId, B.TreatmentId , C.TreatmentName " +
            " FROM ProductMaster A, ProductTreatementLink B, Treatment C " +
            " where A.ProductId = B.ProductId " +
            " and B.TreatmentId = C.TreatmentId ";


            var products = db.ExecuteSqlStringAccessor<ProductTreatmentLink>(sql);

            //foreach (var product in products)
            //{



            //}
            return products;
            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;




        }

        public IEnumerable<Supplier> getSuppliers()
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            var supplierInfo = db.ExecuteSqlStringAccessor<Supplier>("SELECT SupplierId, Name as SupplierName, IsActive FROM Supplier where IsActive=1");


            return supplierInfo;

        }

        public IEnumerable<Product> getProductLike(string productSearchCriteria, int SupplierId)
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            ////IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //string sql = "SELECT	ItemBarCodeId as barCodeId, ProductId as productId, name + REPLICATE('*', 56-len(name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice,  " +
            //" name as productName, 		SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            //" B.CategoryId as productVatCategoryId,		A.IsActive as IsActive, B.VATRate , " +
            //" A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit " +
            //" FROM ProductMaster A, ProductCategory B " +
            //" where A.CategoryId = B.CategoryId " +
            //" AND Name LIKE '%" + productSearchCriteria.Trim() + "%' " + 
            //" order by Name asc";
            //string sql = " SELECT	A.SupplierId, S.Name SupplierName, ItemBarCodeId as barCodeId, A.ProductId as productId, A.name + REPLICATE('*', 56-len(A.name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice, " +
            //            " A.name as productName, 		SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory , " +
            //            " B.CategoryId as productVatCategoryId,		A.IsOffer as OfferOption, case when A.IsOffer =1 then 'Yes' else 'No' end OfferOptionStr, A.IsActive as IsActive, B.VATRate ,  " +
            //            " A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit , " +
            //            " isnull(c.TotalInwardQty,0) - isnull(d.TotalSoldQty,0) as TotalAvailQty, C.LastInwardDate " +
            //            " FROM ProductMaster A  " +
            //            " 	LEFT OUTER JOIN  ProductCategory B  ON A.CategoryId = B.CategoryId " +
            //            " 	LEFT OUTER JOIN  " +
            //            " 	( " +
            //            " 		SELECT ProductId, SUM(Quantity) TotalInwardQty , max(CreatedOn) LastInwardDate " +
            //            " 		FROM  InwardDetail (NOLOCK) " +
            //            " 		GROUP BY ProductId " +
            //            " 	) C on A.ProductId = C.ProductId  " +
            //            " 	LEFT OUTER JOIN " +
            //            " 	( " +
            //            " 		SELECT ProductId, SUM(Quantity) TotalSoldQty " +
            //            " 		FROM  OrderDetail (NOLOCK) " +
            //            " 		GROUP BY ProductId " +
            //            " 	) D ON A.ProductId = D.ProductId " +
            //            "     INNER JOIN " +
            //            " 	( " +
            //            " 		SELECT SupplierId, Name " +
            //            " 		FROM  Supplier (NOLOCK) " +
            //            " 	) S ON A.SupplierId = S.SupplierId" +
            //            " AND A.Name LIKE '%" + productSearchCriteria.Trim() + "%' " +
            //            "	order by A.Name asc ";
            string sql = "SELECT	C.SupplierId, c.Name SupplierName, ItemBarCodeId as barCodeId, A.ProductId as productId, A.name + REPLICATE('*', 56-len(A.name)) + ' ' + CAST(SellingPrice AS VARCHAR(8)) productWithPrice, " +
            " A.name as productName, 		MRP, SellingPrice as productPrice ,		CostPrice as productCostPrice,		CategoryName as productVatCategory ,		" +
            " B.CategoryId as productVatCategoryId,	A.IsOffer as OfferOption,	case when A.IsOffer = 1 then 'Yes' else 'No' end OfferOptionStr, A.IsActive as IsActive, B.VATRate , " +
            " A.CostPrice + (A.CostPrice * (B.VATRate * 0.01)) CPWithVAT, A.SellingPrice - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) Profit, A.MRP - (A.CostPrice + (A.CostPrice * (B.VATRate * 0.01))) ProfitOnMRP, D.QuantityAvail as TotalAvailQty, D.LastInwardDate as LastInwardDate " +
            " FROM ProductMaster A, ProductCategory B, Supplier C , Stock D " +
            " where A.CategoryId = B.CategoryId and A.SupplierId = C.SupplierId " +
            " and A.ProductId = D.ProductId " +
            " AND A.Name LIKE '%" + productSearchCriteria.Trim() + "%' ";
            if (SupplierId != 0)
            {
                sql = sql + " and A.SupplierId = " + SupplierId + " ";
            }
            sql = sql + " order by A.Name asc";
            var products = db.ExecuteSqlStringAccessor<Product>(sql);

            foreach (var product in products)
            {



            }
            return products;
            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;


        }

        public IEnumerable<Treatment> getTreatmentList()
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            var TreatmentInfo = db.ExecuteSqlStringAccessor<Treatment>("SELECT 0 as IsSelected, TreatmentId, TreatmentName from Treatment  where IsActive=1");


            return TreatmentInfo;

        }

        public int saveProduct(Product product, string selectedTreatementValues, string operation)
        {






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
            int outputParam;
            using (SqlConnection sqlConnection = (SqlConnection)db.CreateConnection())
            {
                // Define a command object for calling the stored procedure.
                // Note: The Parameters collection of the SqlCommand object automatically assigns the
                // DbType property of each parameter to Object, and the SqlDbType property to Structured.
                //
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_SaveProduct";

                SqlParameter p_OperationFlag = new SqlParameter("@p_OperationFlag ", SqlDbType.VarChar, 1);
                p_OperationFlag.Direction = ParameterDirection.Input;
                p_OperationFlag.Value = operation;
                sqlCommand.Parameters.Add(p_OperationFlag);


                SqlParameter p_ProductId = new SqlParameter("@p_productId ", SqlDbType.BigInt);
                p_ProductId.Direction = ParameterDirection.Input;
                p_ProductId.Value = product.ProductId;
                sqlCommand.Parameters.Add(p_ProductId);

                SqlParameter p_ProductName = new SqlParameter("@p_productName ", SqlDbType.VarChar, 200);
                p_ProductName.Direction = ParameterDirection.Input;
                p_ProductName.Value = product.ProductName;
                sqlCommand.Parameters.Add(p_ProductName);

                //SqlParameter P_productDescripton = new SqlParameter("@productDescripton ", SqlDbType.VarChar, 200);
                //P_productDescripton.Direction = ParameterDirection.Input;
                //p_ProductName.Value = product.Description;
                //sqlCommand.Parameters.Add(P_productDescripton);

                SqlParameter p_ItemBarCodeId = new SqlParameter("@p_ItemBarCodeId", SqlDbType.VarChar, 50);
                p_ItemBarCodeId.Direction = ParameterDirection.Input;
                p_ItemBarCodeId.Value = product.BarCodeId;
                sqlCommand.Parameters.Add(p_ItemBarCodeId);


                SqlParameter p_CostPrice = new SqlParameter("@p_CostPrice", SqlDbType.Decimal);
                p_CostPrice.Direction = ParameterDirection.Input;
                p_CostPrice.Value = product.ProductCostPrice;
                sqlCommand.Parameters.Add(p_CostPrice);

                SqlParameter p_MRP = new SqlParameter("@p_MRP", SqlDbType.Decimal);
                p_MRP.Direction = ParameterDirection.Input;
                p_MRP.Value = product.MRP;
                sqlCommand.Parameters.Add(p_MRP);

                SqlParameter p_SellingPrice = new SqlParameter("@p_SellingPrice", SqlDbType.Decimal);
                p_SellingPrice.Direction = ParameterDirection.Input;
                p_SellingPrice.Value = product.ProductPrice;
                sqlCommand.Parameters.Add(p_SellingPrice);
                //VatCategory
                SqlParameter p_CategoryId = new SqlParameter("@p_CategoryId", SqlDbType.Int);
                p_CategoryId.Direction = ParameterDirection.Input;
                p_CategoryId.Value = product.ProductVatCategoryId;
                sqlCommand.Parameters.Add(p_CategoryId);


                SqlParameter p_IsActive = new SqlParameter("@p_IsActive", SqlDbType.Bit);
                p_IsActive.Direction = ParameterDirection.Input;
                p_IsActive.Value = product.IsActive;
                sqlCommand.Parameters.Add(p_IsActive);

                //SupplierId
                SqlParameter p_SupplierId = new SqlParameter("@p_SupplierId", SqlDbType.Int);
                p_SupplierId.Direction = ParameterDirection.Input;
                p_SupplierId.Value = product.SupplierId;
                sqlCommand.Parameters.Add(p_SupplierId);


                SqlParameter p_IsOffer = new SqlParameter("@p_IsOffer", SqlDbType.TinyInt);
                p_IsOffer.Direction = ParameterDirection.Input;
                p_IsOffer.Value = product.OfferOption;
                sqlCommand.Parameters.Add(p_IsOffer);


                SqlParameter p_TreatmentIdList = new SqlParameter("@p_TreatmentIdList", SqlDbType.VarChar, 2000);
                p_TreatmentIdList.Direction = ParameterDirection.Input;
                p_TreatmentIdList.Value = selectedTreatementValues;
                sqlCommand.Parameters.Add(p_TreatmentIdList);

                SqlParameter OutputParam = new SqlParameter("@O_ProductIdOut", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(OutputParam);


                // Open the connection, execute the command and close the connection.
                //
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.ExecuteNonQuery();

                var out_ProductId = sqlCommand.Parameters["@O_ProductIdOut"].Value;
                outputParam = Convert.ToInt32(out_ProductId);

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }
            }

            return outputParam;

        }

        public bool ValidateProduct(Product selectedProduct)
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            string SQL;
            SQL = "select 1 " +
                  "  from productmaster " +
                  "   where ItemBarCodeId = '" + selectedProduct.BarCodeId + "'" +
                  "   and productid != " + selectedProduct.ProductId +
                  "    and IsActive = 1 ";
            var ds = db.ExecuteDataSet(CommandType.Text, SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return false;
            }
            else
            {
                return true;
            }


            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;
        }

        public IEnumerable<ProductCategory> getProductCategory()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            var productCategory = db.ExecuteSqlStringAccessor<ProductCategory>("SELECT CategoryId, CategoryName + ' ' + convert(varchar(20),VatRate) + '%' CategoryName , VATRate FROM ProductCategory");


            return productCategory;
            //Int64 barCodeId;
            //int productId;
            //string productName;
            //double productPrice;




        }


        public IEnumerable<Order> getOrderDetail(Int64 billNo)
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            var orders = db.ExecuteSqlStringAccessor<Order>("select A.ItemBarCodeId as barCodeId,       A.OrderDetailId as orderDetailId,        A.ProductId as productId,        B.Name AS productName,        A.Quantity as quantity,    A.SellingPrice as price,     A.MRP as MRP  , A.Total as total,        A.BillAmt as billAmount, 	A.CreatedOn as billDate, 0 as isDirty, 0 as CostPrice, 0 as Profit    from OrderDetail A, ProductMaster B    where     B.IsActive = 1 and A.ProductId = B.ProductId and A.BillNo =" + billNo);
            return orders;

        }

        public IEnumerable<ActiveType> getActiveTypes()
        {
            List<ActiveType> activeTypes = new List<ActiveType>();
            ActiveType activeType = new ActiveType();
            activeType.ActiveId = 1;
            activeType.ActiveCategory = "True";

            activeTypes.Add(activeType);
            activeType = new ActiveType();
            activeType.ActiveId = 2;
            activeType.ActiveCategory = "False";
            activeTypes.Add(activeType);
            return activeTypes;

        }

        public IEnumerable<ProductOffers> getProductOffers()
        {
            List<ProductOffers> productOffers = new List<ProductOffers>();
            ProductOffers productOffer = new ProductOffers();
            productOffer.OfferId = 1;
            productOffer.OfferOption = "Yes";

            productOffers.Add(productOffer);
            productOffer = new ProductOffers();
            productOffer.OfferId = 0;
            productOffer.OfferOption = "No";
            productOffers.Add(productOffer);
            return productOffers;

        }

        public IEnumerable<OrderSummary> getOrderSummaryDetail(long billNo)
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaster");
            var ordersummary = db.ExecuteSqlStringAccessor<OrderSummary>("select BillNo,CustomerId,BillAmt as BillAmount,CashTendered, NetBillAmt, ConsumedLoyaltyPoints, CashReturned as Balance,  0 as AvailableLoyaltyPoints, CONVERT(varchar(20), CreatedOn, 103) + ' '+ RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,CreatedOn,100),8)),7) as BillDate, IsBillReturn , 0 as TotalQty, Discount, FinalTotal , PaymentModeId , 0 as TotalCostPrice, 0 as TotalProfit,DiscountAuto  from orders where BillNo = " + billNo);
            return ordersummary;

        }

        public Int64 saveBill(IEnumerable<Order> orders, OrderSummary orderSummary)
        {

            DataTable table = new DataTable();
            table.Columns.Add("OrderDetailId", typeof(Int64));
            //table.Columns.Add("BillNo", typeof(Int64));
            table.Columns.Add("ProductId", typeof(int));
            //table.Columns.Add("CustomerId", typeof(int));

            table.Columns.Add("ItemBarCodeId", typeof(Int64));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("SellingPrice", typeof(double));
            table.Columns.Add("Total", typeof(double));
            table.Columns.Add("BillAmt", typeof(double));
            table.Columns.Add("CashTendered", typeof(double));
            table.Columns.Add("CashReturned", typeof(double));
            table.Columns.Add("MRP", typeof(double));

            foreach (var ord in orders)
            {
                table.Rows.Add(
                        ord.OrderDetailId,
                        ord.ProductId,
                        ord.BarCodeId,
                        ord.Quantity,
                        ord.Price,
                        ord.Total,
                        orderSummary.BillAmount,
                        orderSummary.CashTendered,
                        orderSummary.Balance,
                        ord.MRP
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
                sqlCommand.CommandText = "sp_OrderDetail";
                sqlCommand.Parameters.AddWithValue("@tvp", table);

                SqlParameter p_CustID = new SqlParameter("@p_CustID ", SqlDbType.Decimal);
                p_CustID.Direction = ParameterDirection.Input;
                p_CustID.Value = orderSummary.CustomerId;
                sqlCommand.Parameters.Add(p_CustID);

                SqlParameter p_ConsumedLoyaltyPoints = new SqlParameter("@p_ConsumedLoyaltyPoints", SqlDbType.Decimal);
                p_ConsumedLoyaltyPoints.Direction = ParameterDirection.Input;
                p_ConsumedLoyaltyPoints.Value = orderSummary.ConsumedLoyaltyPoints;
                sqlCommand.Parameters.Add(p_ConsumedLoyaltyPoints);

                SqlParameter p_NetBillAmt = new SqlParameter("@p_NetBillAmt", SqlDbType.Decimal);
                p_NetBillAmt.Direction = ParameterDirection.Input;
                p_NetBillAmt.Value = orderSummary.NetBillAmt;
                sqlCommand.Parameters.Add(p_NetBillAmt);

                SqlParameter p_Discount = new SqlParameter("@p_Discount", SqlDbType.Decimal);
                p_Discount.Direction = ParameterDirection.Input;
                p_Discount.Value = orderSummary.Discount;
                sqlCommand.Parameters.Add(p_Discount);

                SqlParameter p_FinalTotal = new SqlParameter("@p_FinalTotal", SqlDbType.Decimal);
                p_FinalTotal.Direction = ParameterDirection.Input;
                p_FinalTotal.Value = orderSummary.FinalTotal;
                sqlCommand.Parameters.Add(p_FinalTotal);

                SqlParameter p_AsOfRewardPoints = new SqlParameter("@p_AsOfRewardPoints", SqlDbType.Decimal);
                p_AsOfRewardPoints.Direction = ParameterDirection.Input;
                p_AsOfRewardPoints.Value = orderSummary.AvailableLoyaltyPoints;
                sqlCommand.Parameters.Add(p_AsOfRewardPoints);


                SqlParameter p_PaymentModeId = new SqlParameter("@p_PaymentModeId", SqlDbType.Int);
                p_PaymentModeId.Direction = ParameterDirection.Input;
                p_PaymentModeId.Value = orderSummary.PaymentModeId;
                sqlCommand.Parameters.Add(p_PaymentModeId);


                SqlParameter p_IsBillReturn = new SqlParameter("@p_IsBillReturn", SqlDbType.Bit);
                p_IsBillReturn.Direction = ParameterDirection.Input;
                p_IsBillReturn.Value = orderSummary.IsBillReturn;
                sqlCommand.Parameters.Add(p_IsBillReturn);


                SqlParameter p_DiscountAuto = new SqlParameter("@p_DiscountAuto", SqlDbType.Bit);
                p_DiscountAuto.Direction = ParameterDirection.Input;
                p_DiscountAuto.Value = orderSummary.DiscountAuto;
                sqlCommand.Parameters.Add(p_DiscountAuto);


                SqlParameter OutputParam = new SqlParameter("@O_BillNo", SqlDbType.BigInt);
                OutputParam.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(OutputParam);


                // Open the connection, execute the command and close the connection.
                //
                if (sqlCommand.Connection.State != ConnectionState.Open)
                {
                    sqlCommand.Connection.Open();
                }

                sqlCommand.ExecuteNonQuery();

                var str = sqlCommand.Parameters["@O_BillNo"].Value;
                outputParam = Convert.ToInt64(str);

                if (sqlCommand.Connection.State == ConnectionState.Open)
                {
                    sqlCommand.Connection.Close();
                }
            }

            return outputParam;
        }

        public Customer SearchCustomerByCustId(int custID)
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone,LeftRewardsPoints  from customermaster where CustomerId =" + custID);
            var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone, TotalRewardsPoints , ConsumedRewardsPoints, LeftRewardsPoints, CreatedOn from customermaster  where CustomerId =" + custID);


            List<Customer> customerList = new List<Customer>(customers);

            if (customerList.Count != null)
            {
                if (customerList.Count == 1)
                {

                    return customerList[0];
                }
            }

            return null;

        }

        public Customer SearchCustomerByPhone(string phone)
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode , MobileNo1 as Phone, LeftRewardsPoints  from customermaster where MobileNo1 ='" + phone + "'");
            var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone, TotalRewardsPoints , ConsumedRewardsPoints, LeftRewardsPoints, CreatedOn from customermaster where MobileNo1 ='" + phone + "'");

            List<Customer> customerList = new List<Customer>(customers);

            if (customerList.Count != null)
            {
                if (customerList.Count == 1)
                {

                    return customerList[0];
                }
            }

            return null;

        }

        public Customer SearchCustomerByCustomerBarCode(Int64? customer_barcode)
        {
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");
            //var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode , MobileNo1 as Phone, LeftRewardsPoints  from customermaster where BarCodeId ='" + customer_barcode + "'");

            var customers = db.ExecuteSqlStringAccessor<Customer>("select CustomerId as CustID, Name, Address, BarCodeId as Customer_barcode, MobileNo1 as Phone, TotalRewardsPoints , ConsumedRewardsPoints, LeftRewardsPoints, CreatedOn from customermaster where BarCodeId ='" + customer_barcode + "'");
            List<Customer> customerList = new List<Customer>(customers);

            if (customerList.Count != null)
            {
                if (customerList.Count == 1)
                {

                    return customerList[0];
                }
            }

            return null;

        }
    }
}
