using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace TechnologicalPracticeApp.Models
{
    public class FilterModel
    {
        public IEnumerable<Ecolabel> Ecolabels { get; set; }
        public SelectList Companies { get; set; }
        public string Name { get; set; }
    }
}