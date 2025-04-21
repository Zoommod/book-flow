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

        [HttpGet("emprestimo")]
        public IActionResult Index()
        {
            var viewModel = new LoanViewModel
            {
                Loans = _db.Loan.OrderByDescending(x => x.LastUpdatedDate)
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(LoanViewModel viewModel)
        {
            if(ModelState.IsValid){
                var loan = viewModel.NewLoan;
                loan.LastUpdatedDate = DateTime.Now;
                _db.Loan.Add(loan);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", new LoanViewModel {
                NewLoan = viewModel.NewLoan,
                Loans = _db.Loan.OrderByDescending(x => x.LastUpdatedDate).ToList()           
            });    
            
        }

    }
}
