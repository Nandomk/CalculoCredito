using CalculoCredito.Application.Domain;
using CalculoCredito.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCredito.Application.Services
{
    public class CreditoPessoaJuridica : CalculoCreditoBase, ICalculoCredito
    {
        public CreditoPessoaJuridica(SolicitacaoCredito solicitacao)
            : base(solicitacao)
        {
            this._taxa = 5;
        }
        public override SolicitacaoCredito Calcular()
        {
            ValidarCredito();
            if (this.Solicitacao.StatusAprovacao == null)
            {
                this.Solicitacao.ValorJuros = this.Solicitacao.ValorCredito * (_taxa / 100);
                this.Solicitacao.ValorTotalComJuros = this.Solicitacao.ValorCredito + this.Solicitacao.ValorJuros;
                this.Solicitacao.AlterarStatusAprovacao(true, "");
            }
            return this.Solicitacao;
        }
        private void ValidarCredito()
        {
            if (this.Solicitacao.ValorCredito < 15000)
            {
                this.Solicitacao.AlterarStatusAprovacao(false, "Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00");
            }
        }
    }
}
