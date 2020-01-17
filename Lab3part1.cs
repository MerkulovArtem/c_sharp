using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3svojstvaindexatori
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Лабараторная работа №3. Свойства и индексаторы.");
            Console.WriteLine("Меркулов А.А. М30-235Б-18");
            Console.WriteLine();

            KvadrUrav ex = new KvadrUrav();
            Matrix m = new Matrix();
            Alph16 a = new Alph16();

            int menu;

            do //Меню
            {
                Console.WriteLine("Меню: ");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Дескрименант квадратного уравнения");
                Console.WriteLine("2 - Определитель матрицы 2x2");
                Console.WriteLine("3 - Двоичная запись алфавита шестнадцатеричной системы счисления");
                Console.WriteLine("Введите пункт меню: ");
                menu = OnlyInt();
                switch (menu)
                {
                    case 0: break;
                    case 1:
                        Console.WriteLine("Введите коэффициенты квадратного уравнения (Ax^2+Bx+C=0): ");
                        Console.Write("Введите параметр A: ");
                        ex.A = OnlyDouble();
                        Console.Write("Введите параметр B: ");
                        ex.B = OnlyDouble();
                        Console.Write("Введите параметр C: ");
                        ex.C = OnlyDouble();
                        Console.WriteLine("Дискременант равен = {0}", ex.Diskriminant);
                        break;
                    case 2:
                        Console.WriteLine("Введите матрицу вида: ");
                        Console.WriteLine("|A B|");
                        Console.WriteLine("|C D|");

                        Console.Write("Введите A: ");
                        m.A = OnlyDouble();
                        Console.Write("Введите B: ");
                        m.B = OnlyDouble();
                        Console.Write("Введите C: ");
                        m.C = OnlyDouble();
                        Console.Write("Введите D: ");
                        m.D = OnlyDouble();

                        Console.WriteLine("Определитель матрицы = {0}", m.Determinant);
                        break;
                    case 3:
                        Console.WriteLine("Bведите символ из алфавита шестнадцатеричной системы счисления: ");
                        char c = OnlyChar();
                        Console.WriteLine(a[c]);
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню");
                        break;
                }
            } while (menu != 0);
        }

    
    class KvadrUrav//Квадратное уравнение
    {
        private double a, b, c;
        public double A
        {
            set
            {
                a = value;
            }
        }
        public double B
        {
            set
            {
                b = value;
            }
        }
        public double C
        {
            set
            {
                c = value;
            }
        }
        public double Diskriminant
        {
            get
            {
                return b * b - 4 * a * c;
            }
        }
    }

    class Matrix//Матрица 2х2
    {
        private double[,] m= new double[2, 2];
        public double A
        {
            set
            {
                m[0, 0] = value;
            }
        }
        public double B
        {
            set
            {
                m[0, 1] = value;
            }
        }
        public double C
        {
            set
            {
                m[1, 0] = value;
            }
        }
        public double D
        {
            set
            {
                m[1, 1] = value;
            }
        }
        public double Determinant
        {
            get
            {
                return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
            }
        }
    }

    class Alph16//Алфавит шестнадцетеричной системы счисления
    {
        public string this[char i]
        {
                get
                {
                    if ((i >= 48 && i <= 57))
                        return Convert.ToString(i - 48, 2).PadLeft(4, '0');
                    else if ((i >= 65 && i <= 70))
                        return Convert.ToString(i - 55, 2).PadLeft(4, '0');
                    else
                        return "Нет такого символа в алфавите шестнадцатеричной системы счисления";

                }
        }
    }
        public static double OnlyDouble() // ввод только double
        {
            string str;
            double dbuff;
            bool flag;
            do
            {
                str = Console.ReadLine();
                if (double.TryParse(str, out dbuff))
                    flag = false;
                else
                {
                    Console.WriteLine("Неккоректный тип данных. Повторите ввод: ");
                    flag = true;
                }
            } while (flag);
            return dbuff;
        }
        public static int OnlyInt() // ввод только int
        {
            string str;
            int ibuff;
            bool flag;
            do
            {
                str = Console.ReadLine();
                if (int.TryParse(str, out ibuff))
                    flag = false;
                else
                {
                    Console.WriteLine("Неккоректный тип данных. Повторите ввод: ");
                    flag = true;
                }
            } while (flag);
            return ibuff;
        }
        public static char OnlyChar() // ввод только char
        {
            string str;
            char cbuff;
            bool flag;
            do
            {
                str = Console.ReadLine();
                if (char.TryParse(str, out cbuff))
                    flag = false;
                else
                {
                    Console.WriteLine("Неккоректный тип данных. Повторите ввод: ");
                    flag = true;
                }
            } while (flag);
            return cbuff;
        }
    }
}
