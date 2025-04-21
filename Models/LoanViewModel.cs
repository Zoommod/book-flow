using BookFlow.Models;

public class LoanViewModel
{
    public LoanModel NewLoan{ get; set; } = new();
    public IEnumerable<LoanModel> Loans { get; set; } = new List<LoanModel>();
}
