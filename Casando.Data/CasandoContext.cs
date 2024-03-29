﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Casando.Core.Modelos;
using Casando.Data.Interfaces;
using Casando.Data.Migrations;

namespace Casando.Data
{
    public class CasandoContext : DbContext, ICasandoContext
    {
        public CasandoContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CasandoContext, Configuration>());
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<CotacaoPresente>()
                .HasRequired(x => x.Presente);
                
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Presente> Presentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<CotacaoPresente> CotacaoPresentes { get; set; }
    }
}
