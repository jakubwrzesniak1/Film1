using Film1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film1.Controllers
{
    public class FilmController : Controller
    {
        public static IList<Film> films = new List<Film>
        {
            new Film() { Id = 1, Name = "Film1", Description = "opis1" , Price = 4},
            new Film() { Id = 2, Name = "Film2", Description = "opis2" , Price = 5},
            new Film() { Id = 3, Name = "Film3", Description = "opis3" , Price = 6},
            new Film() { Id = 4, Name = "Film4", Description = "opis4" , Price = 4}

        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }
        
        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
                return RedirectToAction(nameof(Index));
           
                
            
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound(); // Zwraca błąd 404, jeśli film o podanym ID nie istnieje
            }
            return View(film);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            var existingFilm = films.FirstOrDefault(x => x.Id == id);
          

            
            existingFilm.Name = film.Name;
            existingFilm.Description = film.Description;
            existingFilm.Price = film.Price;

            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
           
            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film film)
        {
            var deletedFilm = films.FirstOrDefault(x => x.Id == id); 
            if (deletedFilm != null)
            {
                films.Remove(deletedFilm); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
