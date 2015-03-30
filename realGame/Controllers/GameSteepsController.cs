using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using realGame.Models;

namespace realGame.Controllers
{
   public class GameSteepsController : Controller
   {
      private ApplicationDbContext db = new ApplicationDbContext();

      // GET: GameSteeps
      public ActionResult Index(int? gameID)
      {
         List<GameSteep> gameSteeps = null;
         if (gameID.HasValue)
            gameSteeps = GameSteep.GetGameSteeps(gameID.GetValueOrDefault(), db);

         return View(gameSteeps);
      }

      public ActionResult _Index(int? gameID)
      {
         List<GameSteep> gameSteeps = null;
         if (gameID.HasValue)
            gameSteeps = GameSteep.GetGameSteeps(gameID.GetValueOrDefault(), db);

         ViewBag.GameID = gameID.GetValueOrDefault();
         return PartialView(gameSteeps);
      }

      // GET: GameSteeps/Details/5
      public ActionResult Details(int? id)
      {
         if (id == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         GameSteep gameSteep = db.GameSteep.Find(id);
         if (gameSteep == null)
         {
            return HttpNotFound();
         }
         return View(gameSteep);
      }

      // GET: GameSteeps/Create
      public ActionResult Create(int? gameID)
      {
         if (gameID.HasValue)
         {
            ViewBag.GameID = gameID;
            ViewBag.NextSteepNo = GameSteep.GetNextSteepID(gameID.GetValueOrDefault(), db);
            return View();
         }
         else
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      // POST: GameSteeps/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "ID,GameID,SteepNo,Description,Answer,Question,NextPoint")] GameSteep gameSteep)
      {
         gameSteep.SteepID = System.Guid.NewGuid().ToString();
         if (ModelState.IsValid)
         {
            db.GameSteep.Add(gameSteep);
            db.SaveChanges();
            return RedirectToAction("Details", "Games", new { id = gameSteep.GameID } );
         }

         return View(gameSteep);
      }

      // GET: GameSteeps/Edit/5
      public ActionResult Edit(int? id, int? gameID)
      {
         if (id == null || gameID == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         GameSteep gameSteep = db.GameSteep.Find(id);
         if (gameSteep == null)
         {
            return HttpNotFound();
         }
         return View(gameSteep);
      }

      // POST: GameSteeps/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "ID,GameID,SteepNo,Description,Answer,Question,NextPoint,SteepID")] GameSteep gameSteep)
      {
         if (ModelState.IsValid)
         {
            db.Entry(gameSteep).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", "Games", new { id = gameSteep.GameID });
         }
         return View(gameSteep);
      }

      // GET: GameSteeps/Delete/5
      public ActionResult Delete(int? id, int? gameID)
      {
         if (id == null || gameID == null)
         {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         GameSteep gameSteep = db.GameSteep.Find(id);
         if (gameSteep == null)
         {
            return HttpNotFound();
         }
         return View(gameSteep);
      }

      // POST: GameSteeps/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id)
      {
         GameSteep gameSteep = db.GameSteep.Find(id);
         db.GameSteep.Remove(gameSteep);
         db.SaveChanges();
         return RedirectToAction("Details", "Games", new { id = gameSteep.GameID });
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