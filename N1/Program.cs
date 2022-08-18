using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N1    //Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. Эту задачу выполняют два садовника (методы), которые не хотят встречаться друг с другом. Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. Создать многопоточное приложение, моделирующее работу садовников.



{
    internal class Program
    {
        const int n = 5;
        static int m = 1;

        static int[,] garden = new int[n, n] { { m, m, m, m, m }, { m, m, m, m, m }, { m, m, m, m, m }, { m, m, m, m, m }, { m, m, m, m, m }, };    //массив значения задержки
       
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(GardenMan1);  //помещаем садовника в скафандр
            Thread thread = new Thread(threadStart);   //сажаем в ракету
            thread.Start();

            GardenMan2();

            for (int i= 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine($"{garden[i, j]}");
                }
                    
            }
            Console.ReadKey();

            //foreach (int i in garden)
            //Console.Write("{0} ", garden[i, i]);
            //Console.ReadKey();
        }

        static void GardenMan1()
        {
            for (int i = 0; i <= n; i++) //i - индекс строки,  j - индекс столбца
            {
                for (int j = 0; j <= n; j++)
                {
                    if (garden[i, j] >= 0)   //проверка на выполнение участка сада другим садовником
                    {
                        int delay = garden[i, j];   //забираем содерживое ячейки
                        garden[i, j] = -1;  //Условная метка садовника - "обработано"
                        Thread.Sleep(delay);    //задержка
                    }
                }
                    
            }
        }
        static void GardenMan2()
        {
            for (int j = n; j >= 0; j--) //i - индекс строки,  j - индекс столбца
            {
                for (int i = n; i >= 0; i--)
                {
                    if (garden[i, j] >= 0)   //проверка на выполнение участка сада другим садовником
                    {
                        int delay = garden[i, j];   //забираем содерживое ячейки
                        garden[i, j] = -2;  //Условная метка садовника - "обработано"
                        Thread.Sleep(delay);    //задержка
                    }
                }

            }
        }

    }
}
