using ProjetoModeloDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //Define como Primary key
            HasKey(x => x.ProdutoId);

            //Define o tamanho
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(x => x.Valor)
                .IsRequired();

            HasRequired(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId);
        }
    }
}
