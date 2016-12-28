using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using PitchesAndNotes.Models;
using PitchesAndNotes.ViewModels;
using System.Net;

namespace PitchesAndNotes.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            try
            {
                Event nextEvent = db.Events.First(x => x.Date >= System.DateTime.Now);
                hvm.Event = nextEvent;
            } catch (System.InvalidOperationException ex)
            {
                hvm.Event = null;
            }
           

            return View(hvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Donations()
        {
            return View("Donors");
        }

        public ActionResult Members()
        {

            return View(db.Members.ToList());
        }

        [HttpGet]
        public ActionResult IAmAPitch()
        {
            return View();
        }

        public ActionResult Listen()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View(db.Events.ToList());
        }

        [HttpGet]
        public ActionResult AddAdministrators()
        {
            return View(db.Members.ToList());
        }

        [HttpGet]
        public ActionResult AddAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View("Details", member);
        }

        public ActionResult AddAdmin(string email)
        {
            ApplicationUser user = db.Users.Where(model => model.Email.Equals(email)).First();
            

            return RedirectToAction("AddAdministrators", "Home");
        }

        public ActionResult Auditions()
        {
            return View();
        }

        public ActionResult Merchandise()
        {
            return View();
        }

        public ActionResult Contact()
        {
            Dictionary<string, Member> positionMap = new Dictionary<string, Member>();
            List<Member> members = db.Members.ToList();
            foreach(Member member in members)
            {
                if(member.Position != null)
                {
                    string position = member.Position.Trim();
                    member.Position = position;
                    positionMap.Add(position, member);
                }
            }
            return View(positionMap);
        }

        [HttpGet]
        public ActionResult UpdateEvents()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateEvents([Bind(Include = "Title,Description,Date,Id")] Event eventNew)
        {

            db.Events.Add(eventNew);
            db.SaveChanges();
            return View();

            //if (ModelState.IsValid)
            //{
            //    db.Events.Add(eventNew);
            //    db.SaveChanges();
            //    return View("Index");
            //}
            //else
            //{
            //    return View("Failed");
            //}
        }
    }
}