namespace STMRRPP_PT1
{
    internal class Program
    {
        static double t = (Math.Sqrt(5f) - 1f) / 2f;
        static double Fun(double x)
        {
            return Math.Sin(2 * x);
        }
        static double UniformSearch(double ilb, double irb, double eps)
        {
            double new_lb = ilb;
            double new_rb = irb;

            int steps_amount = 0;            
            while (steps_amount <= 1)
            {
                Console.WriteLine("Введите число разбиений: ");
                steps_amount = Convert.ToInt32(Console.ReadLine());
            }

            double min_x = 0f;
            double min_f = Double.MaxValue;           
            
            
            while (Math.Abs(new_rb - new_lb) > eps)
            {
                double step = (new_rb - new_lb) / steps_amount;
                for (double i = new_lb; i < new_rb; i += step)
                {
                    if (Fun(i) < min_f)
                    {
                        min_f = Fun(i);
                        min_x = i;
                    }
                }
                if (min_x == new_lb)
                {
                    new_rb = new_lb + step;
                }
                else if (min_x == new_rb)
                {
                    new_lb = new_rb - step;
                }
                else
                {
                    new_lb = min_x - step;
                    new_rb = min_x + step;
                }
            }            

            return min_f;
        }
        static double Bisection(double ilb, double irb, double eps)
        {
            double new_lb = ilb;
            double new_rb = irb;

            double mid_x = 0f;
            double left_x = 0f;
            double right_x = 0f;

            double min_f = 0f;

            while (Math.Abs(new_rb - new_lb) > eps)
            {
                mid_x = (new_rb + new_lb) / 2f;
                left_x = (new_lb + mid_x) / 2f;
                right_x = (mid_x + new_rb) / 2f;

                if (Fun(left_x) < Fun(right_x))
                {
                    new_rb = mid_x;
                }
                else
                {
                    new_lb = mid_x;
                }
                min_f = Fun((new_rb + new_lb) / 2f);
            }

            return min_f;
        }
        static double FibNumber(int n)
        {
            double number = (Math.Pow(1 / t, n + 1) - Math.Pow(-t,n+1)) / Math.Sqrt(5f);

            return number;
        }
        static double Fibonacci(double ilb, double irb, double eps)
        {
            double new_lb = ilb;
            double new_rb = irb;

            double min_f = 0f;
            
            double x1 = 0f;
            double x2 = 0f;

            int N = 1;
            while ((new_rb - new_lb) / FibNumber(N) >= eps)
            {
                N++;
            }
            Console.WriteLine("Необходимое число итераций равно " + N);

            for (int i = 1; i < N; i++)
            {
                x1 = new_lb + (new_rb - new_lb) * (FibNumber(N - 1 - i) / FibNumber(N + 1 - i));
                x2 = new_lb + (new_rb - new_lb) * (FibNumber(N - i) / FibNumber(N + 1 - i));

                if (Fun(x1) < Fun(x2))
                {
                    new_rb = x2;
                }
                else
                {
                    new_lb = x1;
                }
            }
            min_f = Fun(x1);

            return min_f;
        }
        static double GoldenRatio(double ilb, double irb, double eps)
        {
            double new_lb = ilb;
            double new_rb = irb;

            double min_f = 0f;

            double x1 = 0f;
            double x2 = 0f;

            while (Math.Abs(new_rb - new_lb) > eps)
            {
                x1 = new_rb - (new_rb - new_lb) * t;
                x2 = new_lb + (new_rb - new_lb) * t;

                if (Fun(x1)<Fun(x2))
                {
                    new_rb = x2;
                    min_f = Fun(x1);
                }
                else
                {
                    new_lb = x1;
                    min_f = Fun(x2);
                }
            }

            return min_f;
        }
        static void Main(string[] args)
        {
            double interval_left_border = -(Math.PI / 8f);
            double interval_right_border = 1f;
            double eps3 = 1e-3;
            double eps6 = 1e-6;
            double eps12 = 1e-12;
            double res = 0f;

            res = UniformSearch(interval_left_border, interval_right_border, eps3);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма равномерного поиска при точности " + eps3 + " равно " + res);
            res = UniformSearch(interval_left_border, interval_right_border, eps6);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма равномерного поиска при точности " + eps6 + " равно " + res);
            res = UniformSearch(interval_left_border, interval_right_border, eps12);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма равномерного поиска при точности " + eps12 + " равно " + res + "\n");

            res = Bisection(interval_left_border, interval_right_border, eps3);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма деления пополам при точности " + eps3 + " равно " + res);
            res = Bisection(interval_left_border, interval_right_border, eps6);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма деления пополам при точности " + eps6 + " равно " + res);
            res = Bisection(interval_left_border, interval_right_border, eps12);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма деления пополам при точности " + eps12 + " равно " + res + "\n");

            res = Fibonacci(interval_left_border, interval_right_border, eps3);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма Фибоначчи при точности " + eps3 + " равно " + res);
            res = Fibonacci(interval_left_border, interval_right_border, eps6);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма Фибоначчи при точности " + eps6 + " равно " + res);
            res = Fibonacci(interval_left_border, interval_right_border, eps12);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма Фибоначчи при точности " + eps12 + " равно " + res + "\n");

            res = GoldenRatio(interval_left_border, interval_right_border, eps3);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма золотого сечения при точности " + eps3 + " равно " + res);
            res = GoldenRatio(interval_left_border, interval_right_border, eps6);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма золотого сечения при точности " + eps6 + " равно " + res);
            res = GoldenRatio(interval_left_border, interval_right_border, eps12);
            Console.WriteLine("Минимальное значение функции при использовании " +
                "алгоритма золотого сечения при точности " + eps12 + " равно " + res + "\n");
        }
    }
}