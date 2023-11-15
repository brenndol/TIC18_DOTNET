using System;
#region

class Program
{
    static void Main()
    {   
        int x = 10;
        int y = 3;

        // Realizar operações aritméticas
        int soma = x + y;
        int subtracao = x - y;
        int multiplicacao = x * y;

        // Verificar se o segundo número é zero antes de realizar a divisão
        double divisao = 0;
        if (y != 0)
        {
            divisao = x / y;
        }

        // Exibir resultados
        Console.WriteLine($"Soma: {soma}");
        Console.WriteLine($"Subtração: {subtracao}");
        Console.WriteLine($"Multiplicação: {multiplicacao}");
        
        if (y != 0)
        {
            Console.WriteLine($"Divisão: {divisao}");
        }
        else
        {
            Console.WriteLine("Não é possível dividir por zero.");
        }
    }
}
#endregion