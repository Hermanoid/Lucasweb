using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lucasweb.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace Lucasweb.Controllers
{
    public class SoundwebController : Controller
    {
        private LucaswebContext db = new LucaswebContext();

        private IEnumerable<string> supportedAudioTypes = new List<string>()
        {
            "mpeg",
            "wav",
            "Ogg"
        };

        public ActionResult BoringIndex()
        {
            return View(GetSoundsWithIsEditable());
        }

        // GET: Sounds
        public ActionResult Index()
        {
            return View(GetSoundsWithIsEditable());
        }

        private IEnumerable<Tuple<Sound,string>> GetSoundsWithIsEditable()
        {
            if (User.Identity.IsAuthenticated)
            {
                string currentUsername = User.Identity.GetUserName();
                List<Tuple<Sound, string>> toReturn = new List<Tuple<Sound, string>>();
                foreach(var sound in db.Sound.ToList())
                {
                    string method;
                    if(sound.OwnerName == currentUsername)
                    {
                        method = "Edit";
                    }else
                    {
                        method = "Details";
                    }
                    toReturn.Add(Tuple.Create(sound, method));
                }
                return toReturn;
            }
            else
            {
                return db.Sound.ToList().Select(sound => Tuple.Create(sound, "Details"));
            }
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

        [Authorize]
        // GET: Sounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoundID,Location,Name,Notes")] Sound sound)
        {
            sound.UploadTime = System.DateTime.Now;
            sound.OwnerName = User.Identity.GetUserName();
            try
            {
                sound.type = GetSoundType(sound.Location);
            }catch(NotSupportedException e)
            {
                ModelState.AddModelError("Location", e);
            }
            if (ModelState.IsValid)
            {
                db.Sound.Add(sound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sound);
        }

        [Authorize]
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
            if (sound.OwnerName != User.Identity.GetUserName())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not Authorized to Edit this sound");
            }
            return View(sound);
        }

        // POST: Sounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoundID,Location,Name,Notes")] Sound sound)
        {
            if (ModelState.IsValid)
            {
                if (db.Sound.Find(sound.SoundID).OwnerName != User.Identity.GetUserName())
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not Authorized to Edit this Sound");
                }
                try
                {
                    sound.type = GetSoundType(sound.Location);
                }catch(NotSupportedException e)
                {
                    ModelState.AddModelError("Location", e);
                    return View(sound);
                }


                db.Entry(sound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sound);
        }

        [Authorize]
        // GET: Sounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sound sound = db.Sound.Find(id);
            if (db.Sound.Find(sound.SoundID).OwnerName != User.Identity.GetUserName())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not Authorized to Delete this Sound.");
            }
            if (sound == null)
            {
                return HttpNotFound();
            }
            return View(sound);
        }

        // POST: Sounds/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sound sound = db.Sound.Find(id);
            if (db.Sound.Find(sound.SoundID).OwnerName != User.Identity.GetUserName())
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not Authorized to Delete this Sound.");
            }
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

        private string GetSoundType(string SoundURL)
        {
            string extension = Path.GetExtension(SoundURL);
            extension.Replace(".", "");
            if (extension == "mp3")
            {
                extension = "mpeg";
            }
            if (!supportedAudioTypes.Contains(extension, StringComparer.CurrentCultureIgnoreCase))
            {
                throw new NotSupportedException("That Sound Type is not supported in HTML5 by any browsers.");
            }
            return extension;
        }
    }
}
