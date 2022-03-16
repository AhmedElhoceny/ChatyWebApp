using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class AdminData
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PayPalClientId { get; set; }
    }
}
