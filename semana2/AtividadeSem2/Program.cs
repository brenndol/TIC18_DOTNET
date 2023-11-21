using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Task
    {
        public string Titulo
        { 
            get {return Titulo; } 
            set {Titulo = value; }
        }
        public string Descricao 
        {
            get {return Descricao;}
            set {Descricao = value;} 
        }
        public DateTime DataVencimento 
        { 
            get {return DataVencimento;}
            set {DataVencimento = value;}
        }
        public bool Concluida 
        { 
            get {return Concluida;}
            set {Concluida = value;} 
        }
    }

    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("9. Sair");

            Console.Write("Escolha uma opção: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CriaTarefa();
                    break;
                case "2":
                    ListarTarefa();
                    break;
                case "3":
                    MarcarComoConcluida();
                    break;
                case "4":
                    ListarTarefaPendente();
                    break;
                case "5":
                    ListarTarefaConcluida();
                    break;
                case "6":
                    ExcluirTarefa();
                    break;
                case "7":
                    PesquisaPalavraChave();
                    break;
                case "8":
                    ExibirEstatistica();
                    break;
                case "9":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CriaTarefa()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Data de Vencimento (yyyy-MM-dd): ");
        DateTime dataVencimento = DateTime.Parse(Console.ReadLine());

        tasks.Add(new Task { Titulo = titulo, Descricao = descricao, DataVencimento = dataVencimento });
        Console.WriteLine("Tarefa criada com sucesso!");
    }

    static void ListarTarefa()
    {
        Console.WriteLine("Lista de Tarefas:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"Título: {task.Titulo}, Descrição: {task.Descricao}, Data de Vencimento: {task.DataVencimento.ToString("dd-mm-yyyy")}, Concluída: {task.Concluida}");
        }
    }

    static void MarcarComoConcluida()
    {
        Console.Write("Digite o título da tarefa concluída: ");
        string titulo = Console.ReadLine();

        Task task = tasks.Find(t => t.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (task != null)
        {
            task.Concluida = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    static void ListarTarefaPendente()
    {
        var pendenciaTarefa = tasks.Where(t => !t.Concluida).ToList();

        Console.WriteLine("Lista de Tarefas Pendentes:");
        foreach (var task in pendenciaTarefa)
        {
            Console.WriteLine($"Título: {task.Titulo}, Descrição: {task.Descricao}, Data de Vencimento: {task.DataVencimento.ToString("dd-mm-yyyy")}");
        }
    }

    static void ListarTarefaConcluida()
    {
        var completaTarefa = tasks.Where(t => t.Concluida).ToList();

        Console.WriteLine("Lista de Tarefas Concluídas:");
        foreach (var task in completaTarefa)
        {
            Console.WriteLine($"Título: {task.Titulo}, Descrição: {task.Descricao}, Data de Vencimento: {task.DataVencimento.ToString("dd-mm-yyyy")}");
        }
    }

    static void ExcluirTarefa()
    {
        Console.Write("Digite o título da tarefa a ser excluída: ");
        string titulo = Console.ReadLine();

        Task task = tasks.Find(t => t.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }

    static void PesquisaPalavraChave()
    {
        Console.Write("Digite a palavra-chave: ");
        string palavrachave = Console.ReadLine();

        var resultado = tasks.Where(t => t.Titulo.Contains(palavrachave, StringComparison.OrdinalIgnoreCase) || t.Descricao.Contains(palavrachave, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine("Resultado da Pesquisa:");
        foreach (var task in resultado)
        {
            Console.WriteLine($"Título: {task.Titulo}, Descrição: {task.Descricao}, Data de Vencimento: {task.DataVencimento.ToString("dd-mm-yyyy")}, Concluída: {task.Concluida}");
        }
    }

    static void ExibirEstatistica()
    {
        int totalTarefa = tasks.Count;
        int completaTarefa = tasks.Count(t => t.Concluida);
        int pendenciaTarefa = totalTarefa - completaTarefa;

        var velhaTarefa = tasks.OrderBy(t => t.DataVencimento).FirstOrDefault();
        var novaTarefa = tasks.OrderByDescending(t => t.DataVencimento).FirstOrDefault();

        Console.WriteLine($"Número total de tarefas: {totalTarefa}");
        Console.WriteLine($"Número de tarefas concluídas: {completaTarefa}");
        Console.WriteLine($"Número de tarefas pendentes: {pendenciaTarefa}");
        Console.WriteLine($"Tarefa mais antiga: {velhaTarefa?.Titulo} - Data de Vencimento: {velhaTarefa?.DataVencimento.ToString("dd-mm-yyyy")}");
        Console.WriteLine($"Tarefa mais recente: {novaTarefa?.Titulo} - Data de Vencimento: {novaTarefa?.DataVencimento.ToString("dd-mm-yyyy")}");
    }
}