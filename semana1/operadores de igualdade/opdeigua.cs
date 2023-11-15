using System;
#region 

class Igual
{
    static void Main()
    {
       string str1 = Hello;
       string str2 = World;

       bool saoIguais = str1 == str2;

       Console.WriteLine($"As strings são iguais {(saoIguais ? "iguais" : "diferentes")}");

    }
}

#endregion