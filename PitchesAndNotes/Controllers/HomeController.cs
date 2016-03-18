using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using PitchesAndNotes.Models;
using PitchesAndNotes.ViewModels;

namespace PitchesAndNotes.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Events = new List<Event>();
            List<Event> Events = db.Events.ToList();
            if(Events.Count != 0)
            {
                for(int i = 0; i < Events.Count; i++)
                {
                    hvm.Events.Add(Events[i]);
                    if(i == 2)
                    {
                        break;
                    }
                }        
            }

            return View(hvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Members()
        {
            return View();
        }

        public ActionResult Listen()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Auditions()
        {
            return View();
        }

        public ActionResult Merchandise()
        {
            return View();
        }

        public ActionResult Donors()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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