using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Cd
    {
        public int Id { get; set; }
        [DisplayName("Name of Album")]
        [Required(ErrorMessage = "You need to fill out the name of the album!")]
        [StringLength(80, MinimumLength = 3)]
        public string Name { get; set; }
        [DisplayName("Artist")]
        public int Artist_Id { get; set; }
        [DisplayName("Release Year")]
        [Required(ErrorMessage = "You need to fill out the release year!")]
        public int Year { get; set; }
    }

    
}
