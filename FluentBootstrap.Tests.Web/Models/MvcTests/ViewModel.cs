using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentBootstrap.Tests.Web.Models.MvcTests
{
    public class ViewModel
    {
        [Display(Name = "Property A")]
        public string PropA { get; set; }
        public int PropB { get; set; }
        public Dictionary<int, string> PropC { get; set; }
    }
}