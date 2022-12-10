using System;
using System.Collections;

namespace EPQ_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator number = new NumberGenerator(1000, 10000);


            number.runAlgorithm();


            Console.ReadLine();
        }
    }

    class NumberGenerator
    {
        private double m = 3;
        private double tempNumber = 0;
        int numberOfPasses = 0;
        int numOfNumbers = 0;
        int count = 0;
        Stack stack = new Stack();

        public NumberGenerator(int p, int n)
        {
            this.numberOfPasses = p;
            this.numOfNumbers = n;
        }

        public void runAlgorithm()
        {
            for (int i = 0; i < numberOfPasses; i++)
            {
                sendNumbers();
                count++;
            }
        }

        public void sendNumbers()
        {
            createNumbers();

            Stack numbers = new Stack();
            numbers = returnStackofNumbers();

            int one = 0;
            int two = 0;
            int three = 0;

            foreach (double n in numbers)
            {
                if (n == 1)
                {
                    one++;
                }

                if (n == 2)
                {
                    two++;
                }

                if (n == 3)
                {
                    three++;
                }
            }

            Console.WriteLine($"{count + 1}) Each number frequency: ");
            Console.WriteLine($"One: {one}");
            Console.WriteLine($"Two: {two}");
            Console.WriteLine($"Three: {three}");
            Console.WriteLine("\t");

            stack.Clear();

        }
        public void createNumbers()
        {
            for (int i = 0; i < numOfNumbers; i++)
            {
                tempNumber = DateTime.Now.Ticks;

                if (tempNumber % m <= 3)
                {
                    tempNumber = tempNumber % m;
                    tempNumber++;
                    stack.Push(tempNumber);
                }
            }
        }

        public Stack returnStackofNumbers()
        {
            return stack;   
        }
    }
}
