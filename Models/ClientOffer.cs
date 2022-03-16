using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class ClientOffer
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OfferId { get; set; }

    }
}
