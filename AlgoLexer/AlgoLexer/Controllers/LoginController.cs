using AlgoLexer.Extention;
using AlgoLexerApi.Database;
using AlgoLexerApi.Models.Models;
using AlgoLexerApi.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace AlgoLexer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserDbContext _context;
        public LoginController() 
        {
            _context = new UserDbContext();
        }

        [HttpPost]
        public async Task<ActionResult<UserReadViewModel?>>  Login(User _user)
        {
            /*UserReadViewModel user = new UserReadViewModel() { Id = (await _context.Users.FirstOrDefaultAsync(u => u.UserName == _user.UserName)).Id, UserName = (await _context.Users.FirstOrDefaultAsync(u => u.UserName == _user.UserName)).UserName };
            return (await _context.Users.FirstOrDefaultAsync(u => u.UserName == _user.UserName)).Password.CheckPassword(_user.Password) ? user : NotFound();*/
            User user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == _user.UserName);
            return user.Password.CheckPassword(_user.Password) ? new UserReadViewModel() { Id=user.Id ,UserName = user.UserName } : NotFound();
        }
    }
}
