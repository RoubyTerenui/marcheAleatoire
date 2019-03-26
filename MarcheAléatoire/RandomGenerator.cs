using System;
namespace MarcheAléatoire
{
    public class RandomGenerator
    {
        private double x0, x_1, x_2, n, k, u;

        // Constructor

        public RandomGenerator(double x0, double x_1, double x_2, double n, double k, double u)
        {
            if (x0 > 0 && x_1 > 0 && x_2 > 0)
            {
                if (x0 <= n && x_1 <= n && x_2 <= n)
                {
                    this.X0 = x0;
                    this.X_1 = x_1;
                    this.X_2 = x_2;
                    this.N = n;// Choisir n premier
                    this.K = k;// Choisir k-1 multiple de 4 
                    this.U = u;// Choisir u impair
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }

        // Getters and Setters
        public double X0 { get => x0; set => x0 = value; }
        public double X_1 { get => x_1; set => x_1 = value; }
        public double X_2 { get => x_2; set => x_2 = value; }
        public double N { get => n; set => n = value; }
        public double K { get => k; set => k = value; }
        public double U { get => u; set => u = value; }

        // Other functions
        private double mod(double x, double m)
        {
            double res1 = (x % m + m) % m;
            return res1;
        }

        public void congruence()
        {
            double res = 0;
            res = mod((K * X_1 - U * X_2) , N + 1);
            X_2 = X_1;
            X_1 = X0;
            X0 = res;
        }

        public int generate(int min, int max)
        {
            this.congruence();
            double temp =(mod( X0 , (N + 1)) )/ (N + 1);
            int res = Convert.ToInt32(Math.Floor(temp * (max +1 - min) + min));
            return res;
        }

    }
}
