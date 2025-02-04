using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new();

        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        //requesting the applicationdb context from the service container using a contructor
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            
            
            }

            var invoice = new Invoice
            {
                Number = InvoiceDto.Number,
                Status = InvoiceDto.Status,
                IssueDate = InvoiceDto.IssueDate,
                Duedate = InvoiceDto.Duedate,

                service = InvoiceDto.service,
                UnirPrice = InvoiceDto.UnirPrice,
                Quantity = InvoiceDto.Quantity,

                Clientname = InvoiceDto.Clientname,
                Email = InvoiceDto.Email,
                Phone = InvoiceDto.Phone,
                Address = InvoiceDto.Address,


            };
            context.Invoices.Add(invoice);//saving the variable to the database
            context.SaveChanges();//save the modification

            //redirecting the user to the invoice page

            return RedirectToPage("/Invoices/Index");
        
        }
    }
}
