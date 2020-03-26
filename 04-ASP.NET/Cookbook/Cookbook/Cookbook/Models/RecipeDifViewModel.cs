using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cookbook.Models
{
    public class RecipeDifViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public SelectList Difficulties { get; set; }
        public string RecipeDif { get; set; }
        public string SearchString { get; set; }
    }
}
