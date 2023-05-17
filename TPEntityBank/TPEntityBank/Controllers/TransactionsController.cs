using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPEntityBank.DataBase;
using TPEntityBank.Models;

namespace TPEntityBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        BankDbContext context;

        public TransactionsController()
        {
            context = new BankDbContext();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> RecupererTout()
        {
            return context.Transactions != null ? context.Transactions.ToList() : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> RecupererUn(int id)
        {
            Transaction tran = await context.Transactions.FirstOrDefaultAsync(t=>t.Id==id);
            return tran is Transaction ? tran : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> Ajouter(Transaction transaction)
        {
            if (transaction == null)
            {
                return NoContent();
            }
            if (transaction.CompteCrediteur == transaction.CompteDebiteur)
            {
                return BadRequest("Les comptes doivent etre differents !");
            }
            context.Add(transaction);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Transaction>> Modifier(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest("Vous ne devez pas changer l'ID");
            }
            context.Entry(transaction).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return transaction;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Supprimer(int id)
        {
            Transaction tran = await context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            if (tran is Transaction)
            {
                context.Remove(tran);
                await context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

    }
}
