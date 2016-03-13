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
            //Parse the data and configure a culture model
            Culture model = new Culture();
            foreach(TraitRank rank in result.Selection)
            {
                model.GetType().GetProperty(rank.PropertyName).SetValue(model, rank.Rank);
            }
            model.Id = Guid.NewGuid();

            //Create a new Db context
            ApplicationDbContext context = new ApplicationDbContext();

            //Store the model
            context.Cultures.Add(model);
            await context.SaveChangesAsync();

            //Update the appropriate account
            switch (result.CreatorType)
            {
                case (CultureCreatorType.SeekerAccount):
                    {
                        SeekerAccount account = (from s in context.SeekerAccounts
                                                 where s.Id == result.CreatorId
                                                 select s).FirstOrDefault();
                        if (account == null) break;

                        context.SeekerAccounts.Attach(account);
                        var entry = context.Entry(account);
                        entry.Reference(e => e.Culture).CurrentValue = model;
                        await context.SaveChangesAsync();

                        break;
                    }
                case (CultureCreatorType.JobPosting):
                {
                    break;
                }
                default:
                {
                    break;
                }
            }

            return PartialView("CultureEditPartial", model);
        }

        // GET: Culture
        public ActionResult CultureEditPartial(Guid CultureId)
        {
            //Create a new Db context
            ApplicationDbContext context = new ApplicationDbContext();
            Culture model = (from s in context.Cultures
                             where s.Id == CultureId
                             select s).FirstOrDefault();
            return PartialView("CultureEditPartial", model);
        }
    }
}