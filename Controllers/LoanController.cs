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

        [HttpPost]
        public IActionResult Edit(LoanModel loan)
        {
            if (ModelState.IsValid)
            {
                var existingLoan = _db.Loan.FirstOrDefault(l => l.Id == loan.Id);

                if (existingLoan != null)
                {
                    existingLoan.Borrower = loan.Borrower;
                    existingLoan.Supplier = loan.Supplier;
                    existingLoan.BorrowedBook = loan.BorrowedBook;
                    existingLoan.LastUpdatedDate = DateTime.Now;

                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            var viewModel = new LoanViewModel
            {
                Loans = _db.Loan.OrderByDescending(x => x.LastUpdatedDate).ToList(),
                NewLoan = new LoanModel()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var loan = _db.Loan.FirstOrDefault(l => l.Id == id);

            if (loan != null)
            {
                _db.Loan.Remove(loan);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}
