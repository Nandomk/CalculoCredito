using CalculoCredito.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using CalculoCredito.Application.Enum;
using CalculoCredito.Application.Interfaces;

namespace CalculoCredito.Application.Services
{
    public class CreditoDireto : CalculoCreditoBase, ICalculoCredito
    {
        
        public CreditoDireto(SolicitacaoCredito solicitacao)
            : base(solicitacao)
        {
            this._taxa = 2;
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
