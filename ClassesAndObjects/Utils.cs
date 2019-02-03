using System;

namespace ClassesAndObjects
{
    class Utils
    {
        public void generate()
        {
            // создание объекта - генератора случайных чисел 
            Random random = new Random();
            // генерация координат точки в пределах [0; 100]
            const int MAX = 100;
            double x = random.NextDouble() * MAX;
            double y = random.NextDouble() * MAX;
        }
    }
}