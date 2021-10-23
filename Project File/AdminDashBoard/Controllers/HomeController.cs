using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AdminDashBoard.Models;

namespace AdminDashBoard.Controllers
{
    public class HomeController : Controller
    {
        private Recharge1Entities db = new Recharge1Entities();
       

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.admin = Session["adminid"];
            if (Session["adminid"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "AdminLogin");
        }

        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;

            //file name to be created   
            string strPDFFileName = string.Format("TransactionDetails" + dTime.ToString("dd") + "-" + ".pdf");
            Document doc = new Document();

            doc.SetMargins(0f, 0f, 0f, 0f);

            //Create PDF Table with 5 columns  

            PdfPTable tableLayout = new PdfPTable(5);
            doc.SetMargins(0f, 0f, 0f, 0f);

            //Create PDF Table  

            //file will created in this path  
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 50, 24, 45, 35, 50 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            List<Transaction> Transactions = db.Transactions.ToList<Transaction>();



            tableLayout.AddCell(new PdfPCell(new Phrase("Creating Pdf using ItextSharp", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) {
                Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER
            });


            //Add header  
            AddCellToHeader(tableLayout, "Transaction_id");
            AddCellToHeader(tableLayout, "Name");
            AddCellToHeader(tableLayout, "Phone Number");
            AddCellToHeader(tableLayout, "Operator Name");
            AddCellToHeader(tableLayout, "Plan Name");

            //Add body  

            foreach (var emp in Transactions)
            {

                AddCellToBody(tableLayout, emp.transaction_id.ToString());
                AddCellToBody(tableLayout, emp.User.name.ToString());
                AddCellToBody(tableLayout, emp.phone_number);
                AddCellToBody(tableLayout, emp.Operator.operator_name);
                AddCellToBody(tableLayout, emp.Plan.plan_name);

            }

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
    });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
             {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
    });
        }
    }
}
