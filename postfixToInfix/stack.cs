using System;


namespace postfixToInfix
{
    class Stack
    {
        String[] myStack;
        int temp;

        public Stack(int size)
        {
            myStack = new String[size];
            temp = 0;
        }

        public void Push(String obj)
        {
            if(IsFull())
                return;
            
            myStack[temp] = obj;
            temp++;

        }

        public String Pop()
        {
            if(IsEmpty())
                return "";

            temp--;
            return myStack[temp];
        }

        public bool IsFull()
        {
            return temp == myStack.Length;
        }
        public bool IsEmpty()
        {
            return temp == 0;
        }

        public int Count()
        {
            return temp;
        }
    }
}
