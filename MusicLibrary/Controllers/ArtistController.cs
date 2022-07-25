using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    public class ArtistController : Controller
    {
        private MusicLibraryContext _db { get; set; }

        public ArtistController(MusicLibraryContext context)
        {
            _db = context;
        }


        // GET: ArtistController
        public ActionResult Index()
        {
            return View(_db.Artists.ToList());
        }

        // GET: ArtistController/Details/5
        public ActionResult SongsByArtist(int id)
        {
            try
            {
                Artist artist =_db.Artists.
                    Include(a => a.Songs).
                    ThenInclude(r => r.Genre).
                    First(a => a.Id == id);

                return View(artist);
            }catch(Exception e)
            {
                return RedirectToAction("Error", "Home");
            }

            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
