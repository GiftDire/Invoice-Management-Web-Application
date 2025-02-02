using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Models
{
    public class InvoiceDto
    {
        [Required]
        public string Number { get; set; } = "";

        [Required]
        public string Status { get; set; } = "";// paid or pending
        public DateOnly? IssueDate { get; set; }
        //Dateonly represents only date without time
        //? makes it nullable ,allowing it to hold nulll when value is not assigned
        //so basically the question mark allows the user to leave the input empty as sometimes the value type can be undefined.

        public DateOnly? Duedate { get; set; }

        //details services


        [Required]
        public string service { get; set; } = "";
        [Range(1,999999, ErrorMessage ="Unit Price is not valid")]
        //The precision specify the total number of digits bore and after the decimal point.
        public decimal UnirPrice { get; set; }
        [Range(1, 99)]
        //value should be in a certain range
        public int Quantity { get; set; }

        //client details
        [Required(ErrorMessage ="Client Name is required")]
        public string Clientname { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Phone]
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";

    }
}
