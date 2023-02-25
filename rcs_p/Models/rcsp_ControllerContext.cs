using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace rcs_p.Models
{
    public class RequestsContext : DbContext
    {
        public RequestsContext(DbContextOptions<RequestsContext> options) : base(options)
        {

        }
        
        public DbSet<rcs_p.Models.Task> Task { get; set; } = default!;
    }
}
