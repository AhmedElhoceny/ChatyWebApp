using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Imgae { get; set; }
        public string PhoneNumber { get; set; }
        public string UserCode { get; set; }
        public bool Activated { get; set; }
        public bool PayedOrNot { get; set; }
        public int OfferNumber { get; set; }
        public int MessagesNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
