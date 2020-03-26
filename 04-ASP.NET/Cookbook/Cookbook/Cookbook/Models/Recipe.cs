using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Duration [min]")]
        public int Time { get; set; }
        public string Difficulty { get; set; }
        public int NumberOfLikes { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }
        public string TipsAndTricks { get; set; }
    }
}
