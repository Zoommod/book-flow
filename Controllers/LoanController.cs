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
                Loans = _db.Loan.OrderByDescending(x => x.LastUpdatedDate).ToList()
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
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Houve um erro ao realizar o cadastro!";

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
                    TempData["MensagemSucesso"] = "Edição realizada com sucesso!";
                }
                TempData["MensagemErro"] = "Houve um erro ao realizar a edição!";

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
                TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";
            }
            TempData["MensagemErro"] = "Houve um erro ao realizar a remoção!";

            return RedirectToAction("Index");
        }


    }
}
