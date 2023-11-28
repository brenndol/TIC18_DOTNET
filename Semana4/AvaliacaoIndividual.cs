using System;
using System.Collections.Generic;
using System.Linq;

class Academia {

    static void Main() {
        List<Treinador> treinadores = new List<Treinador> {

            new Treinador("Pedro", new DateTime(1990, 2, 10), "12312312301", "CREF123"),
            new Treinador("Jonior", new DateTime(1994, 10, 5), "98798798702", "CREF565")
        };

        List<Cliente> clientes = new List<Cliente> {

            new Cliente("Nairan", new DateTime(1999, 3, 20), "11122233312", 1.55, 58),
            new Cliente("Alessandro", new DateTime(1998, 7, 10), "1212312456", 1.68, 70),
            new Cliente("Caio", new DateTime(1997, 12, 5), "45645676589")
        };

        Console.WriteLine("1. Treinadores com idade entre dois valores: ");
        List<Treinador> treinadoresEntreIdades = Relatorios.treinadoresEntreIdades(treinadores, 20, 40;)
        foreach (var treinador in treinadoresEntreIdades) {
            Console.WriteLine($"Nome: {treinador.Nome}, Idade: {treinadore.Idade}");
        }

        Console.WriteLine("\n2. Clientes com idade entre dois valores:");
        List<Cliente> clientesEntreIdades = Relatorios.clientesEntreIdades(clientes, 18,35);
        foreach (var cliente in clientesEntreIdades) {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
        }

        Console.WriteLine("\n3. Clientes com IMC maior que um valor informado, em ordem crescente:");
        List<Cliente> clientesPorIMC = Relatorios.ClientesPorIMC(clientes, 22);
        foreach (var cliente in clientesPorIMC) {
            Console.WriteLine($"Nome: {cliente.Nome}, IMC: {cliente.CalcularIMC()}");
        }

        Console.WriteLine("\n4. Clientes em oredem alfabetica:");
        List<Cliente> clientesOrdenadosPorNome = Relatorios.clientesOrdenadosPorNome(cliente);
        foreach (var cliente in clientesOrdenadosPorNome) {
            Console.WriteLine($"Nome: {cliente.Nome}");
        }
        
        Console.WriteLine("\n5. Clientes do mais velho para o mais novo:");
        List<Cliente> clienteOrdenadosPorIdade = Relatorios.clienteOrdenadosPorIdade(clientes);
        foreach (var cliente in clienteOrdenadosPorIdade) {
            Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}");
        }

        Console.WriteLine("\n6. Treinadores e clientes aniversariantes do mes informado:");
        List<Pessoa> anviversariantes = Relatorios.AniversariantesDoMes(treinadores.Cast<Pessoa>().Concat(clientes.Cast<Pessoa>()), 5);
        foreach (var pessoa in anviversariantes) {
            Console.WriteLine($"Nome: {pessoa.Nome}, Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
        }
        
            
        }
    }


class Pessoa {
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;
}

class Treinador : Pessoa {
    public string CPF { get; set; }
    public string CREF { get; set; }

    public Treinador(string nome, DateTime dataNascimento, string cpf, string cref) {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        CREF = cref;
    }
}


class Cliente : Pessoa {
    public string CPF { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, double altura, double peso) {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        Altura = altura;
        Peso = peso;
    }

    public double CalcularIMC() {
        return Peso / (Altura * Altura);
    }
}

class Relatorios {
    public static List<Treinador> TreinadoresEntreIdades(List<Treinador> treinadores, int idadeMin, int idadeMax) {
        return treinadores.Where(t. => t.Idade >= idadeMin && t.Idade <= idadeMax).ToList();
    }

    public static List<Cliente> ClientesEntreIdades(List<Cliente> clientes, int idadeMin, int idadeMax) {
        return clientes.Where(c => c.Idade >= idadeMin && c.Idade <= idadeMax).ToList();    
    }

    public static List<Cliente> ClientesPorIMC(List<Cliente> clientes, double imcMin) {
        return clientes.Where(c => CalcularIMC() > imcMin).OrderBy(c. => c.CalcularIMC()).ToList();
    }

    public static List<Cliente> ClientesOrdenadosPorNome(List<Cliente> clientes) {
        return clientes.OrderBy(char => c.Nome).ToList();
    }

    public static List <Cliente> ClientesOrdenadosPorIdade(List<Cliente> clientes) {
        return clientes.OrderByDescending(c => c.Idade).ToList();
    }

    public static List<Pessoa> AniveriantesDoMes(IEnumerable<Pessoa> pessoas, int mes) {
        return pessoas.Where(p => p.DataNascimento.Month == mes).ToList();
    }
}