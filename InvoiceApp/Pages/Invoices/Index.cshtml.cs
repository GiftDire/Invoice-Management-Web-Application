using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InvoiceApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
    }
}
