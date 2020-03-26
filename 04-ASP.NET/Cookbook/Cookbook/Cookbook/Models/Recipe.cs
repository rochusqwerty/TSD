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

        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Duration [min]")]
        [Required]
        [Range(1, 1440)]
        public int Time { get; set; }

        [Required]
        [RegularExpression(@"\d"), StringLength(1)]
        public string Difficulty { get; set; }

        [Display(Name = "Number of likes")]
        public int NumberOfLikes { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Process { get; set; }

        [Display(Name = "Tips and tricks")]
        public string TipsAndTricks { get; set; }
    }
}
