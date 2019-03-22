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
        }
    }
}
