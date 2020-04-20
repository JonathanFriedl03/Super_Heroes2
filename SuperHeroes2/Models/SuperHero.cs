using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes2.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }

       
        public string Name { get; set; }
        [Display (Name="Alter Ego")]
        public string AlterEgo { get; set; }
        [Display(Name = "main Power")]
        public string MainPower { get; set; }
        [Display(Name = "Secondary Power")]
        public string SecondaryPower { get; set; }
        [Display(Name = "Catch Phrase")]

        public string CatchPhrase { get; set; }
    }
}
