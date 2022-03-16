using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class Offer
    {
        [Key]
        public int id { get; set; }
        public int MessagesNumber { get; set; }
        public string OfferTitle { get; set; }
        public double Money { get; set; }
        public int daysNumber { get; set; }
    }
}
