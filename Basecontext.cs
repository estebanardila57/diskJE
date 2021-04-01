﻿using Microsoft.EntityFrameworkCore;
using proyectodisctienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectodisctienda
{
    public class Basecontext:DbContext
    {
        public Basecontext(DbContextOptions<Basecontext> options) :base(options)
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Discos> Discos { get; set; }
        public DbSet<Usersystem> Usersystems { get; set; }
        public DbSet<Prestamo> Prestamos{ get; set; }
        public DbSet<Sancion> Sanciones{ get; set; }
    }
}
