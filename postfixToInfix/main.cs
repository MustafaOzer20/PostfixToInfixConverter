using postfixToInfix;
using System;

class PostfixToInfix
{
    public static void Main(String[] args)
    {
        while (true)
        {
            Console.Write("Arttaki ifade girin: ");
            String exp = Console.ReadLine();
            GetInfix getInfixObj = new GetInfix(exp);
            Console.WriteLine(getInfixObj.convertToInfix());
        }
        



    }
}
