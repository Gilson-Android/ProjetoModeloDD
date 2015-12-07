using System;
namespace ProjetoModeloDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual IEquatable<Produto> Produtos { get; set; }

        public bool ClienteEspecial(Cliente cliente_)
        {
            return cliente_.Ativo && DateTime.Now.Year - cliente_.DataCadastro.Year >= 5;
        }
    }
}
