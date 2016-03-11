using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Springboard.Models;
using Microsoft.AspNet.Identity;

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
            var seeker = from s in context.Applications where s.UserId == id select s;
            
            return PartialView("CurrentSeekerApplications", seeker);
        }

        public ActionResult PosterApplication()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            String posterId = User.Identity.GetUserId();
            //posterId needs to be the JobPostingId, NOT the User ID to match. Not sure how to access this
            var poster = from s in context.Applications where s.JobPostingId.Equals(posterId) select s;
            return PartialView("CurrentSeekerApplications", poster);
        }
    }
}