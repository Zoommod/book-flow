using BookFlow.Data;
using BookFlow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookFlow.Controllers
{
    public class LoanController : Controller{
        readonly private ApplicationDbContext _db;
        public LoanController(ApplicationDbContext db){
            _db = db;
        }
    
        public IActionResult Index(){
            IEnumerable<LoanModel> loan = _db.Loan;
            return View(loan);
        }
    }
}
