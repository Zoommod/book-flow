using System.ComponentModel.DataAnnotations;

namespace BookFlow.Models;

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public int? Year { get; set; }

        public bool IsAvailable { get; set; } = true;
        
        // public ICollection<Loan>? Loans { get; set; }
    }

