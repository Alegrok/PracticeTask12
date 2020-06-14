using System;

namespace PracticeTask12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение по проверке эффективности двух сортировок: сортировки Шелла и быстрой сортировки");

            // Ввод количества элементов в массивах
            Console.WriteLine("\nВведите количество элементов в массиве");
            uint size = Input(1, 1000000);

            // Создание массивов для проверки сортировки Шелла
            int[] array1 = CreateRandomArray(size);
            int[] sortArray1 = Sort((int[])array1.Clone());
            int[] reverseArray1 = Reverse((int[])sortArray1.Clone());

            // Создание массивов для проверки быстрой сортировки
            int[] array2 = (int[])array1.Clone();
            int[] sortArray2 = (int[])sortArray1.Clone();
            int[] reverseArray2 = (int[])reverseArray1.Clone();

            // Сортировка неупорядоченного массива сортировкой Шелла
            Console.WriteLine("\nПервый неупорядоченный массив");
            ShellSortPrintArray(array1);

            // Сортировка упорядоченного по возрастанию массива сортировкой Шелла
            Console.WriteLine("\nПервый упорядоченный по возрастанию массив");
            ShellSortPrintArray(sortArray1);

            // Сортировка упорядоченного по убыванию массива сортировкой Шелла
            Console.WriteLine("\nПервый упорядоченный по убыванию массив");
            ShellSortPrintArray(reverseArray1);

            // Сортировка неупорядоченного массива быстрой сортировкой
            Console.WriteLine("\nВторой неупорядоченный массив");
            QuickSortPrintArray(array2);

            // Сортировка упорядоченного по возрастанию массива быстрой сортировкой
            Console.WriteLine("\nВторой упорядоченный по возрастанию массив");
            QuickSortPrintArray(sortArray2);

            // Сортировка упорядоченного по убыванию массива быстрой сортировкой
            Console.WriteLine("\nВторой упорядоченный по убыванию массив");
            QuickSortPrintArray(reverseArray2);

            Console.WriteLine("\nЗавершение работы в приложении по проверке эффективности двух сортировок: сортировки Шелла и быстрой сортировки");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        // Сортировка массива для удобного пользования
        public static int[] Sort(int[] array)
        {
            Array.Sort(array);
            return array;
        }

        // Переворот массива для удобного пользования
        public static int[] Reverse(int[] array)
        {
            Array.Reverse(array);
            return array;
        }

        // Вывод массива
        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.WriteLine();
        }

        // Создание массива с рандомными элементами
        public static int[] CreateRandomArray(uint size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = random.Next(1, 100);

            return array;
        }

        // Сортировка Шелла
        public static int[] ShellSort(int[] array, ref ulong movings, ref ulong comparisons)
        {
            for (int step = array.Length / 2; step > 0; step /= 2)
            {
                for (int j, i = step; i < array.Length; i++)
                {
                    int tmp = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        comparisons++;
                        if (tmp < array[j - step])
                        {
                            array[j] = array[j - step];
                            movings++;
                        }
                        else { break; }
                    }
                    array[j] = tmp;
                }
            }
            return array;
        }

        // Печать массива, сортировка массива по алгоритму сортировки Шелла 
        // и печать отсортированного массива, перемещений и сравнений
        private static void ShellSortPrintArray(int[] array)
        {
            ulong movings = 0;
            ulong comparisons = 0;
            Console.Write("Массив: ");
            Print(array);
            Console.Write("Отсортированный массив: ");
            array = ShellSort(array, ref movings, ref comparisons);
            Print(array);
            Console.WriteLine("Перемещения: " + movings);
            Console.WriteLine("Сравнения: " + comparisons);
        }

        // Быстрая сортировка
        public static int[] QuickSort(int[] array, int left, int right, ref ulong movings, ref ulong comparisons)
        {
            int i = left, j = right;
            int buf = array[(left + right) / 2];
            do
            {
                while (array[i] < buf) i++;
                while (array[j] > buf) j--;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                    movings++;
                }
                comparisons++;
            } while (i <= j);
            if (left < j) QuickSort(array, left, j, ref movings, ref comparisons);
            if (i < right) QuickSort(array, i, right, ref movings, ref comparisons);
            return array;
        }

        // Печать массива, сортировка массива по алгоритму быстрой сортировки 
        // и печать отсортированного массива, перемещений и сравнений
        private static void QuickSortPrintArray(int[] array)
        {
            ulong movings = 0;
            ulong comparisons = 0;
            Console.Write("Массив: ");
            Print(array);
            Console.Write("Отсортированный массив: ");
            array = QuickSort(array, 0, array.Length - 1, ref movings, ref comparisons);
            Print(array);
            Console.WriteLine("Перемещения: " + movings);
            Console.WriteLine("Сравнения: " + comparisons);
        }

        // Ввод целого положительного числа
        private static uint Input(uint min, uint max)
        {
            uint number;
            bool check;
            do
            {
                Console.Write("Ввод: ");
                check = uint.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!check) Console.WriteLine("Ошибка! Введите целое положительное число");
            } while (!check);
            return number;
        }
    }
}
