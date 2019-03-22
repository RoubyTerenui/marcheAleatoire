using System;
namespace MarcheAléatoire
{
    public class TestDes
    {
        private int nbreTest;
        private RandomGenerator generator;
        private int[] tabRes;

        public TestDes()
        {
            this.generator = new RandomGenerator(13, 1073, 43215, 4294967087, 1403580, 810728);
            this.nbreTest = 0;
            this.tabRes = new int[11];
        }

        public void printRes()
        {
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(" tabRes[{0:D}] : {1:P}  \n", i+2, (double)tabRes[i] / nbreTest);
            }
        }

        public void test()
        {
            nbreTest += 1;
            int value1 = generator.generate(1, 7);
            int value2 = generator.generate(1, 7);
            tabRes[value1 + value2 - 2] += 1;
        }
    }
}
