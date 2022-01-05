create or alter proc p_listar_produtos
as
begin
	Select 
		c.Descricao as CATEGORIA,
		p.Descricao as PRODUTO,
		p.Preco as VALOR
	from 
		TBCategorias c, TBProdutos p
	where 
		c.Id = p.Id
end