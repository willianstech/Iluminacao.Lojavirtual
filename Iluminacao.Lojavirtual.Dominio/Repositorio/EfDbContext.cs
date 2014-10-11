﻿using Iluminacao.Lojavirtual.Dominio.Entidade;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Iluminacao.Lojavirtual.Dominio.Repositorio
{
    public class EfDbContext: DbContext
    {
        public DbSet<Produto> Produtos { get;set;}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove < PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
        }
    }
}
