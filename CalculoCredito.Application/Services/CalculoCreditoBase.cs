using CalculoCredito.Application.Domain;
using CalculoCredito.Application.Interfaces;
using System;

namespace CalculoCredito.Application.Services
{
    public abstract class CalculoCreditoBase : ICalculoCredito
    {
        protected decimal _taxa;
        protected SolicitacaoCredito Solicitacao { get; set; }

        private DateTime _dataMinPrimeiroVencimento;
        private DateTime _dataMaxPrimeiroVencimento;

        protected CalculoCreditoBase(SolicitacaoCredito solicitacao)
        {
            this.Solicitacao = solicitacao;
            _dataMinPrimeiroVencimento = DateTime.Now.AddDays(15);
            _dataMaxPrimeiroVencimento = DateTime.Now.AddDays(40);
            ValidacaoEntradas();
        }
        private void ValidacaoEntradas()
        {
            if (this.Solicitacao.ValorCredito > 1000000)
            {
                this.Solicitacao.AlterarStatusAprovacao(false, "O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00");
            }
            if (this.Solicitacao.QtdParcelas < 5
                && this.Solicitacao.QtdParcelas > 72)
            {
                this.Solicitacao.AlterarStatusAprovacao(false, "A quantidade de parcelas máximas é de 72x e a mínima é de 5x");
            }

            if (this.Solicitacao.DataPrimeiroVencimento >= _dataMinPrimeiroVencimento
                && this.Solicitacao.DataPrimeiroVencimento <= _dataMaxPrimeiroVencimento)
            {
                this.Solicitacao.AlterarStatusAprovacao(false, "A data do primeiro vencimento sempre será no mínimo D+15(Dia atual + 15 dias), e no máximo, D + 40(Dia atual + 40 dias)");
            }
        }
        public abstract SolicitacaoCredito Calcular();
    }
}
