using System;
namespace MarcheAléatoire
{
    public class TestDes
    {
        private int nbreTest;
        private RandomGenerator generator;
        private int[] tabRes;
        private double[] probTheo;

        // Constructor

        public TestDes()
        {
            this.Generator = new RandomGenerator(107, 107484, 643217, 4294967085, 1403580, 810728);
            this.NbreTest = 0;
            this.probTheo =new double[]{ 1,2,3,4,5,6,5,4,3,2,1};
            this.TabRes = new int[11];
        }

        // Getters and Setters

        public int NbreTest { get => nbreTest; set => nbreTest = value; }
        public RandomGenerator Generator { get => generator; set => generator = value; }
        public int[] TabRes { get => tabRes; set => tabRes = value; }

        // Other functions
        public double testKhi2()
        {
            double res=0;
            for(int j = 0; j < 11; j++)
            {
                res+= (((double)tabRes[j] - probTheo[j]*1000/36) * ((double)tabRes[j] - probTheo[j]*1000/36))*36 / (probTheo[j]*1000);
            }
            return res;
        }
        public void printRes()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(" tabRes[{0:D}] : {1:P}  \n", i+2, (double)TabRes[i] / NbreTest);
            }
        }

        public void test()
        {
            NbreTest += 1;
            int value1 = Generator.generate(1, 6);
            int value2 = Generator.generate(1, 6);
            TabRes[value1 + value2 - 2] += 1;
        }
    }
}
