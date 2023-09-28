using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ar_Class_ex2_lb2
{
    public class Ar
    {
        private int n;
        private int[] a;
        private int k;

        // Конструктор 1
        public Ar(int a, int b)
        {
            n = (b - a + 2) / 2; // кількість парних чисел в діапазоні [a, b]
            this.a = new int[n];
            int value = a;
            for (int i = 0; i < n; i++)
            {
                this.a[i] = value;
                value += 2;
            }
            CalculateK();
        }

        // Конструктор 2
        public Ar(string input)
        {
            string[] numbers = input.Split(',');
            n = numbers.Length;
            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(numbers[i]);
            }
            CalculateK();
        }

        private void CalculateK()
        {
            k = 0;
            foreach (int element in a)
            {
                if (element < 20)
                    k++;
            }
        }

        // Властивість для читання поля n
        public int N
        {
            get { return n; }
        }

        // Властивість для читання властивості k
        public int K
        {
            get { return k; }
        }

        // Метод для виведення масиву на екран
        public void Print()
        {
            Console.WriteLine("Масив:");
            foreach (int element in a)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        // Метод для знаходження індексу останнього елемента, який закінчується на 0
        public int P()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                if (a[i] % 10 == 0)
                    return i;
            }
            return -1;
        }

        // Метод для обчислення твору елементів масиву з індексами від i1 до i2
        public int Pr(int i1, int i2)
        {
            int product = 1;
            for (int i = i1; i <= i2; i++)
            {
                product *= a[i];
            }
            return product;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Console.WriteLine("Оберіть конструктор (1 або 2):");
                int constructorChoice = int.Parse(Console.ReadLine());

                Ar array;

                if (constructorChoice == 1)
                {
                    Console.Write("Введіть a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Введіть b: ");
                    int b = int.Parse(Console.ReadLine());
                    array = new Ar(a, b);
                }
                else if (constructorChoice == 2)
                {
                    Console.Write("Введіть числа, розділені комою: ");
                    string input = Console.ReadLine();
                    string[] numbers = input.Split(',');

                    int[] parsedNumbers = new int[numbers.Length];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (!int.TryParse(numbers[i], out parsedNumbers[i]))
                            throw new FormatException("Некоректні дані. Будь ласка, введіть числа, розділені комою.");
                    }

                    array = new Ar(input);
                }
                else
                {
                    throw new ArgumentException("Неправильний вибір конструктора.");
                }

                array.Print();
                Console.WriteLine("Кількість елементів менше 20: " + array.K);

                int lastIndex = array.P();
                if (lastIndex != -1)
                {
                    Console.WriteLine("Індекс останнього елемента, який закінчується на 0: " + lastIndex);
                    int productBeforeIndex = array.Pr(0, lastIndex);
                    Console.WriteLine("Добуток елементів до цього індексу: " + productBeforeIndex);
                }
                else
                {
                    Console.WriteLine("Елемент, що закінчується на 0, не знайдено.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Виникла невідома помилка: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}

