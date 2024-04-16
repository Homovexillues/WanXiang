using System;

namespace WanXiang
{
    internal class Dice
    {
        public void Side(int side)
        {
            Random random = new Random();
            switch (side)
            {
                case 1: Console.WriteLine($"6={ random.Next(1, 7)}"); break;
                case 2: Console.WriteLine($"8={ random.Next(1, 9)}"); break;
                case 3: Console.WriteLine($"10={ random.Next(1, 11)}"); break;
                case 4: Console.WriteLine($"20={ random.Next(1, 21)}"); break;
                case 5: Console.WriteLine($"100={ random.Next(1, 101)}"); break;
            }
        }
        public Dice() 
        { 
            while (true)
            {
                Console.WriteLine("1. 6面骰");
                Console.WriteLine("2. 8面骰");
                Console.WriteLine("3. 10面骰");
                Console.WriteLine("4. 20面骰");
                Console.WriteLine("5. 100面骰");
                Console.Write("请选择骰子面数:");
                int side =int.Parse(Console.ReadLine());
                Console.Write("请选择投掷次数:");
                int times =int.Parse(Console.ReadLine());
                for (int i = 0; i < times; i++)
                {
                    Console.Write($"{i+1}D");
                    Side(side);
                }
                
            }
        }
    }
}
