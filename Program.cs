using System;

namespace EPQ_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 1; j <= 30; j++)
            {
                var freq = new int[50];
                var rng = new RandomNumberGenerator();
                int numOfValuesToGenerate = 10000;



                int one = 0, two = 0, three = 0;


                for (int i = 0; i < numOfValuesToGenerate; i++)
                {
                    var rnd = rng.Next(3);
                    freq[rnd] += 1;

                    if (rnd == 0)
                    {
                        one++;
                    }
                    else if (rnd == 1)
                    {
                        two++;
                    }
                    else if (rnd == 2)
                    {
                        three++;
                    }
                }

                Console.WriteLine($"{j}) Each number frequency");

                Console.WriteLine($"One: {one}");
                Console.WriteLine($"Two: {two}");
                Console.WriteLine($"Three: {three}");

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    class RandomNumberGenerator
    {
        private const long m = 4294967296; // aka 2^32
        private const long a = 1664525; //the multiplie
        private const long c = 1013904223;  //the increment
        private long _last;

        public RandomNumberGenerator()
        {
            _last = DateTime.Now.Ticks % m; //gets the value from the nternal clock in the computer
        }

        public RandomNumberGenerator(long seed)
        {
            _last = seed;
        }

        public long Next()
        {
            _last = ((a * _last) + c) % m; //eqaution

            return _last;
        }

        public long Next(long maxValue)
        {
            return Next() % maxValue;
        }
    }
}
