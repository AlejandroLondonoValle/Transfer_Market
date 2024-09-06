using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Models;
using System.Security.Cryptography;

namespace TransferMarket.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }


    public DbSet<Jugador> Jugadores { get; set; }
    public DbSet<Club> Clubes { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
}

