using CalculoCredito.Application.Domain;
using CalculoCredito.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCredito.Application.Services
{
    public class CreditoFactory
    {
        public ICalculoCredito GetCalculo(SolicitacaoCredito solicitacao)
        {
            switch (solicitacao.TipoCreditoSolicitado)
            {
                case Enum.TipoCreditoEnum.CreditoDireto:
                    return new CreditoDireto(solicitacao);
                case Enum.TipoCreditoEnum.CreditoConsignado:
                    return new CreditoConsignado(solicitacao);
                case Enum.TipoCreditoEnum.CreditoImobiliario:
                    return new CreditoImobiliario(solicitacao);                    
                case Enum.TipoCreditoEnum.CreditoPessoaFisica:
                    return new CreditoPessoaFisica(solicitacao);
                case Enum.TipoCreditoEnum.CreditoPessoaJuridica:
                    return new CreditoPessoaJuridica(solicitacao);
                default:
                    throw new Exception("Tipo de crédito não identificado");
            }
        }
    }
}
