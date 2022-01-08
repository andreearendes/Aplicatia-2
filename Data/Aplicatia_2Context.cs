using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicatia_2.Models;

namespace Aplicatia_2.Data
{
    public class Aplicatia_2Context : DbContext
    {
        public Aplicatia_2Context (DbContextOptions<Aplicatia_2Context> options)
            : base(options)
        {
        }

        public DbSet<Aplicatia_2.Models.Patient> Patient { get; set; }

        public DbSet<Aplicatia_2.Models.Doctor> Doctor { get; set; }

        public DbSet<Aplicatia_2.Models.Treatment> Treatment { get; set; }
    }
}
