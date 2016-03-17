using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Springboard.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Springboard.Controllers
{


    public class ApplicationController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult SeekerApplication()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            String id = User.Identity.GetUserId();
            var seeker = (from s in context.Applications where s.UserId == id select s).ToList();
            
            return PartialView("CurrentSeekerApplications", seeker);
        }

        public ActionResult JobPostingApplication(Guid posterId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Application> poster = (from s in context.Applications
                                        where s.JobPostingId != null &&
                                        s.JobPostingId == posterId
                                        select s).ToList();
            return PartialView("CurrentSeekerApplications", poster);
        }

        public async Task<ActionResult> Apply(Guid Id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            String id = User.Identity.GetUserId();
            Application app = new Application
            {
                DateOpen = DateTime.Now,
                Id = Guid.NewGuid(),
                JobPostingId = Id,
                Resolved = false,
                UserId = id
            };
            context.Applications.Add(app);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Seeker");
        }
    }
}