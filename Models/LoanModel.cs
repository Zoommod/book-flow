using System;

namespace BookFlow.Models;

public class LoanModel
{
    public int Id { get; set; }
    public string Borrower { get; set; }
    public string Supplier { get; set; }
    public string BorrowedBook { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.Now;
}
