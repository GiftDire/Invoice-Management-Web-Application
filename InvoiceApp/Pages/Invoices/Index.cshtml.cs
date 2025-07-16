using InvoiceApp.Models;
using InvoiceApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;//adding the EF.functions.like

namespace InvoiceApp.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<Invoice> invoicelist = new List<Invoice>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        //bind search item for the query string 
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } 
        public void OnGet()
        {
            invoicelist = context.Invoices.OrderByDescending(i =>i.Id).ToList();

            var q = context.Invoices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                q =q.Where(i => EF.Functions.Like(i.Number, $"%{SearchTerm}%") ||
                                EF.Functions.Like(i.Clientname, $"%{SearchTerm}%") ||
                                EF.Functions.Like(i.Email, $"%{SearchTerm}%") ||
                                EF.Functions.Like(i.Phone, $"%{SearchTerm}%") ||
                                EF.Functions.Like(i.Address, $"%{SearchTerm}%"));
            }
            invoicelist = q.OrderByDescending(i => i.Id).ToList();
        }
        
        public IActionResult OnPostMarkPaid(int id)
        {
            var inv = context.Invoices.Find(id);
            if(inv != null && inv.Status != "Paid")
            {
                inv.Status = "Paid";
                context.SaveChanges();
            }
            return RedirectToPage(new { SearchTerm });
        }
        
    }
}
