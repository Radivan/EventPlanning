using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanning.Models;

namespace EventPlanning.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        EventsEntities db = new EventsEntities();

        [HttpPost]
        public ActionResult EventSearch(string title)
        {
            List<int> actives = db.Members.Where(x => x.MemberName == User.Identity.Name).Select(x => x.IdEvent).ToList();
            ViewBag.Actives = actives;

            var events = db.Events.Where(e => e.Title.Contains(title)).ToList();
            var add = db.Events.Where(e => e.Place.Contains(title)).ToList();

            events = events.Union(add).ToList();

            if (events.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(events);
        }

        public ActionResult Index()
        {
            List<int> actives = db.Members.Where(x => x.MemberName == User.Identity.Name).Select(x => x.IdEvent).ToList();
            ViewBag.Actives = actives;
            ViewBag.Events = db.Events;
            return View();
        }
        [HttpGet]
        public ActionResult Join(int id = 0)
        {
            if (id != 0)
            {
                Member m = db.Members.FirstOrDefault(x => x.IdEvent == id && x.MemberName == User.Identity.Name);
                if (m != null)
                {
                    return View("Delete",m);
                }
                else
                {
                    m = new Member { IdEvent = id, MemberName = User.Identity.Name };
                    db.Members.Add(m);
                    db.SaveChanges();
                    return View("Joined");
                }
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(Member m)
        {
            m = db.Members.FirstOrDefault(x => x.IdEvent == m.IdEvent && x.MemberName == User.Identity.Name);

            if (m == null)
                return HttpNotFound();
            db.Members.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "administrator")]
        [HttpGet]
        public ActionResult CreateEvent()
        {
            //SelectList faculties = new SelectList(db.Faculty, "Id", "Title");
            //ViewBag.Faculties = faculties;
            return View();
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public ActionResult CreateEvent([Bind(Include = "Title,Place,Organizer,Date,Id")]Event e)
        {
            if (ModelState.IsValid)
            {
                e.Organizer = User.Identity.Name;
                db.Events.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}