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
        private double m = 209;
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
                double test = n % 3;

                if (test == 0)
                {
                    one++;
                }

                if (test == 1)
                {
                    two++;
                }

                if (test == 2)
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
            double number;

            do
            {
                seed = DateTime.Now.Ticks % 1000;
            }
            while (seed / 2 != 0 && seed < 102);

            stack.Push(seed);
            number = Convert.ToDouble(Math.Pow(seed, 2)) % m;
            stack.Push(number);

            for (int i = 0; i < numOfNumbers - 2; i++)
            {
                number = Math.Pow(number, 2) % m;
                stack.Push(number);
            }
        }
        public Stack returnStackofNumbers()
        {
            return stack;
        }

    }
}


