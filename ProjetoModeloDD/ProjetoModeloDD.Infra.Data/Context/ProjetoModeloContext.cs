
using System;
using ProjetoModeloDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoModeloDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext()
            : base("ProjetoModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Converte o campo que conter no final id para primary Key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            //Todos os campos do tipo string será criado como varchar
            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar"));

            //Todos os campos do tipo string será criado com tamanho de 100
            modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());


        }

        public override int SaveChanges()
        {
            //Serve para ter necessidade de aplicar uma data no insert
            //Não não vai alterar a data de cadastro nos updates
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = new DateTime();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }

            return base.SaveChanges();
        }
    }
}
