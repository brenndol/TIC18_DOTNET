using System;
#region 

class Misturper
{
    static void Main()
    {
        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        bool maiorQue = num1 > num2;
        bool igualQue = num3 == (num1 + num2);

        Console.WriteLine($"num1 é {(maiorQue ? "maior" : "não é maior")} que num2");
        Console.WriteLine($"num3 é {(igualQue ? "igual" : "não é igual")} a num1 + num2");
    }
}

#endregion