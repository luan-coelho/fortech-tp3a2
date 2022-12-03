namespace FortechTP3A2.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime DataNascimento { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public IList<SolicitacaoServico> Solicitacoes { get; set; }

        public bool Admin { get; set; }

        public bool Ativo { get; set; }
    }
}
