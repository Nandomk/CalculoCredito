using CalculoCredito.Application.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCredito.Application.Domain
{
    public class SolicitacaoCredito
    {
        public int QtdParcelas { get; set; }
        public decimal ValorCredito { get; set; }

        public DateTime DataPrimeiroVencimento { get; set; }

        public TipoCreditoEnum TipoCreditoSolicitado { get; set; }

        public bool? StatusAprovacao { get; private set; }

        public decimal? ValorTotalComJuros { get; set; }

        public decimal? ValorJuros { get; set; }

        public string MotivoNegacao { get; private set; }

        public SolicitacaoCredito(decimal valorCredito, int qtdParcelas, DateTime dataPrimeiroVencimento, TipoCreditoEnum tipoCredito)
        {
            this.ValorCredito = valorCredito;
            this.QtdParcelas = qtdParcelas;
            this.DataPrimeiroVencimento = dataPrimeiroVencimento;
            this.TipoCreditoSolicitado = tipoCredito;
        }

        public void AlterarStatusAprovacao(bool status, string motivoNegacao)
        {
            this.StatusAprovacao = status;
            this.MotivoNegacao = status ? "" : motivoNegacao;
        }
    }
}
