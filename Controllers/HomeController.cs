using Job_search.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Job_search.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Details(int jobId)
        {
            var job = db.Jobs.Find(jobId);

            if (job == null)
            {
                return HttpNotFound();
            }
            Session["jobId"] = jobId;
            return View(job);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Apply(string Massage)
        {
            var UserId = User.Identity.GetUserId();
            var jobId = (int)Session["jobId"];
            var check = db.ApplyForJobs.Where(a => a.jobsId == jobId && a.userId == UserId).ToList();
            if (check.Count < 1)
            {
                var job = new ApplyForJob();
                job.userId = UserId;
                job.jobsId = jobId;
                job.Massage = Massage;
                job.ApplyDate = DateTime.Now;
                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                ViewBag.massage = "تم التقدم الى الوظيفة بنجاح";
            }
            else
            {
                ViewBag.result = "المعذرة لقد تقدمت الى هذه الوظيفة من قبل!";
            }
            return View();
        }
        [Authorize]

        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var jobs = db.ApplyForJobs.Where(a => a.userId == UserId);
            return View(jobs.ToList());
        }
        public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        //----------Edit Of Job -----------

        public ActionResult EditOfJobs(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        [HttpPost]
        public ActionResult EditOfJobs(ApplyForJob job)
        {

            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);
        }

        //----------Delete Of Job -----------
        public ActionResult DeleteOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }


        [HttpPost]
        public ActionResult DeleteOfJob(ApplyForJob job)
        {
            var myjob = db.ApplyForJobs.Find(job.Id);
            db.ApplyForJobs.Remove(myjob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");
        }
        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var userId = User.Identity.GetUserId();
            var job = from app in db.ApplyForJobs
                      join Job in db.Jobs
                      on app.jobsId equals Job.Id
                      where Job.user.Id == userId
                      select app;

            var groubed = from j in job
                          group j by j.jobs.JobTitle
                          into gr
                          select new JobsViewModelByGroup
                          {
                              jobTitle = gr.Key,
                              Items = gr
                          };
            return View(groubed.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string gsearch)
        {
            var result = db.Jobs.Where(a => a.JobTitle.Contains(gsearch)
                         || a.JobContent.Contains(gsearch)
                         || a.Category.Categoryname.Contains(gsearch)
                         || a.Category.CategoryDescription.Contains(gsearch)).ToList();
            return View(result);
        }

    }
}