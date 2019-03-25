using System;
namespace MarcheAléatoire
{
    public class TestDes
    {
        private int nbreTest;
        private RandomGenerator generator;
        private int[] tabRes;

        // Constructor

        public TestDes()
        {
            this.Generator = new RandomGenerator(105, 107484, 643216, 4294967085, 1403580, 810728);
            this.NbreTest = 0;
            this.TabRes = new int[11];
        }

        // Getters and Setters

        public int NbreTest { get => nbreTest; set => nbreTest = value; }
        public RandomGenerator Generator { get => generator; set => generator = value; }
        public int[] TabRes { get => tabRes; set => tabRes = value; }

        // Other functions

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
            int value1 = Generator.generate(1, 7);
            int value2 = Generator.generate(1, 7);
            TabRes[value1 + value2 - 2] += 1;
        }
    }
}
