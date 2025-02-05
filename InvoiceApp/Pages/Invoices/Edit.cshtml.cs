using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Pages.Invoices
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new InvoiceDto();

        public Invoice Invoice { get; set; } = new();

        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            // Reading a value from the database that matches the ID in the parameters
            var invoice = _context.Invoices.Find(id); // Finding the invoice by id
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index"); // Redirecting the user
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
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
            {
                return RedirectToPage("/Invoices/Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Updating the invoice with new values from InvoiceDto
            invoice.Number = InvoiceDto.Number;
            invoice.Status = InvoiceDto.Status;
            invoice.IssueDate = InvoiceDto.IssueDate;
            invoice.Duedate = InvoiceDto.Duedate;

            invoice.service = InvoiceDto.service;
            invoice.UnirPrice = InvoiceDto.UnirPrice;
            invoice.Quantity = InvoiceDto.Quantity;

            invoice.Clientname = InvoiceDto.Clientname;
            invoice.Email = InvoiceDto.Email;
            invoice.Phone = InvoiceDto.Phone;
            invoice.Address = InvoiceDto.Address;

            _context.SaveChanges();

            successMessage = "Invoice updated successfully";

            return Page();
        }
    }
}
