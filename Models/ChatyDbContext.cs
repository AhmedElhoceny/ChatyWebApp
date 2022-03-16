using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Models
{
    public class ChatyDbContext : DbContext
    {
        public ChatyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<AdminMessage> AdminMessage { get; set; }
        public DbSet<ChatBotMessages> ChatBotMessages { get; set; }
        public DbSet<ClientOffer> ClientOffer { get; set; }
        public DbSet<ProcessingRequest> ProcessingRequest { get; set; }
        public DbSet<AdminData> AdminData { get; set; }
        
    }
}
