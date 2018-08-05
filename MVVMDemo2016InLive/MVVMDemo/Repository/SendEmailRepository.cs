using Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SendEmailRepository
    {
        public IEnumerable<SalesSummary> getTodaysData()
        {
            //var container = new UnityContainer();
            //container.AddExtension<EnterpriseLibraryCoreExtension>();        
            Database db;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create("OPSDBConn");
            //IDataReader reader = db.ExecuteReader(CommandType.Text, "select * from ProductMaser");

            string sql = " SELECT  S.Name AS Supplier, " +
            "        AVG(ROUND(100 * (X.SellingPrice - (X.CostPrice + X.CostPrice * Z.VATRate / 100)) / X.CostPrice, 2)) AS 'ProfitPerc',  " +
            " 		SUM(ISNULL(Y.QtySold, 0) * X.SellingPrice) AS SaleAmt,  " +
            "         SUM(ISNULL(Y.QtySold, 0) * (X.CostPrice + X.CostPrice * Z.VATRate / 100)) AS CostAmt, " +
            " 		SUM(ISNULL(Y.QtySold, 0) * X.SellingPrice - ISNULL(Y.QtySold, 0) * (X.CostPrice + X.CostPrice * Z.VATRate / 100)) AS Profit, " +
            " 		SUM(ISNULL(Y.QtySold, 0)) AS QtySold " +
            " FROM            (SELECT        A.SupplierId, A.ProductId, A.Name, A.Descripton, A.LotBarCodeId, A.ItemBarCodeId, A.NoOfLots, A.LotSize, A.TotalItems, A.LotPrice,  A.CostPrice, " +
"                                                     A.SellingPrice, A.CreatedOn, A.CreatedBy, A.UpdatedOn, A.UpdatedBy, A.CategoryId, A.IsActive, B.TotalQty " +
"                           FROM            ProductMaster AS A LEFT OUTER JOIN " +
"                                                         (SELECT        ProductId, SUM(Quantity) AS TotalQty " +
"                                                           FROM            InwardDetail " +
"                                                           GROUP BY ProductId) AS B ON A.ProductId = B.ProductId) AS X LEFT OUTER JOIN " +
"                              (SELECT        ProductId, SUM(Quantity) AS QtySold, CONVERT(varchar(20), CreatedOn, 112) AS CreateOn " +
"                                FROM            OrderDetail " +
"                                GROUP BY ProductId, CONVERT(varchar(20), CreatedOn, 112)) AS Y ON X.ProductId = Y.ProductId LEFT OUTER JOIN " +
"                          ProductCategory AS Z ON X.CategoryId = Z.CategoryId INNER JOIN " +
"                          Supplier AS S ON X.SupplierId = S.SupplierId " +
" WHERE  (ISNULL(Y.QtySold, 0) * X.SellingPrice <> 0) " +
" and convert(varchar(20), Y.CreateOn, 112) = convert(varchar(20), getdate(),112) " +
" GROUP BY S.Name " +
" union all " +
" SELECT  'Total' AS Descripton, " +
"         AVG(ROUND(100 * (X.SellingPrice - (X.CostPrice + X.CostPrice * Z.VATRate / 100)) / X.CostPrice, 2)) AS 'ProfitPerc',  " +
" 		SUM(ISNULL(Y.QtySold, 0) * X.SellingPrice) AS SaleAmt,  " +
"         SUM(ISNULL(Y.QtySold, 0) * (X.CostPrice + X.CostPrice * Z.VATRate / 100)) AS CostAmt,  " +
" 		SUM(ISNULL(Y.QtySold, 0) * X.SellingPrice - ISNULL(Y.QtySold, 0) * (X.CostPrice + X.CostPrice * Z.VATRate / 100)) AS Profit, " +
" 		SUM(ISNULL(Y.QtySold, 0)) AS QtySold " +
" FROM            (SELECT        A.SupplierId, A.ProductId, A.Name, A.Descripton, A.LotBarCodeId, A.ItemBarCodeId, A.NoOfLots, A.LotSize, A.TotalItems, A.LotPrice,  A.CostPrice, " +
"                                                     A.SellingPrice, A.CreatedOn, A.CreatedBy, A.UpdatedOn, A.UpdatedBy, A.CategoryId, A.IsActive, B.TotalQty " +
"                           FROM            ProductMaster AS A LEFT OUTER JOIN " +
"                                                         (SELECT        ProductId, SUM(Quantity) AS TotalQty " +
"                                                           FROM            InwardDetail " +
"                                                           GROUP BY ProductId) AS B ON A.ProductId = B.ProductId) AS X LEFT OUTER JOIN " +
"                              (SELECT        ProductId, SUM(Quantity) AS QtySold, CONVERT(varchar(20), CreatedOn, 112) AS CreateOn " +
"                                FROM            OrderDetail " +
"                                GROUP BY ProductId, CONVERT(varchar(20), CreatedOn, 112)) AS Y ON X.ProductId = Y.ProductId LEFT OUTER JOIN " +
"                          ProductCategory AS Z ON X.CategoryId = Z.CategoryId INNER JOIN " +
"                          Supplier AS S ON X.SupplierId = S.SupplierId " +
" WHERE  (ISNULL(Y.QtySold, 0) * X.SellingPrice <> 0) " +
" and convert(varchar(20), Y.CreateOn, 112) = convert(varchar(20), getdate(),112) " +
" union all " +
  " select 'Discount' as Supplier, 0,sum(Discount), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112) " +
  " union all " +
  " select 'Net Total' as Supplier, 0,sum(FinalTotal), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112) " +
  " union all " +
  " select 'Cash' as Supplier, 0,isnull(sum(case when PaymentModeId = 1 then FinalTotal end), 0), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112) " +
  " union all " +
  " select 'Card' as Supplier, 0,isnull(sum(case when PaymentModeId = 2 then FinalTotal end), 0), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112) " +
  " union all " +
  " select 'BHIM' as Supplier, 0,isnull(sum(case when PaymentModeId = 3 then FinalTotal end), 0), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112) " +
  " union all " +
  " select 'PayTM' as Supplier, 0,isnull(sum(case when PaymentModeId = 4 then FinalTotal end), 0), 0,0,0 " +
  " from Orders " +
  " where convert(varchar(20), CreatedOn, 112) = convert(varchar(20), getdate(), 112)  ";
   

       var salesSummary = db.ExecuteSqlStringAccessor<SalesSummary>(sql);


            return salesSummary;
        }
    }
}
