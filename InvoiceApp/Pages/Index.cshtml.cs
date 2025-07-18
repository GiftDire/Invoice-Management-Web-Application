using InvoiceApp.Services;            // for ApplicationDbContext
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace InvoiceApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        // these match the @Model.TotalInvoices references in your view
        public int TotalInvoices { get; set; }
        public int PendingInvoices { get; set; }
        public int PaidInvoices { get; set; }

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnGet()
        {
            TotalInvoices = _ctx.Invoices.Count();
            PendingInvoices = _ctx.Invoices.Count(i => i.Status == "Pending");
            PaidInvoices = _ctx.Invoices.Count(i => i.Status == "Paid");
        }
    }
}
