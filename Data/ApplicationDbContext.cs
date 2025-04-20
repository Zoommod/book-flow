using System;
using BookFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace BookFlow.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<LoanModel> Loan { get; set; } = null!;
}
