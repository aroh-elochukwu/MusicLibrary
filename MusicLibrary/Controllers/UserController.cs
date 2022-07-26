using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Models.ViewModels;

namespace MusicLibrary.Controllers
{
    public class UserController : Controller
    {
        private MusicLibraryContext _db { get; set; }
        public UserController(MusicLibraryContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            UserSelectViewModel vm = new UserSelectViewModel(_db.Users.ToList());
            return View(vm);
        }

        public IActionResult UserMusicLibrary(int? userId)
        {
            User user = _db.Users.Include(r => r.Collection ).First(r => r.Id == userId);

        }
    }
}
