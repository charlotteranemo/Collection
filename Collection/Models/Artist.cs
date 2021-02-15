using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to fill out the name of the artist!")]
        public string Name { get; set; }
        [DisplayName("Country of Origin")]
        public string Country { get; set; }

    }

    
}
