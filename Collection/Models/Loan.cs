using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class Loan
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to enter who you're lending it to!")]
        public string Name { get; set; }
        [DisplayName("Album")]
        public int Cd_Id { get; set; }
        [Required(ErrorMessage = "You need to fill out the start date of the loan!")]
        public DateTime Date { get; set; }
        [DisplayName("Has it been returned?")]
        public bool IsReturned { get; set; }
    }
}
