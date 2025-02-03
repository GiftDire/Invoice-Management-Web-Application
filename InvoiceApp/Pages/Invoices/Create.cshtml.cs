using InvoiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public InvoiceDto InvoiceDto { get; set; } = new();
        public void OnGet()
        {
        }
    }
}
