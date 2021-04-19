using System;

namespace postfixToInfix
{
    class GetInfix
    {
        private String exp;
        private Stack myStack;
        const String message = "Ictaki Bicimi : ";
        const String errMessage = "Hatali arttaki girdi";

        public GetInfix(String exp)
        {
            this.exp = exp;
            myStack = new Stack(exp.Length);
        }

        public String convertToInfix()
        {
            var catchError = buildInfixStack();

            if (catchError)
                return message + errMessage;

            return message + myStack.Pop();
        }

        private Boolean isOperand(char operand)
        {
            return (operand >= 'a' && operand <= 'z') ||
                    (operand >= 'A' && operand <= 'Z');
        }
        private Boolean isOperator(char operators)
        {
            return (operators == '+' || operators == '-') ||
                    (operators == '*' || operators == '/');
        }

        private Boolean buildInfixStack()
        {
            //hata oldugunda true, olmadiginda false doner.

            for (int i = 0; i < exp.Length; i++)
            {
                if (isOperand(exp[i]))
                {
                    myStack.Push(exp[i] + "");
                }
                else if (isOperator(exp[i]))
                {
                    if (myStack.Count() < 2)
                    {
                        // yiginin icinde birden fazla operand olmali cunku tek degiskenle islem yapamayiz
                        // bu yuzden burada hata mesaji dondurulmelidir.
                        return true;
                    }
                    //karakter operator ise ve bir hata yoksa

                    String op1 = myStack.Pop();

                    String op2 = myStack.Pop();

                    //islem yigina string olarak push edilir.
                    myStack.Push("(" + op2 + exp[i] +
                            op1 + ")");
                }
                else
                {
                    //operand veya operator olmayan bir ifade girildiyse hata mesaji dondurulmelidir.
                    return true;
                }
            }

            if (myStack.Count() != 1)
            {
                //döngü bittiginde elimizdeki yiginda sadece 1 tane String ifade bulunmalıdır.
                // dolayısıyla burada hata mesajı verilmelidir.
                return true;
            }

            return false;
        }

    }
}
