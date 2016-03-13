using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Springboard.Models
{
    public enum CultureCreatorType
    {
        SeekerAccount,
        JobPosting
    }

    public class CultureCreateViewModel
    {
        public CultureCreatorType CreatorType { get; set; }
        public Guid CreatorId { get; set; }
        public List<Trait> Traits { get; set; }
    }

    [Serializable]
    public class CultureCreatePostModel
    {
        public CultureCreatorType CreatorType { get; set;}
        public Guid CreatorId { get; set; }
        public List<TraitRank> Selection { get; set; }
    }

    [Serializable]
    public class TraitRank
    {
        public string PropertyName { get; set; }
        public int Rank { get; set; }
    }

    public class Trait
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
    }
}