using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebRota.Domain.Entities;


namespace WebRota.Infra.Context
{
    public class WebRotaContext : DbContext
    {
        public WebRotaContext(DbContextOptions<WebRotaContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
