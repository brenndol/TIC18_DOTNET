using System;
using System.Collections.Generics;
using System.Linq;

class Empresa {
    static void Main(){
        GestaoEstoque estoque = new GestaoEstoque();
        
        try {
            estoque.CadastrarProduto(1, "Produto A", 10, 20.99);
            estoque.CadastrarProfuto(2, "Produto B", 5, 17.45);
        }

        catch (Exception ex){
            Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
        }

        try {
            var produtoConsultado = estoque.ConsultarProduto (1);
            Console.WriteLine($"Produto encontrado: {produtoConsultado}");
        }

        catch (Exception ex) {
            Console.WriteLine($"Erro ao consultar produto: {ex.Message}");
        }

        var relatorio1 = estoque.ListarProdutosAbaixoDoLimite(8);
        Console.WriteLine("Produtos com quantidade abaixo do limite");
        foreach (var produto in relatorio1) {
            Console.WriteLine(produto);
        }

        var relatorio2 = estoque.ListarProdutosComValorEntre(20, 30);
        Console.WriteLine("\nProdutos com valor entre um mínimo e um máximo: ");
        foreach (var produto in relatorio2) {
            Console.WriteLine(produto);
        }

        var relatorio3 = estoque.CalcularValorTotalEstoque();
        Console.WriteLine($"\nValor total do estoque: {relatorio3.Item1}");
        Console.WriteLine("Valor total de cada produto no estoque: ");
        foreach (var produto in relatorio3.Item2) {
            Console.WriteLine($"{produto.Nome}: {produto.ValorTotal}");
        }   
    }
}

class Produto {
    public int Codigo 
    public string Nome 
    public int Quantidade 
    public double PrecoUnitario 

    public int Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Quantidade
    {
        get { return quantidade; }
        set { quantidade = value; }
    }

    public double PrecoUnitario
    {
        get { return precoUnitario; }
        set { precoUnitario = value; }
    }

    public double ValorTotal => Quantidade * PrecoUnitario;

    public override string ToString() {
        return $"Código: {Codigo}, Nome: {Nome}, Quantidade: {Quantidade}, Preço Unitário: {PrecoUnitario:C}, Valor Total: {ValorTotal:C}";
    }

}

class GestaoEstoque {
    private List<Produto> estoque = new List<Produto>();

    public void CadastrarProduto(int codigo, string nome, int quantidade, double precoUnitario) {
        if (estoque.Any(p => p.Codigo == codigo)) {
            throw new Exception("Produto com código já cadastrado.");
    }

Produto novoProduto = new Produto {
    Codigo = codigo,
    Nome = nome,
    Quantidade = quantidade,
    PrecoUnitario = precoUnitario
    };

estoque.Add(novoProduto);
}

public Produto ConsultarProduto(int codigo) {
    Produto produto = estoque.FirtOrDefault(p => p.Codigo == codigo);

    if (produto == null)
    {
        throw new Exception("Quantidade isuficiente em estoque para essa saída.");
    }

    produto.Quantidade += quantidade;
}

public List<Produto> ListarProdutosAbaixoDoLimite(int limite) {
    return estoque.where(Produto => p.Quantidade < limite).ToList();
}

public Tuple<double>, List<Produto>> CalcularValorTotalEstoque() {
    double CalcularValorTotalEstoque = estoque.Sum(Produto => p.ValorTotal);
    return Tuple<double, List<Produto>>(CalcularValorTotalEstoque, estoque);
}

}