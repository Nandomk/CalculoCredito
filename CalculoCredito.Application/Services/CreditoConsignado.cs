using CalculoCredito.Application.Domain;
using CalculoCredito.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCredito.Application.Services
{
    public class CreditoConsignado : CalculoCreditoBase, ICalculoCredito
    {
        public CreditoConsignado(SolicitacaoCredito solicitacao)
            : base(solicitacao)
        {
            this._taxa = 1;
        }
        public override SolicitacaoCredito Calcular()
        {
            if (this.Solicitacao.StatusAprovacao == null)
            {
                this.Solicitacao.ValorJuros = this.Solicitacao.ValorCredito * (_taxa / 100);
                this.Solicitacao.ValorTotalComJuros = this.Solicitacao.ValorCredito + this.Solicitacao.ValorJuros;
                this.Solicitacao.AlterarStatusAprovacao(true, "");
            }
            return this.Solicitacao;
        }
    }
}
