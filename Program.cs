using System;
using System.Collections;

namespace EPQ_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator number = new NumberGenerator(30, 10000);  //(number of passess to make, # of numbers to generate in each pass)

            number.runAlgorithm();


            Console.ReadLine();
        }
    }

    class NumberGenerator
    {
        private double m = 3;
        private double seed  = 0;
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
            string number;
            double seed = 0;
            double num1 = 0;
            double num2 = 0;

            Stack stack = new Stack();
            Random rnd = new Random();

            do
            {
                seed = DateTime.Now.Ticks % 1000;
            }
            while (seed < 213 && seed / 2 != 0);

            stack.Push(seed);
            num1 = Math.Pow(seed, 2);

            for (int i = 0; i < numOfNumbers; i++)
            {
                number = Convert.ToString(num1);

                if (number.Length == 6)
                {
                    double chance = rnd.NextDouble();

                    if (chance < 0.5)
                    {
                        number = number.Substring(0, 4);
                        number = number.Substring(1, 3);
                    }
                    else
                    {
                        number = number.Substring(1, 4);
                        number = number.Substring(1, 3);
                    }

                    num2 = Convert.ToDouble(number);
                    stack.Push(num2);

                    num1 = Math.Pow(num2, 2);
                }

                else if (number.Length == 5)
                {
                    number = number.Substring(0, 4);
                    number = number.Substring(1, 3);

                    num2 = Convert.ToDouble(number);

                    stack.Push(num2);
                    num1 = Math.Pow(num2, 2);
                }
            }

            for (int i = 0; i < stack.Count; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        public Stack returnStackofNumbers()
        {
            return stack;   
        }
    }
}
