using Springboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Springboard.Controllers
{
    public class CultureController : Controller
    {
        // GET: Culture
        public ActionResult CultureCreatePartialSeekerAccount(SeekerAccount model)
        {
            return CultureCreatePartial(model);
        }

        private ActionResult CultureCreatePartial(ICultureRef cultureRef)
        {
            Culture culture = new Culture();
            List<Trait> listItems = new List<Trait>();
            foreach (var prop in from s in culture.GetType().GetProperties() select s)
            {
                Trait item = new Trait
                {
                     DisplayName = prop.Name,
                     PropertyName = prop.Name
                };
                listItems.Add(item);
            }
            CultureCreateViewModel viewModel = new CultureCreateViewModel
            {
                Culture = culture,
                CultureRef = cultureRef,
                Traits = listItems
            };

            return PartialView("CultureCreatePartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CultureCreatePartial(CultureCreateViewModel viewModel)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            viewModel.Culture.Id = Guid.NewGuid();
            context.Cultures.Add(viewModel.Culture);
            await context.SaveChangesAsync();

            return null;//PartialView(viewModel.Culture);
        }
    }
}