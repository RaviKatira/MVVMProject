using Common;
using OPSSystem.Command;
using OPSSystem.Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OPSMain.Email
{
    public class SendEmailViewModel : ViewModelBase
    {
        ICommand _sendMailCommand;

        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {

                    _SubmitCommand = new RelayCommand(param => this.Submit(), null);
                }

                return _SubmitCommand;
            }


        }
        private bool Submit()
        {
            return true;
        }
        public ICommand SendMailCommand
        {
            get
            {
                if(_sendMailCommand == null)
                {
                    _sendMailCommand = new RelayCommand(param => this.SendInfoMail(),
                        null);
                }
                return _sendMailCommand;
            }

            
        }

        private void SendInfoMail()
        {
            try
            {
                SendEmailRepository sendEmailRepository;
                sendEmailRepository = new SendEmailRepository();
                var salesSummaryList = sendEmailRepository.getTodaysData();


                var html = Utility.getHtmlTable(salesSummaryList, x => x.Supplier, x => x.SaleAmt, x=> x.CostAmt, x=>x.Profit, x=>x.QtySold);
                Utility.SendMailSalesSummary("Sales dated: " + DateTime.Now.ToShortDateString(), html);
                MessageBox.Show("Mail Sent Successfully");
            }
            catch(Exception e)
            {
                MessageBox.Show("Error occured: " + e.Message + e.Source + e.StackTrace);

            }
        }
    }
}
