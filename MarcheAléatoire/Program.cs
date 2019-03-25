using System;

namespace MarcheAléatoire
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDes test = new TestDes();

            for (int i = 0; i < 1000; i++){
                test.test();
            }

            test.printRes();


            RandomGenerator rando=new RandomGenerator(105, 107484, 643216, 4294967085, 1403580, 810728);
            for(int j = 0; j < 100; j++) {
                int x2 = rando.generate(0, 1);
            }
            
        }
    }
}
