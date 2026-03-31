using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EleicaoBrasilApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EleicaoBrasilApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Candidato> Candidatos { get; set; }
    }
}