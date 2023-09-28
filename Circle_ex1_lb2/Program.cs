using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_ex1_lb2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                // Створення об'єкта за допомогою конструктора за замовчуванням
                Circle circle = new Circle();

                // Введення значення радіуса з клавіатури
                Console.Write("Введіть значення радіуса: ");
                double radiusInput = Convert.ToDouble(Console.ReadLine());

                // Присвоєння значення полю через властивість
                circle.Radius = radiusInput;

                // Виведення значення поля на екран
                circle.Print();

                // Перевірка можливості існування об'єкта та виклик інших методів
                if (circle.Correct())
                {
                    Console.WriteLine("Площа круга: " + circle.Area().ToString("F2"));
                    Console.WriteLine("Довжина кола: " + circle.Length().ToString("F2"));
                }
                else
                {
                    Console.WriteLine("Коло з введеним радіусом не може існувати.");
                }
            }
            catch 
            {
                Console.WriteLine("Виникла помилка");
            }
            Console.ReadLine();
        }
        public class Circle
        {
            private double radius;

            // Конструктор за замовчуванням
            public Circle()
            {
                radius = 0.0;
            }

            // Властивість для присвоєння значення радіусу
            public double Radius
            {
                get { return radius; }
                set { radius = value; }
            }

            // Логічний метод для перевірки чи може існувати об'єкт
            public bool Correct()
            {
                return radius > 0;
            }

            // Метод для обчислення площі круга
            public double Area()
            {
                return Math.PI * radius * radius;
            }

            // Метод для обчислення довжини кола
            public double Length()
            {
                return 2 * Math.PI * radius;
            }

            // Метод для виведення значення поля
            public void Print()
            {
                Console.WriteLine("Радіус кола: " + radius);
            }
        }
    }
}
