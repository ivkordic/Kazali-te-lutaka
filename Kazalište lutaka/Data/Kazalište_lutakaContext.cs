using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kazalište_lutaka.Models;

namespace Kazalište_lutaka.Models
{
    public class Kazalište_lutakaContext : DbContext
    {
        public Kazalište_lutakaContext (DbContextOptions<Kazalište_lutakaContext> options)
            : base(options)
        {
        }

        public DbSet<Kazalište_lutaka.Models.Predstave> Predstave { get; set; }

        public DbSet<Kazalište_lutaka.Models.Raspored> Raspored { get; set; }
    }
}
