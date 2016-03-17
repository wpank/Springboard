using Springboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Springboard.Controllers
{
    public class SkillsController : Controller
    {
        public ActionResult SkillCreatePartialSeekerAccount(SeekerAccount model)
        {
            SkillRequirement Skill = new SkillRequirement();
            List<Trait> listItems = new List<Trait>();
            foreach (var prop in from s in Skill.GetType().GetProperties() select s)
            {
                if (!prop.PropertyType.Equals(typeof(int?)))
                    continue;
                Trait item = new Trait
                {
                    DisplayName = prop.Name,
                    PropertyName = prop.Name
                };
                listItems.Add(item);
            }
            SkillCreateViewModel viewModel = new SkillCreateViewModel
            {
                CreatorType = SkillCreatorType.SeekerAccount,
                CreatorId = model.Id,
                Traits = listItems
            };

            return PartialView("SkillCreatePartial", viewModel);
        }

        public ActionResult SkillCreatePartialJobPosting(JobPosting model)
        {
            SkillRequirement Skill = new SkillRequirement();
            List<Trait> listItems = new List<Trait>();
            foreach (var prop in from s in Skill.GetType().GetProperties() select s)
            {
                if (!prop.PropertyType.Equals(typeof(int?)))
                    continue;
                Trait item = new Trait
                {
                    DisplayName = prop.Name,
                    PropertyName = prop.Name
                };
                listItems.Add(item);
            }
            SkillCreateViewModel viewModel = new SkillCreateViewModel
            {
                CreatorType = SkillCreatorType.JobPosting,
                CreatorId = model.Id,
                Traits = listItems
            };

            return PartialView("SkillCreatePartial", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> SkillCreatePartial(SkillCreatePostModel result)
        {
            //Parse the data and configure a Skill model
            SkillRequirement model = new SkillRequirement();
            foreach (TraitRank rank in result.Selection)
            {
                model.GetType().GetProperty(rank.PropertyName).SetValue(model, rank.Rank);
            }
            model.Id = Guid.NewGuid();

            //Create a new Db context
            ApplicationDbContext context = new ApplicationDbContext();

            //Store the model
            context.SkillRequirements.Add(model);
            await context.SaveChangesAsync();

            //Update the appropriate account
            switch (result.CreatorType)
            {
                case (SkillCreatorType.SeekerAccount):
                    {
                        SeekerAccount account = (from s in context.SeekerAccounts
                                                 where s.Id == result.CreatorId
                                                 select s).FirstOrDefault();
                        if (account == null) break;

                        context.SeekerAccounts.Attach(account);
                        var entry = context.Entry(account);
                        entry.Reference(e => e.SkillRequirement).CurrentValue = model;
                        await context.SaveChangesAsync();

                        return RedirectToAction("Index", "Seeker", new { area = "" });
                    }
                case (SkillCreatorType.JobPosting):
                    {
                        JobPosting account = (from s in context.JobPostings
                                                 where s.Id == result.CreatorId
                                                 select s).FirstOrDefault();
                        if (account == null) break;

                        context.JobPostings.Attach(account);
                        var entry = context.Entry(account);
                        entry.Reference(e => e.SkillRequirement).CurrentValue = model;
                        await context.SaveChangesAsync();

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return null;
        }

        // GET: Skills
        public ActionResult SkillDetailsPartial(Guid? SkillRequirementId)
        {
            //Create a new Db context
            ApplicationDbContext context = new ApplicationDbContext();
            SkillRequirement model = (from s in context.SkillRequirements
                             where s.Id == SkillRequirementId
                                      select s).FirstOrDefault();
            return PartialView("SkillDetailsPartial", model);
        }
    }
}