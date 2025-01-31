namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string Number { get; set; } = "";
        public string Status { get; set; } = "";
        public DateOnly? IssueDate { get; set; }
        //Dateonly represents only date without time
        //? makes it nullable ,allowing it to hold nulll when value is not assigned
        //so basically the question mark allows the user to leave the input empty as sometimes the value type can be undefined.

        public DateOnly? Duedate { get; set; }


    }
}
