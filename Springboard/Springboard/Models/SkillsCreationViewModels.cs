using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Springboard.Models
{
    public enum SkillCreatorType
    {
        SeekerAccount,
        JobPosting
    }

    public class SkillCreateViewModel
    {
        public SkillCreatorType CreatorType { get; set; }
        public Guid CreatorId { get; set; }
        public List<Trait> Traits { get; set; }
    }

    [Serializable]
    public class SkillCreatePostModel
    {
        public SkillCreatorType CreatorType { get; set; }
        public Guid CreatorId { get; set; }
        public List<TraitRank> Selection { get; set; }
    }
}