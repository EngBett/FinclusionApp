using System.Threading.Tasks;
using AccManagement.Data.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccManagement.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class TransactionController : Controller
    {
        private readonly IAccountTransactionRepository _accountTransactionRepo;

        public TransactionController(IAccountTransactionRepository accountTransactionRepo)
        {
            _accountTransactionRepo = accountTransactionRepo;
        }
        
        public async Task<IActionResult> Index()
        {
            var transactions = await _accountTransactionRepo.GetTransactionsAsync();
            return View(transactions);
        }
    }
}