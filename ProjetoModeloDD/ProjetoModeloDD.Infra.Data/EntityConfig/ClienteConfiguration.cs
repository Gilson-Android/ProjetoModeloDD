using ProjetoModeloDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Define como Primary key
            HasKey(x => x.ClienteId);

            //Define o tamanho
            Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.SobreNome)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Email)
                .IsRequired();
        }
    }
}
