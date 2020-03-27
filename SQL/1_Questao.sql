select 
	c.Nome, 
	f.ValorTotal, 
	count(p.IdFinanciamentoParcela) Parcelas,   
	COUNT(p.pagamento) QtdPagas
from dbo.Cliente c
	left join dbo.Financiamento f on c.IdCliente = f.IdCliente
	left join dbo.FinanciamentoParcela  p on f.IdFinanciamento = p.IdFinanciamento
where 
	c.uf='SP'
group by  
	f.IdFinanciamento, 
	c.Nome, 
	f.ValorTotal
having 
	count(p.Pagamento) >= (count(p.IdFinanciamentoParcela)*0.6)