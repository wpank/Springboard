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
            Culture culture = new Culture();
            List<Trait> listItems = new List<Trait>();
            foreach (var prop in from s in culture.GetType().GetProperties() select s)
            {
                if (!prop.PropertyType.Equals(typeof(int)))
                    continue;
                Trait item = new Trait
                {
                    DisplayName = prop.Name,
                    PropertyName = prop.Name
                };
                listItems.Add(item);
            }
            CultureCreateViewModel viewModel = new CultureCreateViewModel
            {
                CreatorType = CultureCreatorType.SeekerAccount,
                CreatorId = model.Id,
                Traits = listItems
            };

            return PartialView("CultureCreatePartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CultureCreatePartial(CultureCreatePostModel result)
        {


            ApplicationDbContext context = new ApplicationDbContext();
            Culture model = new Culture();
            switch(result.CreatorType)
            {

            }

            return null;//PartialView(viewModel.Culture);
        }
    }
}