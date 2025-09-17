using MeuCorre.Domain.Enums;
using System.Text.RegularExpressions;

namespace MeuCorre.Domain.Entities
{
    public class Categoria : Entidade
    {
        public Guid UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao  { get; private set; }
        public string? Cor { get; private set; }
        public string? Icone { get; private set; }
        public TipoTransacao TipoDaTransacao { get; private set; }
        public bool Ativo { get; private set; }

        // Propriedade de navegação para a entidade Usuario pois
        // o usuário pode ter várias categorias
        public virtual Usuario Usuario { get; private set; }

        public Categoria(Guid usuarioId, string nome, TipoTransacao tipoDaTransacao, bool Ativo, string? descricao, string? cor, string? icone)
        {
            ValidarEntidadeCategoria(cor);

            UsuarioId = usuarioId;
            Nome = nome.ToUpper();
            Descricao = descricao;
            Cor = cor;
            Icone = icone;
            TipoDaTransacao = tipoDaTransacao;
            Ativo = true;
        }

        public void AtualizarInformacoes(string nome, TipoTransacao tipoDaTransacao, bool Ativo, string descricao, string cor, string icone)
        {
            Nome = nome.ToUpper();
            Descricao = descricao;
            Cor = cor;
            Icone = icone;
            TipoDaTransacao = tipoDaTransacao;
            AtualizarDataMoficacao();
        }

        public void Ativar()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }

        public void Inativar()
        {
            Ativo = false;
            AtualizarDataMoficacao();
        }

        private void ValidarEntidadeCategoria(string cor)
        {
            if(string.IsNullOrWhiteSpace(cor))
            {
                return;
            }

            var CorRegex = new Regex(@"^#?([0-9a-fA-F]{3}){1,2}$");

            if (!CorRegex.IsMatch(cor))
            {
                throw new Exception("A cor deve estar no formato hexadecimal");
            }
        }
    }
}
