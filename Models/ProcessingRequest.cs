using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class ProcessingRequest
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime RequestTime { get; set; }
        public int OfferId { get; set; }
    }
}
