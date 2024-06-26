namespace WanXiang.MathTools
{
    internal static class MathProblem
    {
        internal static void GoldBach() {
            int n = 4;
            while(true) {
                var find = false;
                for(int a = 2;a <= n / 2;a++) {
                    var b = n - a;
                    if(a.isPrime() && b.isPrime()) {
                        Console.WriteLine($"n={n};a={a};b={b};");
                        find = true;
                        break;
                    }
                }
                if(!find) {
                    Console.WriteLine($"Finally found it! ——> n={n}");
                    break;
                }
                else {
                    n += 2;
                }
            }
        }

        internal static bool isPrime(this int number) {
            if(number <= 1) return false;//质数需要大于1
            if(number == 2) return true;//2也是质数
            if(number % 2 == 0) return false;//排除偶数
            int boundary = (int)Math.Sqrt(number);
            for(int i = 3;i < boundary;i += 2) {
                if(number % i == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}