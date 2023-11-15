using System;
#region 

class Comp 
{
    static void Main()
    {
        int a = 5;
        int b = 8;

        bool aMaiorqueb = a > b;

        Console.WriteLine($"O valor a ({a}) é {(aMaiorqueb ? "maior" : "não é maior")} que o valor de b ({b}).");
    }
}

#endregion