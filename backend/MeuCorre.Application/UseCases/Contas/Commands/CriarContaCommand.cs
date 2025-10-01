using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Contas.Commands
{
    public class CriarContaCommad : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "É necessário informar o id do usuário")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome da conta é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Tipo da conta é obrigatório")]
        public required string Tipo { get; set; } // Ex: "CartaoCredito" ou "Carteira"

        public decimal Saldo { get; set; } = 0;

        public decimal? Limite { get; set; }
        public int? DiaFechamento { get; set; }
        public int? DiaVencimento { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public string? TipoLimite { get; set; } // Apenas para cartão de crédito
    }


}
