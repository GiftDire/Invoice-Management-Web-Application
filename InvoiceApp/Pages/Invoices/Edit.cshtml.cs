using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvoiceApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new InvoiceDto();

        //used to store the invoice details
        public Invoice Invoice { get; set; } = new();


        private readonly ApplicationDbContext context;

        public EditModel(ApplicationDbContext context) 
        {
            this.context = context;
        }  
        public IActionResult OnGet(int id)
        {
            //reading a value fromtheh database that matches the ID on the parameters
            var invoice = context.Invoices.Find(id);//finding the invoice by id
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");//redirecting the user
            }

            Invoice = invoice;

            InvoiceDto.Number = invoice.Number;
            InvoiceDto.Status = invoice.Status;
            InvoiceDto.IssueDate = invoice.IssueDate;
            InvoiceDto.Duedate = invoice.Duedate;

            InvoiceDto.service = invoice.service;
            InvoiceDto.UnirPrice = invoice.UnirPrice;
            InvoiceDto.Quantity = invoice.Quantity;

            InvoiceDto.Clientname = invoice.Clientname;
            InvoiceDto.Email = invoice.Email;
            InvoiceDto.Phone = invoice.Phone;
            InvoiceDto.Address = invoice.Address;
           
            return Page();
        }

        public string successMessage = "";

        public IActionResult OnPost(int id)
        {
            var invoice = context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            Invoice = invoice;

            if (!ModelState.IsValid)
            {

                return Page();
            }
            InvoiceDto.Number = invoice.Number;
            InvoiceDto.Status = invoice.Status;
            InvoiceDto.IssueDate = invoice.IssueDate;
            InvoiceDto.Duedate = invoice.Duedate;

            InvoiceDto.service = invoice.service;
            InvoiceDto.UnirPrice = invoice.UnirPrice;
            InvoiceDto.Quantity = invoice.Quantity;

            InvoiceDto.Clientname = invoice.Clientname;
            InvoiceDto.Email = invoice.Email;
            InvoiceDto.Phone = invoice.Phone;
            InvoiceDto.Address = invoice.Address;


            context.SaveChanges();

            successMessage = "Invoice updated successfully";

            return Page();
        }
    }
}
