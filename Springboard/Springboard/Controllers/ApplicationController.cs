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
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            String id = User.Identity.GetUserId();
            var user = from s in context.Applications where s.UserId == id select s;
            
            return PartialView("CurrentSeekerApplications", user);
        }
    }
}