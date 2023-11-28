using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        GestaoEstoque estoque = new GestaoEstoque();

        
        try
        {
            estoque.CadastrarProduto(1, "Produto A", 10, 19.99);
            estoque.CadastrarProduto(2, "Produto B", 5, 29.99);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
        }

        
        try
        {
            var produtoConsultado = estoque.ConsultarProduto(1);
            Console.WriteLine($"Produto encontrado: {produtoConsultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao consultar produto: {ex.Message}");
        }

        
        try
        {
            estoque.AtualizarEstoque(1, 5); 
            estoque.AtualizarEstoque(2, -3); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar estoque: {ex.Message}");
        }

        
        var relatorio1 = estoque.ListarProdutosAbaixoDoLimite(8);
        Console.WriteLine("Produtos com quantidade abaixo do limite:");
        foreach (var produto in relatorio1)
        {
            Console.WriteLine(produto);
        }

        var relatorio2 = estoque.ListarProdutosComValorEntre(20, 30);
        Console.WriteLine("\nProdutos com valor entre um minimo e um maximo:");
        foreach (var produto in relatorio2)
        {
            Console.WriteLine(produto);
        }

        var relatorio3 = estoque.CalcularValorTotalEstoque();
        Console.WriteLine($"\nValor total do estoque: {relatorio3.Item1}");
        Console.WriteLine("Valor total de cada produto no estoque:");
        foreach (var produto in relatorio3.Item2)
        {
            Console.WriteLine($"{produto.Nome}: {produto.ValorTotal}");
        }
    }
}

class Produto
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }

    public double ValorTotal => Quantidade * PrecoUnitario;

    public override string ToString()
    {
        return $"Codigo: {Codigo}, Nome: {Nome}, Quantidade: {Quantidade}, Preço Unitario: {PrecoUnitario:C}, Valor Total: {ValorTotal:C}";
    }
}

class GestaoEstoque
{
    private List<Produto> estoque = new List<Produto>();

    public void CadastrarProduto(int codigo, string nome, int quantidade, double precoUnitario)
    {
        if (estoque.Any(p => p.Codigo == codigo))
        {
            throw new Exception("Produto com código ja cadastrado.");
        }

        Produto novoProduto = new Produto
        {
            Codigo = codigo,
            Nome = nome,
            Quantidade = quantidade,
            PrecoUnitario = precoUnitario
        };

        estoque.Add(novoProduto);
    }

    public Produto ConsultarProduto(int codigo)
    {
        Produto produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

        if (produto == null)
        {
            throw new Exception("Produto nao encontrado.");
        }

        return produto;
    }

    public void AtualizarEstoque(int codigo, int quantidade)
    {
        Produto produto = ConsultarProduto(codigo);

        if (produto.Quantidade + quantidade < 0)
        {
            throw new Exception("Quantidade insuficiente em estoque para essa saida.");
        }

        produto.Quantidade += quantidade;
    }

    public List<Produto> ListarProdutosAbaixoDoLimite(int limite)
    {
        return estoque.Where(p => p.Quantidade < limite).ToList();
    }

    public List<Produto> ListarProdutosComValorEntre(double minimo, double maximo)
    {
        return estoque.Where(p => p.PrecoUnitario >= minimo && p.PrecoUnitario <= maximo).ToList();
    }

    public Tuple<double, List<Produto>> CalcularValorTotalEstoque()
    {
        double valorTotalEstoque = estoque.Sum(p => p.ValorTotal);
        return new Tuple<double, List<Produto>>(valorTotalEstoque, estoque);
    }
}