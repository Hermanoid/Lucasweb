using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lucasweb.Models;

namespace Lucasweb.Controllers
{
    public class SoundwebController : Controller
    {
        private LucaswebContext db = new LucaswebContext();

        public ActionResult BoringIndex()
        {
            return View(db.Sound.ToList());
        }

        // GET: Sounds
        public ActionResult Index()
        {
            return View(db.Sound.ToList());
        }

        // GET: Sounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sound sound = db.Sound.Find(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // GET: Sounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoundID,Location,type,Name,OwnerName,Notes")] Sound sound)
        {
            sound.UploadTime = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Sound.Add(sound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sound);
        }

        // GET: Sounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sound sound = db.Sound.Find(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // POST: Sounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoundID,Location,type,Name,Notes")] Sound sound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sound);
        }

        // GET: Sounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sound sound = db.Sound.Find(id);
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // POST: Sounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sound sound = db.Sound.Find(id);
            db.Sound.Remove(sound);
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
