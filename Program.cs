using System;
using System.Collections;

namespace EPQ_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator number = new NumberGenerator(1000, 10000);  //(number of passess to make, # of numbers to generate in each pass)

            number.runAlgorithm();

            Console.ReadLine();
        }
    }

    class NumberGenerator
    {
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

            foreach (int n in numbers)
            {
                int test = n % 3;

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
            Random rnd = new Random();
            Stack st = new Stack();
            string answer = "";
            int standardAnswer;

            for (int i = 0; i < numOfNumbers; i++)
            {
                answer = "";

                for (int k = 0; k < 15; k++)
                {
                    int num = rnd.Next(0, 2);
                    answer = answer + (int)num;
                }

                standardAnswer = (int)Convert.ToInt32(answer, 2);

                st.Push(standardAnswer);
            }

            for (int i = 0; i < numOfNumbers; i++)
            {
                stack.Push(st.Pop());
            }
            
        }

        public Stack returnStackofNumbers()
        {
            return stack;
        }

    }
}


