using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using realGame.Models;
using realGame.Code;

namespace realGame.Controllers
{
   public class GamesController : Controller
   {
      private ApplicationDbContext db = new ApplicationDbContext();

      // GET: Games
      public ActionResult Index()
      {
         return View(db.Games.ToList());
      }

      // GET: Games/Details/5
      public ActionResult Details(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Game game = db.Games.Find(id);
         if (game == null)
         {
            return HttpNotFound();
         }

         ViewBag.GameSteeps = GameSteep.GetGameSteeps(game.ID, db);

         return View(game);
      }

      // GET: Games/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: Games/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "ID,UserID,Name,Description")] Game game)
      {
         if (ModelState.IsValid)
         {
            game.UserID = General.GetLoggedInUserID(User);
            db.Games.Add(game);
            db.SaveChanges();
            return RedirectToAction("Index");
         }

         return View(game);
      }

      // GET: Games/Edit/5
      public ActionResult Edit(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Game game = db.Games.Find(id);
         if (game == null)
         {
            return HttpNotFound();
         }

         ViewBag.GameSteeps = GameSteep.GetGameSteeps(game.ID, db);

         return View(game);
      }

      // POST: Games/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "ID,UserID,Name,Description")] Game game)
      {
         if (ModelState.IsValid)
         {
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(game);
      }

      // GET: Games/Delete/5
      public ActionResult Delete(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Game game = db.Games.Find(id);
         if (game == null)
         {
            return HttpNotFound();
         }

         ViewBag.GameSteeps = GameSteep.GetGameSteeps(game.ID, db);
         return View(game);
      }

      // POST: Games/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         Game game = db.Games.Find(id);
         db.Games.Remove(game);
         db.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            db.Dispose();
         }
         base.Dispose(disposing);
      }
   }
}