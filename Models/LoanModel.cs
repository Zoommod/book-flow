using System;
using System.ComponentModel.DataAnnotations;

namespace BookFlow.Models;

public class LoanModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo Solicitante é obrigatório.")]
    public string Borrower { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo Fornecedor é obrigatório.")]
    public string Supplier { get; set; } = string.Empty;
    [Required(ErrorMessage = "O campo Livro Emprestado é obrigatório.")]
    public string BorrowedBook { get; set; } = string.Empty;
    public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
}
