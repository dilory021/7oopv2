using System;

namespace _7oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            FloatLinkedList list = new FloatLinkedList();

            list.AddLast(4.2f);
            list.AddLast(12.5f);
            list.AddLast(-3.1f);
            list.AddLast(15.0f);
            list.AddLast(-8.4f);
            list.AddLast(2.0f);

            Console.WriteLine("Виведення початкового списку");
            foreach (float item in list)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Введення даних користувачем");
            Console.Write("Введіть порогове значення (наприклад, 10,5 або 10.5): ");
            float threshold;
            // Цикл перевіряє, чи користувач ввів саме число. Якщо ввів літери — попросить ще раз.
            while (!float.TryParse(Console.ReadLine().Replace('.', ','), out threshold))
            {
                Console.Write("Помилка! Введіть коректне дійсне число: ");
            }

            Console.WriteLine($"1. Перший елемент більший за {threshold}");
            float? firstGreater = list.FindFirstGreaterThan(threshold);
            if (firstGreater.HasValue) Console.WriteLine($"Елемент: {firstGreater.Value}\n");
            else Console.WriteLine("Елементів не знайдено.\n");

            Console.WriteLine("2. Сума елементів, менших за перший від'ємний");
            Console.WriteLine($"Сума: {list.SumLessThanFirstNegative()}\n");

            Console.WriteLine($"3. Список з елементів більших за {threshold}");
            FloatLinkedList greaterList = list.GetListGreaterThan(threshold);
            Console.Write("Новий список: ");
            foreach (float item in greaterList)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Видалення по індексу");
            int indexToRemove = 0;
            Console.WriteLine($"Видалення елементу з індексом {indexToRemove} ({list[indexToRemove]})...");
            list.RemoveAt(indexToRemove);
            
            Console.WriteLine("Список після видалення");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + "  ");
            }
            Console.WriteLine("\n");
            
            Console.ReadLine();
        }
    }
}