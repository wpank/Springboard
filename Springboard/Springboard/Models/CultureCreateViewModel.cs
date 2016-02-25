using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Springboard.Models
{
    public class CultureCreateViewModel
    {
        public ICultureRef CultureRef { get; set; }
        public Culture Culture { get; set; }
        public List<Trait> Traits { get; set; }
    }

    public class Trait
    {
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
    }
}