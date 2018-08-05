using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OPSScheduler
{
    public class Program
    {
        static void Main(string[] args)
        {
            if(args[0] =="mail")
            {
                SendInfoMail();
            }
        }
        public static void SendInfoMail()
        {
            try
            {
                SendEmailRepository sendEmailRepository;
                sendEmailRepository = new SendEmailRepository();
                var salesSummaryList = sendEmailRepository.getTodaysData();


                var html = Utility.getHtmlTable(salesSummaryList, x => x.Supplier, x => x.SaleAmt, x => x.CostAmt, x => x.Profit, x => x.QtySold);
                Utility.SendMailSalesSummary("Sales dated: " + DateTime.Now.ToShortDateString(), html);
                //MessageBox.Show("Mail Sent Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured: " + e.Message + e.Source + e.StackTrace);

            }
        }
    }
}
