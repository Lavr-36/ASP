using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Academy.Models;

namespace Academy.Data
{
    public class AcademyContext : DbContext
    {
        public DbSet<Academy.Models.Teacher> teachers { get; set; } = default!;
        public AcademyContext (DbContextOptions<AcademyContext> options)
            : base(options)
        {
        }

        public DbSet<Academy.Models.Discipline> disciplines { get; set; } = default!;
        public DbSet<Academy.Models.Direction> directions { get; set; } = default!;
        public DbSet<Academy.Models.Group> groups { get; set; } = default!;
        public DbSet<Academy.Models.Student> students { get; set; } = default!;
    }
}
