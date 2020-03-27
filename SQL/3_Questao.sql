select 
	c.Nome
	, f.ValorTotal
from dbo.Cliente c
	left join dbo.Financiamento f on c.IdCliente = f.IdCliente
	left join dbo.FinanciamentoParcela  p on f.IdFinanciamento = p.IdFinanciamento
where
	DATEADD(dd, 10, DATEDIFF(dd, 0, p.Vencimento)) < p.Pagamento
	and f.ValorTotal > 10000
group by  
	f.IdFinanciamento, 
	c.Nome,
	f.ValorTotal
having  count(*) >1


