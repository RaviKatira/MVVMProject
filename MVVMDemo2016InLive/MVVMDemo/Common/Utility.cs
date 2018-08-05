using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Configuration;
using System.Reflection;

namespace Common
{
    public static class Utility
    {
        static readonly string smtpAddress = readAppSetting("SmtpAddress");
        const int portNumber = 587;
        const bool enableSSL = true;

        static string emailFrom = readAppSetting("EmailFrom");
        static string password = readAppSetting("PwdKey");
        static readonly string emailTo = readAppSetting("EmailDistributionList");// "dashamastores@gmail.com,katiraravi@gmail.com,snehakatira@gmail.com";
        static readonly string companyName = readAppSetting("CompanyName");
        static readonly string address1 = readAppSetting("Address1");
        static readonly string address2 = readAppSetting("Address2");
        static readonly string contact = readAppSetting("Contact");
        static readonly string tax = readAppSetting("Tax");
        static readonly string website = readAppSetting("Website");
        static readonly string note1 = readAppSetting("Note1");
        static readonly string note2 = readAppSetting("Note2");
        static readonly string advertisement = readAppSetting("Advertisement");

        public static void SendMailSalesSummary(string subject, string htmlBody)
        {
            ActionMail(subject, htmlBody);
        }
        public static void SendMail(OrderSummary orderSummary)
        {
            string subject = "Hi";
            string body = "Thanks for shopping with us for bill amount: " + orderSummary.BillAmount.ToString();
            ActionMail(subject, body);
        }

        private static void ActionMail(string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

        public static void PrintBill(Int64 billNo)
        {

            OrderRepository orderRepository = new OrderRepository();
            var orders = orderRepository.getOrderDetail(billNo);
            IEnumerable<OrderSummary> ordersummary = orderRepository.getOrderSummaryDetail(billNo);
            OrderSummary ordSummary = new OrderSummary();
            foreach (var ordsumm in ordersummary)
            {
                ordSummary.BillNo = ordsumm.BillNo;
                ordSummary.BillAmount = ordsumm.BillAmount;
                ordSummary.CashTendered = ordsumm.CashTendered;
                ordSummary.Balance = ordsumm.Balance;
                ordSummary.BillDate = ordsumm.BillDate;
                ordSummary.Discount = ordsumm.Discount;
                ordSummary.FinalTotal = ordsumm.FinalTotal;
                ordSummary.DiscountAuto = ordsumm.DiscountAuto;
            }
            Utility.PrintBill(orders, ordSummary);

        }
        public static void PrintBill_old(IEnumerable<Order> paraorders, OrderSummary paraorderSummary)
        {
            PrintDialog printDlg = new PrintDialog();
            // Create a FlowDocument dynamically.
            String str;
            str = companyName;
            Paragraph para = new Paragraph(new Bold(new Run(str)));
            para.TextAlignment = TextAlignment.Center;

            FlowDocument doc = new FlowDocument(para);
            doc.PagePadding = new Thickness(20, 0, 0, 0);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));


            str = address1;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));

            str = address2;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));

            str = contact;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));


            str = "Cash Memo";

            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));
            str = "Bill No: " + paraorderSummary.BillNo;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Left;
            doc.Blocks.Add(para);

            str = "Date: " + paraorderSummary.BillDate;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Left;
            doc.Blocks.Add(para);


            doc.FontSize = 10;
            doc.FontFamily = new FontFamily("Fixedsys");

            //doc.PageHeight = printDlg.PrintableAreaHeight;
            doc.PageWidth = printDlg.PrintableAreaWidth;
            doc.FontStretch = FontStretches.UltraExpanded;
            doc.LineHeight = 1;
            Table table = new Table();

            doc.Blocks.Add(table);
            table.CellSpacing = 10;
            table.Background = Brushes.White;
            //int numberOfColumns = 5;
            //for (int x = 0; x < numberOfColumns; x++)
            //{
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());


            // Set alternating background colors for the middle colums.
            //if (x % 2 == 0)
            //table.Columns[x].Background = Brushes.Beige;
            //else
            //table.Columns[x].Background = Brushes.LightSteelBlue;
            //}
            table.RowGroups.Add(new TableRowGroup());

            // Add the first (title) row.
            //table.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow;
            // Alias the current working row for easy reference.
            //TableRow currentRow = table.RowGroups[0].Rows[0];

            //// Global formatting for the title row.
            ////currentRow.Background = Brushes.Silver;
            ////currentRow.FontSize = 40;
            ////currentRow.FontWeight = System.Windows.FontWeights.Bold;

            //// Add the header row with content, 
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;


            // Add the first (header) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            table.CellSpacing = 0;

            currentRow = table.RowGroups[0].Rows[0];



            // Global formatting for the header row.
            currentRow.FontSize = 10;
            currentRow.FontWeight = FontWeights.Bold;


            // Add cells with content to the header row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Sl"))));
            //currentRow.Cells[0].Padding = new Thickness(0, 2, 0, 2);
            //currentRow.Cells[0].BorderThickness = new Thickness(0.5);
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Description"))));
            currentRow.Cells[1].ColumnSpan = 2;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Qty"))));
            currentRow.Cells[2].TextAlignment = TextAlignment.Right;

            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rate"))));

            currentRow.Cells[3].TextAlignment = TextAlignment.Right;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Amt."))));
            currentRow.Cells[4].TextAlignment = TextAlignment.Right;

            for (int j = 0; j <= (5 - 1); j++)
            {

                currentRow.Cells[j].Padding = new Thickness(0);
                currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                currentRow.Cells[j].BorderBrush = Brushes.Black;
            }

            //var separator = new Rectangle();
            //separator.Stroke = new SolidColorBrush(Colors.Blue);
            //separator.StrokeThickness = 3;
            //separator.Height = 3;
            //separator.Width = double.NaN;

            //var lineBlock = new BlockUIContainer(separator);
            //doc.Blocks.Add(lineBlock);



            // Add cells with content to the third row.
            double totalItem = 0;
            double totalBill = 0;
            int i = 0;
            foreach (var ord in paraorders)
            {
                // Add the second row.
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];

                // Global formatting for the row.
                currentRow.FontSize = 10;
                currentRow.FontWeight = FontWeights.Normal;
                i++;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(i.ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.ProductName.ToString()))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Quantity.ToString().ToString()))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;

                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Price.ToString()))));


                currentRow.Cells[3].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Total.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

                totalItem = totalItem + ord.Quantity;
                totalBill = totalBill + ord.Total;


                for (int j = 0; j <= (5 - 1); j++)
                {
                    currentRow.Cells[j].Padding = new Thickness(0);
                    //currentRow.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                    //currentRow.Cells[j].BorderBrush = Brushes.Black;
                }
            }

            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[i + 1];
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
            currentRow.Cells[1].ColumnSpan = 2;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(totalItem.ToString()))));
            currentRow.Cells[2].TextAlignment = TextAlignment.Right;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.BillAmount.ToString()))));
            currentRow.Cells[4].TextAlignment = TextAlignment.Right;



            for (int j = 0; j <= (5 - 1); j++)
            {

                currentRow.Cells[j].Padding = new Thickness(0);
                currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                currentRow.Cells[j].BorderBrush = Brushes.Black;
            }

            if (paraorderSummary.Discount > 0)
            {

                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.ExtraBold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("**Discount**"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.Discount.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

                for (int j = 0; j <= (5 - 1); j++)
                {
                    currentRow.Cells[j].Padding = new Thickness(0);
                    //currentRow.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                    //currentRow.Cells[j].BorderBrush = Brushes.Black;
                }
                i++;
                for (int j = 0; j <= (5 - 1); j++)
                {

                    currentRow.Cells[j].Padding = new Thickness(0);
                    currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                    currentRow.Cells[j].BorderBrush = Brushes.Black;
                }

                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Final Bill Total"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.FinalTotal.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                for (int j = 0; j <= (5 - 1); j++)
                {

                    currentRow.Cells[j].Padding = new Thickness(0);
                    currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                    currentRow.Cells[j].BorderBrush = Brushes.Black;
                }


            }


            if (paraorderSummary.CashTendered > 0)
            {
                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Regular;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Cash Tendered"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.CashTendered.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Regular;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Balance"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.Balance.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

            }

            for (int j = 0; j <= (5 - 1); j++)
            {

                Console.WriteLine(table.Columns[j].Width);

            }

            GridLengthConverter glc = new GridLengthConverter();
            table.Columns[0].Width = (GridLength)glc.ConvertFromString("20"); //'ID'
            table.Columns[1].Width = (GridLength)glc.ConvertFromString("120"); //DESC
            table.Columns[2].Width = (GridLength)glc.ConvertFromString("0"); //QTY
            table.Columns[3].Width = (GridLength)glc.ConvertFromString("30"); //QTY
            table.Columns[4].Width = (GridLength)glc.ConvertFromString("40"); //DESC
            table.Columns[5].Width = (GridLength)glc.ConvertFromString("40"); //DESC
            for (int j = 0; j <= (5 - 1); j++)
            {

                Console.WriteLine(table.Columns[j].Width);

            }

            // Bold the first cell.
            //currentRow.Cells[0].FontWeight = FontWeights.Bold;

            //    table.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table.RowGroups[0].Rows[3];

            //// Global formatting for the footer row.
            //currentRow.Background = Brushes.LightGray;
            //currentRow.FontSize = 18;
            //currentRow.FontWeight = System.Windows.FontWeights.Normal;

            //// Add the header row with content, 
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;

            //doc.FontSize = 10;
            //doc.FontFamily = new FontFamily("Fixedsys"); 
            //doc.PageHeight = printDlg.PrintableAreaHeight;
            //doc.PageWidth = printDlg.PrintableAreaWidth;
            //doc.FontStretch = FontStretches.UltraExpanded;
            //doc.LineHeight=1;
            //doc.PagePadding = new Thickness(20.0, 20.0, 20.0, 20.0);
            //doc.IsOptimalParagraphEnabled = true;
            //doc.IsHyphenationEnabled = true;
            //doc.IsColumnWidthFlexible = true;

            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //str = "---- Cash Memo ----";
            //doc.Blocks.Add(new Paragraph(new Run(str)));

            //str = "Product Name".PadRight(50 - "Product Name".Length);
            //str += "Qty@Price".PadLeft(15);
            //str += "Total".PadLeft(10);
            //Debug.WriteLine(str);

            //doc.Blocks.Add(new Paragraph(new Run(str)));
            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //string strcon;
            //foreach(var ord in Orders)
            //{
            //    strcon = ord.ProductName.ToString().PadRight(50- ord.ProductName.ToString().Length);
            //    //strcon += new string(' ', 8);
            //    //strcon += new string(' ', 8);
            //    strcon += (ord.Quantity.ToString() +'@' + ord.Price.ToString()).PadLeft(15);
            //    //strcon += new string(' ', 8);
            //    strcon += ord.Total.ToString().PadLeft(10);
            //    Debug.WriteLine(strcon);
            //    doc.Blocks.Add(new Paragraph(new Run(strcon)));
            //}

            if (tax != null && tax.Length > 0)
            {
                str = tax;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }
            if (website != null && website.Length > 0)
            {
                str = website;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }

            if (note1 != null && note1.Length > 0)
            {
                str = note1;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }

            if (note2 != null && note2.Length > 0)
            {
                str = note2;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }
            if (advertisement != null && advertisement.Length > 0)
            {
                str = advertisement;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                para.FontWeight = FontWeights.Bold;
                doc.Blocks.Add(para);
            }

            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;
            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }
        public static void PrintBill(IEnumerable<Order> paraorders, OrderSummary paraorderSummary)
        {
            PrintDialog printDlg = new PrintDialog();
            // Create a FlowDocument dynamically.
            String str;
            str = companyName;
            Paragraph para = new Paragraph(new Bold(new Run(str)));
            para.TextAlignment = TextAlignment.Center;

            FlowDocument doc = new FlowDocument(para);
            doc.PagePadding = new Thickness(20, 0, 0, 0);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));


            str = address1;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));

            str = address2;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));

            str = contact;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));


            str = "Cash Memo";

            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Center;
            doc.Blocks.Add(para);
            //doc.Blocks.Add(new Paragraph(new LineBreak()));
            str = "Bill No: " + paraorderSummary.BillNo;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Left;
            doc.Blocks.Add(para);

            str = "Date: " + paraorderSummary.BillDate;
            para = new Paragraph(new Run(str));
            para.TextAlignment = TextAlignment.Left;
            doc.Blocks.Add(para);


            doc.FontSize = 10;
            doc.FontFamily = new FontFamily("Fixedsys");

            //doc.PageHeight = printDlg.PrintableAreaHeight;
            doc.PageWidth = printDlg.PrintableAreaWidth;
            doc.FontStretch = FontStretches.UltraExpanded;
            doc.LineHeight = 1;
            Table table = new Table();

            doc.Blocks.Add(table);
            table.CellSpacing = 10;
            table.Background = Brushes.White;
            //int numberOfColumns = 5;
            //for (int x = 0; x < numberOfColumns; x++)
            //{
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            if (paraorderSummary.DiscountAuto)
                table.Columns.Add(new TableColumn());


            // Set alternating background colors for the middle colums.
            //if (x % 2 == 0)
            //table.Columns[x].Background = Brushes.Beige;
            //else
            //table.Columns[x].Background = Brushes.LightSteelBlue;
            //}
            table.RowGroups.Add(new TableRowGroup());

            // Add the first (title) row.
            //table.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow;
            // Alias the current working row for easy reference.
            //TableRow currentRow = table.RowGroups[0].Rows[0];

            //// Global formatting for the title row.
            ////currentRow.Background = Brushes.Silver;
            ////currentRow.FontSize = 40;
            ////currentRow.FontWeight = System.Windows.FontWeights.Bold;

            //// Add the header row with content, 
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;


            // Add the first (header) row.
            table.RowGroups[0].Rows.Add(new TableRow());
            table.CellSpacing = 0;

            currentRow = table.RowGroups[0].Rows[0];



            // Global formatting for the header row.
            currentRow.FontSize = 10;
            currentRow.FontWeight = FontWeights.Bold;


            // Add cells with content to the header row.
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Sl"))));
            //currentRow.Cells[0].Padding = new Thickness(0, 2, 0, 2);
            //currentRow.Cells[0].BorderThickness = new Thickness(0.5);
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Description"))));
            currentRow.Cells[1].ColumnSpan = 2;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Qty"))));
            currentRow.Cells[2].TextAlignment = TextAlignment.Right;

            if (paraorderSummary.DiscountAuto)
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Mrp"))));
                currentRow.Cells[3].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rate"))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Amt."))));
                currentRow.Cells[5].TextAlignment = TextAlignment.Right;

            }
            else
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Rate"))));
                currentRow.Cells[3].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Amt."))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

            }

            int colCount = paraorderSummary.DiscountAuto ? 6 : 5;
            for (int j = 0; j <= (colCount - 1); j++)
            {

                currentRow.Cells[j].Padding = new Thickness(0);
                currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                currentRow.Cells[j].BorderBrush = Brushes.Black;
            }

            //var separator = new Rectangle();
            //separator.Stroke = new SolidColorBrush(Colors.Blue);
            //separator.StrokeThickness = 3;
            //separator.Height = 3;
            //separator.Width = double.NaN;

            //var lineBlock = new BlockUIContainer(separator);
            //doc.Blocks.Add(lineBlock);



            // Add cells with content to the third row.
            double totalItem = 0;
            double totalBill = 0;
            int i = 0;
            foreach (var ord in paraorders)
            {
                // Add the second row.
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];

                // Global formatting for the row.
                currentRow.FontSize = 10;
                currentRow.FontWeight = FontWeights.Normal;
                i++;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(i.ToString()))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.ProductName.ToString()))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Quantity.ToString().ToString()))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;

                if (paraorderSummary.DiscountAuto)
                {
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.MRP.ToString()))));
                    currentRow.Cells[3].TextAlignment = TextAlignment.Right;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Price.ToString()))));
                    currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Total.ToString()))));
                    currentRow.Cells[5].TextAlignment = TextAlignment.Right;
                }
                else
                {
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Price.ToString()))));
                    currentRow.Cells[3].TextAlignment = TextAlignment.Right;
                    currentRow.Cells.Add(new TableCell(new Paragraph(new Run(ord.Total.ToString()))));
                    currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                }



                totalItem = totalItem + ord.Quantity;
                totalBill = totalBill + ord.Total;


                for (int j = 0; j <= (colCount - 1); j++)
                {
                    currentRow.Cells[j].Padding = new Thickness(0);
                    //currentRow.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                    //currentRow.Cells[j].BorderBrush = Brushes.Black;
                }
            }

            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[i + 1];
            currentRow.FontWeight = FontWeights.Bold;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Total"))));
            currentRow.Cells[1].ColumnSpan = 2;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(totalItem.ToString()))));
            currentRow.Cells[2].TextAlignment = TextAlignment.Right;
            
            if(paraorderSummary.DiscountAuto)
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.BillAmount.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells[5].TextAlignment = TextAlignment.Right;
            }
            else
            {
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.BillAmount.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;
            }

            for (int j = 0; j <= (colCount - 1); j++)
            {

                currentRow.Cells[j].Padding = new Thickness(0);
                currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                currentRow.Cells[j].BorderBrush = Brushes.Black;
            }

            if (paraorderSummary.DiscountAuto==false && paraorderSummary.Discount > 0)
            {

                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.ExtraBold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("**Discount**"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.Discount.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

                for (int j = 0; j <= (colCount - 1); j++)
                {
                    currentRow.Cells[j].Padding = new Thickness(0);
                    //currentRow.Cells[j].BorderThickness = new Thickness(1, 1, 1, 1);
                    //currentRow.Cells[j].BorderBrush = Brushes.Black;
                }
                i++;
                for (int j = 0; j <= (colCount - 1); j++)
                {

                    currentRow.Cells[j].Padding = new Thickness(0);
                    currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                    currentRow.Cells[j].BorderBrush = Brushes.Black;
                }

                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Bold;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Final Bill Total"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.FinalTotal.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;
                for (int j = 0; j <= (colCount - 1); j++)
                {

                    currentRow.Cells[j].Padding = new Thickness(0);
                    currentRow.Cells[j].BorderThickness = new Thickness(0, 1, 0, 1);
                    currentRow.Cells[j].BorderBrush = Brushes.Black;
                }


            }


            if (paraorderSummary.CashTendered > 0)
            {
                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Regular;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Cash Tendered"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.CashTendered.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

                i++;
                table.RowGroups[0].Rows.Add(new TableRow());
                currentRow = table.RowGroups[0].Rows[i + 1];
                currentRow.FontWeight = FontWeights.Regular;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Balance"))));
                currentRow.Cells[1].ColumnSpan = 2;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(String.Empty))));
                currentRow.Cells[2].TextAlignment = TextAlignment.Right;
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(paraorderSummary.Balance.ToString()))));
                currentRow.Cells[4].TextAlignment = TextAlignment.Right;

            }

            for (int j = 0; j <= (colCount - 1); j++)
            {

                Console.WriteLine(table.Columns[j].Width);

            }

            GridLengthConverter glc = new GridLengthConverter();
            //table.Columns[0].Width = (GridLength)glc.ConvertFromString("20"); //'ID'
            //table.Columns[1].Width = (GridLength)glc.ConvertFromString("120"); //DESC
            //table.Columns[2].Width = (GridLength)glc.ConvertFromString("0"); //Desc
            //table.Columns[3].Width = (GridLength)glc.ConvertFromString("30"); //Qty
            //table.Columns[4].Width = (GridLength)glc.ConvertFromString("40"); //Rate
            //table.Columns[5].Width = (GridLength)glc.ConvertFromString("40"); //Amt

            table.Columns[0].Width = (GridLength)glc.ConvertFromString("20"); //'ID'
            if (paraorderSummary.DiscountAuto)
            {
                table.Columns[1].Width = (GridLength)glc.ConvertFromString("110"); //DESC
            }
            else
            {
                table.Columns[1].Width = (GridLength)glc.ConvertFromString("120"); //DESC
            }
            table.Columns[2].Width = (GridLength)glc.ConvertFromString("0"); //Desc
            table.Columns[3].Width = (GridLength)glc.ConvertFromString("30"); //Qty
            if (paraorderSummary.DiscountAuto)
            {
                table.Columns[4].Width = (GridLength)glc.ConvertFromString("30"); //MRP
                table.Columns[5].Width = (GridLength)glc.ConvertFromString("30"); //Rate
                table.Columns[6].Width = (GridLength)glc.ConvertFromString("30"); //Amt
            }
            else
            {
                table.Columns[4].Width = (GridLength)glc.ConvertFromString("40"); //Rate
                table.Columns[5].Width = (GridLength)glc.ConvertFromString("40"); //Amt
            }
            for (int j = 0; j <= (colCount - 1); j++)
            {

                Console.WriteLine(table.Columns[j].Width);

            }

            // Bold the first cell.
            //currentRow.Cells[0].FontWeight = FontWeights.Bold;

            //    table.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table.RowGroups[0].Rows[3];

            //// Global formatting for the footer row.
            //currentRow.Background = Brushes.LightGray;
            //currentRow.FontSize = 18;
            //currentRow.FontWeight = System.Windows.FontWeights.Normal;

            //// Add the header row with content, 
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;

            //doc.FontSize = 10;
            //doc.FontFamily = new FontFamily("Fixedsys"); 
            //doc.PageHeight = printDlg.PrintableAreaHeight;
            //doc.PageWidth = printDlg.PrintableAreaWidth;
            //doc.FontStretch = FontStretches.UltraExpanded;
            //doc.LineHeight=1;
            //doc.PagePadding = new Thickness(20.0, 20.0, 20.0, 20.0);
            //doc.IsOptimalParagraphEnabled = true;
            //doc.IsHyphenationEnabled = true;
            //doc.IsColumnWidthFlexible = true;

            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //str = "---- Cash Memo ----";
            //doc.Blocks.Add(new Paragraph(new Run(str)));

            //str = "Product Name".PadRight(50 - "Product Name".Length);
            //str += "Qty@Price".PadLeft(15);
            //str += "Total".PadLeft(10);
            //Debug.WriteLine(str);

            //doc.Blocks.Add(new Paragraph(new Run(str)));
            ////doc.Blocks.Add(new Paragraph(new LineBreak()));
            //string strcon;
            //foreach(var ord in Orders)
            //{
            //    strcon = ord.ProductName.ToString().PadRight(50- ord.ProductName.ToString().Length);
            //    //strcon += new string(' ', 8);
            //    //strcon += new string(' ', 8);
            //    strcon += (ord.Quantity.ToString() +'@' + ord.Price.ToString()).PadLeft(15);
            //    //strcon += new string(' ', 8);
            //    strcon += ord.Total.ToString().PadLeft(10);
            //    Debug.WriteLine(strcon);
            //    doc.Blocks.Add(new Paragraph(new Run(strcon)));
            //}

            if (tax != null && tax.Length > 0)
            {
                str = tax;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }
            if (website != null && website.Length > 0)
            {
                str = website;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }

            if (note1 != null && note1.Length > 0)
            {
                str = note1;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }

            if (note2 != null && note2.Length > 0)
            {
                str = note2;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                doc.Blocks.Add(para);
            }
            if (advertisement != null && advertisement.Length > 0)
            {
                str = advertisement;
                para = new Paragraph(new Run(str));
                para.TextAlignment = TextAlignment.Center;
                para.FontWeight = FontWeights.Bold;
                doc.Blocks.Add(para);
            }

            doc.Name = "FlowDoc";

            // Create IDocumentPaginatorSource from FlowDocument
            IDocumentPaginatorSource idpSource = doc;
            // Call PrintDocument method to send document to printer
            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
        }



        public static string getHtmlTable<T>(IEnumerable<T> list, params Func<T, object>[] fxns)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<TABLE style='border: 1px solid black;'>\n");
            //PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //sb.Append("<TR style='border: 1px solid black;'>\n");
            //foreach (PropertyInfo prop in Props)
            //{
            //    //Defining type of data column gives proper data table 
            //    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //    //Setting column names as Property names
            //    sb.Append("<TD style='border: 1px solid black;'>");
            //    sb.Append(prop.Name);
            //    sb.Append("</TD>");


            //}
            //sb.Append("</TR>\n");
            foreach (var item in list)
            {
                sb.Append("<TR style='border: 1px solid black;'>\n");
                foreach (var fxn in fxns)
                {
                    sb.Append("<TD'>");
                    sb.Append(fxn(item));
                    sb.Append("</TD>");
                }
                sb.Append("</TR>\n");
            }
            sb.Append("</TABLE>");

            return sb.ToString();
        }

        static string readAppSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return null;
            }
        }
    }
}
