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
    public class SeekerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public SeekerController()
        {
        }

        public SeekerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

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
        // GET: Seeker
        [HttpGet]
        public ActionResult Index()
        {
            //DatabaseModel model = new DatabaseModel();
            ApplicationDbContext model = new ApplicationDbContext();
            string id = User.Identity.GetUserId();
            var user = (from s in model.Users
                        where s.Id == id
                        select s).FirstOrDefault();

            //if(user.SeekerAccount == null)
            //{
            //    SeekerAccount account = new SeekerAccount();
            //    account.AccountId = id;
            //    model.SeekerAccounts.Add(account);
            //    await model.SaveChangesAsync();

            //    user.SeekerId = account.Id;
            //    await model.SaveChangesAsync();
            //}

            return View("Index", user);
        }

        public ActionResult SeekerAccountPartial(SeekerAccount account)
        {
            return PartialView("SeekerAccountPartial", account);
        }
    }
}