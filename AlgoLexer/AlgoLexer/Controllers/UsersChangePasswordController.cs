using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgoLexerApi.Database;
using AlgoLexer.Extention;
using AlgoLexerApi.Models.Models;
using AlgoLexerApi.Models.ViewModels;

namespace AlgoLexer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersChangePasswordController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersChangePasswordController()
        {
            _context = new UserDbContext();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangePassword(int id, UserChangePassword user)
        {
            User dbUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (id != dbUser.Id)
            {
                return BadRequest();
            }

            if (dbUser is User && dbUser.Password.CheckPassword(user.Password) && !dbUser.Password.CheckPassword(user.NewPassword))
            {
                dbUser.Password = user.NewPassword.ToPassword();
            }
            else
            {
                return NotFound();
            }

            _context.Entry(dbUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }
        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
