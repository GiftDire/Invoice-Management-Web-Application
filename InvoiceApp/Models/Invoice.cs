using Microsoft.EntityFrameworkCore;
using System.Security;

namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string Number { get; set; } = "";
        public string Status { get; set; } = "";// paid or pending
        public DateOnly? IssueDate { get; set; }
        //Dateonly represents only date without time
        //? makes it nullable ,allowing it to hold nulll when value is not assigned
        //so basically the question mark allows the user to leave the input empty as sometimes the value type can be undefined.

        public DateOnly? Duedate { get; set; }

        //details services 
        public string service { get; set; } = "";
        [Precision(16,2)]
        //The precision specify the total number of digits bore and after the decimal point.
        public decimal UnirPrice { get; set; } 
        public int Quantity { get; set; }

        //client details
        public string Clientname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone{ get; set; } = "";
        public string Address { get; set; } = "";



    }
}
