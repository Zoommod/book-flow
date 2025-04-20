using System;

namespace BookFlow.Models;

public class LoanModel
{
    public int Id { get; set; }
    public string Borrower { get; set; } = string.Empty;
    public string Supplier { get; set; } = string.Empty;
    public string BorrowedBook { get; set; } = string.Empty;
    public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
}
