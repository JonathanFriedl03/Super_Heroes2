using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes2.Data;
using SuperHeroes2.Models;

namespace SuperHeroes2.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SuperHeroesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: SuperHeroes
        public ActionResult Index()
        {
            var superHeroes = _db.SuperHeroes.ToList();

            return View(superHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var superHero = _db.SuperHeroes.Where(q => q.Id == id).SingleOrDefault();
            return View(superHero);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                _db.Add(superHero);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero superHero = _db.SuperHeroes.Where(q => q.Id == id).FirstOrDefault();
            return View(superHero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here
                SuperHero hero2Update = _db.SuperHeroes.Where(q => q.Id == id).FirstOrDefault();
                hero2Update.Name = superHero.Name;
                hero2Update.AlterEgo = superHero.AlterEgo;
                hero2Update.MainPower = superHero.MainPower;
                hero2Update.SecondaryPower = superHero.SecondaryPower;
                hero2Update.CatchPhrase = superHero.CatchPhrase;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero super = _db.SuperHeroes.Where(q => q.Id == id).FirstOrDefault();
            return View(super);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero super)
        {
            try
            {
                // TODO: Add delete logic here
                var superHero = _db.SuperHeroes.Where(q => q.Id == id).FirstOrDefault();
                _db.Remove(superHero);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}