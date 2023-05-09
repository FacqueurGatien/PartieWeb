using AlgoLexer.Extention;
using AlgoLexerApi.Database;
using AlgoLexerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public User? Login(User _user)
        {
            User user = _context.Users.FirstOrDefault(u=>u.UserName == _user.UserName);
            return user.Password.CheckPassword(_user.Password)?user:default;
        }
    }
}
