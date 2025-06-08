using System;

namespace EnumTasks
{
    // Задача 1
    enum Month
    {
        Январь = 1, Февраль, Март, Апрель, Май, Июнь,
        Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь
    }

    // Задача 2
    enum WeekDay
    {
        Понедельник = 1, Вторник, Среда, Четверг, Пятница, Суббота, Воскресенье
    }

    // Задача 3
    enum MathOperation
    {
        Add, Subtract, Multiply, Divide
    }

    // Задача 4
    enum UserRole
    {
        Администратор, Модератор, Пользователь, Гость
    }

    // Задача 5
    enum Post
    {
        Менеджер = 160,
        Разработчик = 180,
        Дизайнер = 150,
        Тестировщик = 170
    }

    class Accauntant
    {
        public bool AskForBonus(Post worker, int hours)
        {
            return hours > (int)worker;
        }
    }

    class Program
    {
        static void Main()
        {
            // Задача 1
            Console.WriteLine("== Задача 1: Месяцы года ==");
            foreach (Month m in Enum.GetValues(typeof(Month)))
                Console.WriteLine($"{(int)m} - {m}");

            // Задача 2
            Console.WriteLine("\n== Задача 2: Дни недели ==");
            foreach (WeekDay d in Enum.GetValues(typeof(WeekDay)))
                Console.WriteLine($"{(int)d} - {d}");

            // Задача 3
            Console.WriteLine("\n== Задача 3: Вычисления ==");
            Console.Write("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Выберите операцию (Add, Subtract, Multiply, Divide): ");
            string opInput = Console.ReadLine();

            if (Enum.TryParse(opInput, true, out MathOperation op))
            {
                double result = 0;
                switch (op)
                {
                    case MathOperation.Add: result = a + b; break;
                    case MathOperation.Subtract: result = a - b; break;
                    case MathOperation.Multiply: result = a * b; break;
                    case MathOperation.Divide: result = b != 0 ? a / b : throw new DivideByZeroException(); break;
                }
                Console.WriteLine($"Результат: {result}");
            }
            else Console.WriteLine("Ошибка: неверная операция.");

            // Задача 4
            Console.WriteLine("\n== Задача 4: Ввод роли ==");
            Console.Write("Введите вашу роль (Администратор, Модератор, Пользователь, Гость): ");
            string roleInput = Console.ReadLine();

            if (Enum.TryParse(roleInput, true, out UserRole role))
            {
                Console.WriteLine($"Вы зарегистрированы как {role.ToString().ToLower()}.");
            }
            else Console.WriteLine("Ошибка: неизвестная роль.");

            // Задача 5
            Console.WriteLine("\n== Задача 5: Премии ==");
            Console.WriteLine("Доступные должности: Менеджер, Разработчик, Дизайнер, Тестировщик");
            Console.Write("Введите должность: ");
            string postInput = Console.ReadLine();
            Console.Write("Введите количество отработанных часов: ");
            int workedHours = Convert.ToInt32(Console.ReadLine());

            if (Enum.TryParse(postInput, true, out Post post))
            {
                Accauntant acc = new Accauntant();
                bool bonus = acc.AskForBonus(post, workedHours);
                Console.WriteLine(bonus ? "Премия положена." : "Премия не положена.");
            }
            else Console.WriteLine("Ошибка: неизвестная должность.");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
