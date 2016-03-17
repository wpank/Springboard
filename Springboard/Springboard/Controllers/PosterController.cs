using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Springboard.Models;

namespace Springboard.Controllers
{
    public class PosterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Poster
        public ActionResult Index()
        {
            var jobPostings = db.JobPostings.Include(j => j.Culture).Include(j => j.SkillRequirement).Include(j => j.User);
            return View(jobPostings.ToList());
        }

        // GET: Poster/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // GET: Poster/Create
        public ActionResult Create()
        {
            ViewBag.CultureId = new SelectList(db.Cultures, "Id", "Id");
            ViewBag.SkillRequirementId = new SelectList(db.SkillRequirements, "Id", "Id");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Poster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobTitle,JobDescription,UserId,CultureId,SkillRequirementId")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                jobPosting.Id = Guid.NewGuid();
                db.JobPostings.Add(jobPosting);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = jobPosting.Id });
            }

            ViewBag.CultureId = new SelectList(db.Cultures, "Id", "Id", jobPosting.CultureId);
            ViewBag.SkillRequirementId = new SelectList(db.SkillRequirements, "Id", "Id", jobPosting.SkillRequirementId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", jobPosting.UserId);
            return View(jobPosting);
        }

        // GET: Poster/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            ViewBag.CultureId = new SelectList(db.Cultures, "Id", "Id", jobPosting.CultureId);
            ViewBag.SkillRequirementId = new SelectList(db.SkillRequirements, "Id", "Id", jobPosting.SkillRequirementId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", jobPosting.UserId);
            return View(jobPosting);
        }

        // POST: Poster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTitle,JobDescription,UserId,CultureId,SkillRequirementId")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPosting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CultureId = new SelectList(db.Cultures, "Id", "Id", jobPosting.CultureId);
            ViewBag.SkillRequirementId = new SelectList(db.SkillRequirements, "Id", "Id", jobPosting.SkillRequirementId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", jobPosting.UserId);
            return View(jobPosting);
        }

        // GET: Poster/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // POST: Poster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            JobPosting jobPosting = db.JobPostings.Find(id);
            db.JobPostings.Remove(jobPosting);
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
