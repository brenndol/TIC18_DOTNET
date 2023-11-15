using System;
#region 

class Logic
{
    static void Main()
    {
        bool condicao1 = true;
        bool condicao2 = false;

        bool ambasCond = condicao1 && condicao2;    

        Console.WriteLine($"Ambas as condições são {(ambasCond ? "verdadeiras" : "falsas")}");
    }
}

#endregion