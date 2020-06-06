using System;

namespace practical_task7
{
    public class Program
    {
        // Вывод меню
        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // Выбор пункта из меню
        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice == 0) choice = menuItems.Length;
                        choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == menuItems.Length - 1) choice = -1;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        // Ввод целого числа
        public static int IntInput(int lBound = int.MinValue, int uBound = int.MaxValue, string info = "")
        {
            bool exit;
            int result;
            Console.Write(info);
            do
            {
                exit = int.TryParse(Console.ReadLine(), out result);
                if (!exit) Console.Write("Введено нецелое число! Повторите ввод: ");
                else if (result <= lBound || result >= uBound)
                {
                    exit = false;
                    Console.Write("Введено недопустимое значение! Повторите ввод: ");
                }
            } while (!exit);
            return result;
        }

        // Обмен значений двух элементов в массиве
        static void Swap(int[] arr, int i1, int i2)
        {
            int tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        }

        // Нахождение следующего размещения
        static bool NextSelection(int[] elements, int n, int k)
        {
            int i;

            // Цикл повторяется пока не будет найдено новое размещение
            do
            {
                // Поиск первого с конца элемента, который меньше следующего за ним
                i = n - 2;
                while (i >= 0 && elements[i] >= elements[i + 1]) i--;
                
                // Больше размещений нет
                if (i == -1) return false;

                // Поиск первого с конца элемента, который больше элемента с индексом i
                int j = n - 1;
                while (elements[i] >= elements[j]) j--;

                // Обмениваем найденные элементы
                Swap(elements, i, j);

                // Сортируем оставшуюся часть последовательности
                int l = i + 1, r = n - 1;
                while (l < r) Swap(elements, l++, r--);

            } while (i > k - 1); // Пока порядок до элемента с индексом k не меняется можно считать, что размещения не изменяются
            
            return true;
        }

        // Вывод размещений из n по k без повторений в лексикографическом порядке
        public static void PrintSelections(int[] elements, int n, int k)
        {
            do
            {
                for (int i = 0; i < k; i++) Console.Write(elements[i] + " ");
                Console.WriteLine();
            } while (NextSelection(elements, n, k));
        }

        static void Main(string[] args)
        {
            // Пункты меню
            string[] MENU_ITEMS = { "Ввести данные для генерации размещений", "Выйти из программы" };

            // Индекс пункта - выход из программы
            const int EXIT_CHOICE = 1;

            // Индекс пункта меню, который выбрал пользователь
            int userChoice;

            while (true)
            {
                // Пользователь выбирает действие (выйти или сгенерировать размещения)
                userChoice = MenuChoice(MENU_ITEMS, "Программа для генерации размещений из n по k без повторений\nи их вывода в лексикографическом порядке\nВыберите действие:");
                if (userChoice == EXIT_CHOICE) break;
                Console.Clear();

                // Ввод n и k
                int n = IntInput(info: "Введите n (целое число больше 0): ", lBound: 0);
                int k = IntInput(info: "Введите k (целое число 0 < k <= n): ", lBound: 0, uBound: n - 1);
                Console.Clear();

                // Заполнение массива для вариантов размещений
                int[] elements = new int[n];
                for (int i = 0; i < n; i++) elements[i] = i + 1;

                // Вывод размещений
                Console.WriteLine($"Размещения из {n} по {k} в лексикографическом порядке:");
                PrintSelections(elements, n, k);
                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
                Console.ReadLine();
            }
        }
    }
}
