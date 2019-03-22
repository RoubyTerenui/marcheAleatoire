using System;
namespace MarcheAléatoire
{
    public class RandomGenerator
    {
        private double x0, x_1, x_2, n, k, u;

        public RandomGenerator(double x0, double x_1, double x_2, double n, double k, double u)
        {
            if (x0 > 0 && x_1 > 0 && x_2 > 0)
            {
                if (x0 <= n && x_1 <= n && x_2 <= n)
                {
                    this.x0 = x0;
                    this.x_1 = x_1;
                    this.x_2 = x_2;
                    this.n = n;// Choisir n premier
                    this.k = k;// Choisir k-1 multiple de 4 
                    this.u = u;// Choisir u impair
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        public void congruence()
        {
            double res = 0;
            res = (k * x_1 + u * x_2) % (n + 1);
            x_2 = x_1;
            x_1 = x0;
            x0 = res;
        }

        public int generate(int min, int max)
        {
            this.congruence();
            double temp = x0 % (n + 1) / (n + 1);
            int res = Convert.ToInt32(Math.Floor(temp * (max - min) + min));
            return res;
        }

    }
}
