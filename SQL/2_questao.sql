select top(4)
	c.Nome, 
	f.ValorTotal	
from dbo.Cliente c
	left join dbo.Financiamento f on c.IdCliente = f.IdCliente
	left join dbo.FinanciamentoParcela  p on f.IdFinanciamento = p.IdFinanciamento
group by  
	f.IdFinanciamento, 
	c.Nome, 
	f.ValorTotal, 
	p.Pagamento, 
	p.Vencimento
having  
	p.Pagamento is null 
	and p.Vencimento <  DATEADD(dd, -5, DATEDIFF(dd, 0, getdate()))