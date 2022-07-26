using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Models.ViewModels;

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

        // GET: Songs by Artist
        public ActionResult SongsByArtist(int? artistId)
        {
            ArtistSelectViewModel vm;

            if (artistId != null)
            {
                try
                {
                    Artist artist = _db.Artists.Include(r => r.Songs).ThenInclude(r => r.Collections).First(r => r.Id == artistId);
                    return View(artist);
                }catch
                {
                    return RedirectToAction("Error", "Home");
                }
                
            }else
            {
                return RedirectToAction("Error", "Home");
            }
            
            
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
