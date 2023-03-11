using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Model.ViewModel.Account;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {

        private List<ViewModelAccount> GetCharges()
        {
            User user = (User)Session["User"];
            Resident resident = (Resident)Session["Resident"];
            ServiceAccount service = new ServiceAccount();

            List<ViewModelAccount> list = new List<ViewModelAccount>();
            IEnumerable<Charge> charges = user.IdRol == 1 ? service.GetCharges() : service.GetChargesByResidentEmail(resident.EmailUser);

            foreach (var item in charges)
            {
                ViewModelAccount model = new ViewModelAccount()
                {
                    Id = item.Id,
                    email = item.Resident.EmailUser,
                    name = item.Resident.Name,
                    lastName = item.Resident.LastName,
                    month = item.Month,
                    year = item.Year,
                    total = item.Total,
                    cancelled= item.Cancelled,

                };
                list.Add(model);
            }

            return list;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View(GetCharges());
        }

        public ActionResult Detail(int id)
        {
            ServiceAccount service = new ServiceAccount();
            ServicePlan servicePlan = new ServicePlan();
            Charge charge = service.GetChargeByChargeId(id);
            ViewModelAccount model = new ViewModelAccount()
            {
                Id = id,
                email = charge.Resident.EmailUser,
                name = charge.Resident.Name,
                lastName = charge.Resident.LastName,
                month = charge.Month,
                year = charge.Year,
                total = charge.Total,
                cancelled = charge.Cancelled,
                notes = charge.Notes,
                PlanName = charge.Plan.Name,
                collection = servicePlan.GetPlan(charge.IdPlan).Collection,
                houseNumber = charge.Resident.HouseNumber


            };

            return View(model);
        }

        public ActionResult Admin()
        {
            User user = (User)Session["User"];

            if (user.IdRol == 1)
            {
                ServiceResident service = new ServiceResident();
                return View(service.GetResidents());
            }
            return View("/");
        }

        public ActionResult Pending(int id)
        {
            ServiceAccount service = new ServiceAccount();

            List<ViewModelAccount> list = new List<ViewModelAccount>();
            var listCharges = service.GetPendingChargesByResidentId(id);
                foreach (var item in listCharges)
                {

                    ViewModelAccount model = new ViewModelAccount()
                    {
                        Id = item.Id,
                        email = item.Resident.EmailUser,
                        name = item.Resident.Name,
                        lastName = item.Resident.LastName,
                        month = item.Month,
                        year = item.Year,
                        total = item.Total,
                        cancelled = item.Cancelled,
                        notes = item.Notes

                    };
                    list.Add(model);
            }

            return View(list);
        } 
        public ActionResult Cancelled(int id)
        {
            ServiceAccount service = new ServiceAccount();

            List<ViewModelAccount> list = new List<ViewModelAccount>();
            var listCharges = service.GetCancelledChargesByResidentId(id);
                foreach (var item in listCharges)
                {

                    ViewModelAccount model = new ViewModelAccount()
                    {
                        Id = item.Id,
                        email = item.Resident.EmailUser,
                        name = item.Resident.Name,
                        lastName = item.Resident.LastName,
                        month = item.Month,
                        year = item.Year,
                        total = item.Total,
                        cancelled = item.Cancelled,
                        notes = item.Notes

                    };
                    list.Add(model);
            }

            return View(list);
        }
        public ActionResult ShowTable()
        {
            // Generate the PDF table
            byte[] pdfBytes = GenerateTable();

            // Return the PDF file as a file result
            return File(pdfBytes, "application/pdf");
        }
        private byte[] GenerateTable()
        {
            // Create a memory stream to store the PDF file
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a PDF document
                PdfDocument pdf = new PdfDocument(new PdfWriter(memoryStream));

                // Create a document layout
                Document document = new Document(pdf);

                // Create a table with 3 columns
                Table table = new Table(new float[] { 2, 2, 1, 1, 1, 1, 5 });

                // Add header cells to the table
                table.AddHeaderCell(new Cell().Add(new Paragraph("Email")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Name")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Month")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Year")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Total")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Cancelled")));
                table.AddHeaderCell(new Cell().Add(new Paragraph("Notes")));

                // Add data rows to the table
                foreach (var item in GetCharges())
                {
                    //table.AddCell(new Cell().Add(new Paragraph("\""+item.email+item.fullName + "," + item.monthName + ","+
                    //    item.year + ","+item.totalColones + ","+item.cancelledName + ","+item.notes+"\"")));
                    table.AddCell(item.email);
                    table.AddCell(item.fullName);
                    table.AddCell(item.monthName);
                    table.AddCell(item.year.ToString());
                    table.AddCell(item.totalColones);
                    table.AddCell(item.cancelledName);
                    table.AddCell(item.notes);
                }
                //table.AddCell(new Cell().Add(new Paragraph("Row 1, Column 2")));
                //table.AddCell(new Cell().Add(new Paragraph("Row 1, Column 3")));
                //table.AddCell(new Cell().Add(new Paragraph("Row 2, Column 1")));
                //table.AddCell(new Cell().Add(new Paragraph("Row 2, Column 2")));
                //table.AddCell(new Cell().Add(new Paragraph("Row 2, Column 3")));

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();

                // Return the memory stream as a byte array
                return memoryStream.ToArray();
            }
        }
    }
}