using DotNetCore2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore2.Data
{
    public class EFCore2Context : DbContext
    {
        public EFCore2Context(DbContextOptions<EFCore2Context> options) : base(options)
        {
        }
        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Code> Codes { get; set; }
    }
}
