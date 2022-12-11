using System;
using System.Collections;

namespace EPQ_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator number = new NumberGenerator(100, 10000);  //(number of passess to make, # of numbers to generate in each pass)

            number.runAlgorithm();


            Console.ReadLine();
        }
    }

    class NumberGenerator
    {
        private double m = 3;
        private double seed = 0;
        private int numberOfPasses = 0;
        private int numOfNumbers = 0;
        private int count = 0;
        private Stack stack = new Stack();
        private Random rnd = new Random();

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

                if (n == 0)
                {
                    one++;
                }

                if (n == 1)
                {
                    two++;
                }

                if (n == 2)
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
            string number;
            double seed = 0;
            double num1 = 0;
            double num2 = 0;

            do
            {
                seed = DateTime.Now.Ticks % 100000;
            }
            while (seed < 21300 && seed / 2 != 0);

            stack.Push(seed);
            num1 = Math.Pow(seed, 2);

            for (int i = 0; i < numOfNumbers; i++)
            {
                number = Convert.ToString(num1);

                number = number.Substring(0, 8);

                num2 = Convert.ToDouble(number);

                num1 = Math.Pow(num2, 2);

                num2 = num2 % 3;

                stack.Push(num2);
            }
        }
        public Stack returnStackofNumbers()
        {
            return stack;
        }

    }
}


