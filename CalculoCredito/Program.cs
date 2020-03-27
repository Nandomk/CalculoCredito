using CalculoCredito.Application.Services;
using CalculoCredito.Application.Domain;
using CalculoCredito.Application.Enum;
using System;

namespace CalculoCredito
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new CreditoFactory();

            var CreditoDireto = factory.GetCalculo(new
                SolicitacaoCredito(50000, 5, new DateTime(2020, 3, 20), TipoCreditoEnum.CreditoDireto));
            var resultado = CreditoDireto.Calcular();
            PrintResultado(resultado);

            var creditoPessoaFisica = factory.GetCalculo(new
                SolicitacaoCredito(50000, 5, new DateTime(2020, 3, 20), TipoCreditoEnum.CreditoPessoaFisica));
            resultado = creditoPessoaFisica.Calcular();
            PrintResultado(resultado);

            var creditoPessoaJuridica = factory.GetCalculo(new
                SolicitacaoCredito(50000, 5, new DateTime(2020, 3, 20), TipoCreditoEnum.CreditoPessoaJuridica));
            resultado = creditoPessoaJuridica.Calcular();
            PrintResultado(resultado);

            var creditoImobiliario = factory.GetCalculo(new
                SolicitacaoCredito(50000, 5, new DateTime(2020, 3, 20), TipoCreditoEnum.CreditoImobiliario));
            resultado = creditoImobiliario.Calcular();
            PrintResultado(resultado);


            var creditoConsignado = factory.GetCalculo(new
                SolicitacaoCredito(50000, 5, new DateTime(2020, 3, 20), TipoCreditoEnum.CreditoConsignado));
            resultado = creditoConsignado.Calcular();
            PrintResultado(resultado);

            Console.WriteLine("Fim");
            Console.ReadKey();
        }
        static void PrintResultado(SolicitacaoCredito s)
        {
            Console.WriteLine("Tipo: " + s.TipoCreditoSolicitado + "\n");
            Console.WriteLine("Valor: " + s.ValorCredito + "\n");
            Console.WriteLine("Parcelas: " + s.QtdParcelas + "\n");            
            Console.WriteLine("Data primeiro vencimento: " + s.DataPrimeiroVencimento + "\n");

            Console.WriteLine("Status " + (s.StatusAprovacao.Value ? "Aprovado" : "Reprovado") + "\n");
            if (!s.StatusAprovacao.Value)
            {
                Console.WriteLine("Motivo Negacao " + s.MotivoNegacao + "\n");
            }


            if (s.StatusAprovacao.Value)
            {

                Console.WriteLine("Total com Juros: " + s.ValorTotalComJuros + "\n");
                Console.WriteLine("Valor Juros: " + s.ValorJuros + "\n");
            }
            Console.WriteLine("\n\n-------------------------------------------------------------------------------------\n");

        }
    }
}
