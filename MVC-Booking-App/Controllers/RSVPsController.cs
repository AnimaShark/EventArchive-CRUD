using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Booking_App.Models;

namespace MVC_Booking_App.Controllers
{
    public class RSVPsController : Controller
    {
        private RSVPDbContext db = new RSVPDbContext();

        // GET: RSVPs
        public ActionResult Index(string eventGenre, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Events
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.eventGenre = new SelectList(GenreLst);

            var Ev = from e in db.Events
                         select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                Ev = Ev.Where(s => s.EventName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(eventGenre))
            {
                Ev = Ev.Where(x => x.Genre == eventGenre);
            }

            return View(Ev);
        }

        // GET: RSVPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.Events.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            return View(rSVP);
        }

        // GET: RSVPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RSVPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EventName,Date,Genre,Price,TicketQuota")] RSVP rSVP)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(rSVP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rSVP);
        }

        // GET: RSVPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.Events.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            return View(rSVP);
        }

        // POST: RSVPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EventName,Date,Genre,Price,TicketQuota")] RSVP rSVP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rSVP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rSVP);
        }

        // GET: RSVPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RSVP rSVP = db.Events.Find(id);
            if (rSVP == null)
            {
                return HttpNotFound();
            }
            return View(rSVP);
        }

        // POST: RSVPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RSVP rSVP = db.Events.Find(id);
            db.Events.Remove(rSVP);
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
