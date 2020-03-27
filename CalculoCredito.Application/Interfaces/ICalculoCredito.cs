using CalculoCredito.Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoCredito.Application.Interfaces
{
    public interface ICalculoCredito
    {
        SolicitacaoCredito Calcular();
    }
}
