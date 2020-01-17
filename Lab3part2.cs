using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3OopDelsSobsInterfsFails
{
    class Program
    {
        static void Main(string[] args)
        {
            Info();

            DataPerson list = new DataPerson();
            int menu, ibuff;
            


            Console.WriteLine("Введите данные человека: ");
            list.InData = InPerson();
            Console.WriteLine("Данные введены");
            list.Notify += DisplayMessage;

            do//Меню
            {
                Console.WriteLine("0 - Выход из программы\n" +
                "1 - Добавить в список еще одного человека\n" +
                "2 - Вывести список\n" +
                "3 - Удалить из списка человека по номеру в списке\n" +
                "4 - Очисть список\n" +
                "5 - Записать список в файл\n" +
                "6 - Прочитать список из файла\n" +
                "Введите пункт меню: ");

                menu = InInt();
                while (menu < 0 || menu > 6)
                {
                    Console.WriteLine("Номер функции должен быть больше -1 но меньше 6.\n" +
                    "Введите данные заново: ");
                    menu = InInt();
                }

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Введите данные человека: ");
                        list.InData = InPerson();
                        Console.WriteLine("Данные введены");
                        break;
                    case 2:
                        if (!list.PrintData())
                            Console.WriteLine("Список пуст");
                        break;
                    case 3:
                        Console.WriteLine("Введите номер человека в списке для удаления");
                        ibuff = InInt();
                        if (list.DelPerson(ibuff))
                            Console.WriteLine("Человек с номер {0} удален из списка", ibuff);
                        else if (ibuff < 1)
                            Console.WriteLine("Номер в списке должен быть больше нуля");
                        else
                            Console.WriteLine("Нет человека с номером {0}", ibuff);
                        break;
                    case 4:
                        list.Clener();
                        Console.WriteLine("Список очищен");
                        break;
                    case 5:
                        list.WriteFile();
                        Console.WriteLine("Данные записаны в файл");
                        break;
                    case 6:
                        list.ReadFile();
                        Console.WriteLine("Файл был прочитан");
                        break;
                }

            } while (menu != 0);
        }

        public static void Info() //Информация о программе
        {
            Console.WriteLine("Лабараторная работа №3");
            Console.WriteLine("Меркулов А.А. М30-235Б-18");
            Console.WriteLine();
            Console.WriteLine("Данная программа реализует базовые функции с списком людей.");
            Console.WriteLine("Также реализованы функции по чтению и записи списка в файл.");
            Console.WriteLine();
        }

        private static void DisplayMessage(string message)//Сообщение события
        {
            Console.WriteLine(message);
        }

        //Функции проверки ввода
        public static DateTime InDateTime()
        {
            string str;
            DateTime dtbuff;
            str = Console.ReadLine();
            while (!(DateTime.TryParse(str, out dtbuff)))
            {
                Console.WriteLine("Вы ввели дату в неправильном формате. Введите дату заново: ");
                str = Console.ReadLine();
            }
            return dtbuff;
        }

        public static char InChar()
        {
            string str;
            char cbuff;
            str = Console.ReadLine();
            while (!(char.TryParse(str, out cbuff)))
            {
                Console.WriteLine("Вы ввели строку а не символ. Введите данные заново: ");
                str = Console.ReadLine();
            }
            return cbuff;
        }

        public static int InInt()
        {
            string str;
            int ibuff;
            str = Console.ReadLine();
            while (!(int.TryParse(str, out ibuff)))
            {
                Console.WriteLine("Вы ввели некорректные данные. Введите данные заново: ");
                str = Console.ReadLine();
            }
            return ibuff;
        }

        public static Person InPerson()
        {
            Person buff = new Person();

            Console.Write("Введите фамилию человека: ");
            buff.Surname = Console.ReadLine();
            while (buff.Surname.Length < 2 || buff.Surname.Length > 25)
            {
                Console.WriteLine("Фамилия должна иметь больше 1 буквы и меньше 25 букв.\n" +
                "Введите фамилию заново: ");
                buff.Surname = Console.ReadLine();
            }


            Console.Write("Введите имя человека: ");
            buff.Name = Console.ReadLine();
            while (buff.Name.Length < 2 || buff.Name.Length > 20)
            {
                Console.WriteLine("Имя должно иметь больше 1 буквы и меньше 20 букв.\n" +
                "Введите имя заново: ");
                buff.Name = Console.ReadLine();
            }

            Console.Write("Введите дату рождения человека в формате (day.month.year): ");
            buff.DOB = InDateTime();
            while (buff.DOB.Year < (DateTime.Now.Year - 200) || buff.DOB.Year > (DateTime.Now.Year - 14))
            {
                Console.WriteLine("Возрост должен бать больше 14 лет и меньше 200\n" +
                "Введите дату рождения заново: ");
                buff.Name =     Console.ReadLine();
            }

            Console.Write("Введите пол человека. М - мужской, Ж - женский: ");
            buff.Gender = InChar();
            while (buff.Gender != 'М' && buff.Gender != 'Ж')
            {
                Console.WriteLine("Нет такого пола.\n" +
                "Введите данные заново (М - мужской, Ж - женский): ");
                buff.Gender = InChar();
            }

            Console.Write("Введите рост человека: ");
            buff.Height = InInt();
            while (buff.Height < 50 || buff.Height > 250)
            {
                Console.WriteLine("Рост должен быть больше 50 но меньше 250.\n" +
                "Введите рост заново: ");
                buff.Height = InInt();
            }

            Console.Write("Введите вес человека: ");
            buff.Weight = InInt();
            while (buff.Weight < 40 || buff.Weight > 250)
            {
                Console.WriteLine("Вес должен быть больше 40 но меньше 250.\n" +
                "Введите вес заново: ");
                buff.Weight = InInt();
            }

            return buff;
        }
    }

    class Person//Данные о человеке
    {
        public string Surname { set; get; }
        public string Name { set; get; }
        public DateTime DOB { set; get; }
        public char Gender { set; get; }
        public int Height { set; get; }
        public int Weight { set; get; }
    }

    interface IData//Интерфейс
    {
        int Size { get; }
        bool PrintData();
        void Clener();
    }

    class DataPerson : IData
    {
        //Событие
        public delegate void Birthday(string str);
        public event Birthday Notify;
      
       
       

        private List<Person> data = new List<Person>();

        public int Size { get => data.Count; }
        public Person InData { set => data.Add(value); }

        //Возращение человека из списка и печать списка
        public Person OutPerson(int i) { return data[i - 1]; }
        public bool PrintData()
        {
            if (data.Count == 0)
                return false;
            else
            {
                int i = 1;
                foreach (Person buff in data)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("{0})", i);
                    Console.WriteLine("Фамилия: {0}", buff.Surname);
                    Console.WriteLine("Имя: {0}", buff.Name);
                    Console.WriteLine("Дата рождения (day.month.year): {0}.{1}.{2}", buff.DOB.Day, buff.DOB.Month, buff.DOB.Year);
                    Console.WriteLine("Пол (М - мужской, Ж - женский): {0}", buff.Gender);
                    Console.WriteLine("Рост: {0}", buff.Height);
                    Console.WriteLine("Вес: {0}", buff.Weight);

                    if (buff.DOB.Day == DateTime.Now.Day && buff.DOB.Month == DateTime.Now.Month)
                        Notify?.Invoke($"Сегодня день рождения у {buff.Surname} {buff.Name}");
                    i++;
                }
                Console.WriteLine("------------------------------");
                return true;
            }
        }
        //Удаление из списка
        public bool DelPerson(int i)
        {
            if (i <= data.Count && i > 0)
            {
                data.RemoveAt(i - 1);
                return true;
            }
            else
                return false;
        }
        public void Clener()
        {
            data.Clear();
        }

        //Работа с файлами
        public void ReadFile()
        {
            data.Clear();
            string str = @"PersonList.txt";
            try
            {
                using (StreamReader sr = new StreamReader(str, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Person p = new Person();
                        DateTime dt;
                        char c;
                        int i;

                        p.Surname = line;
                        p.Name = sr.ReadLine();

                        DateTime.TryParse(sr.ReadLine(), out dt);
                        p.DOB = dt;

                        char.TryParse(sr.ReadLine(), out c);
                        p.Gender = c;

                        int.TryParse(sr.ReadLine(), out i);
                        p.Height = i;

                        int.TryParse(sr.ReadLine(), out i);
                        p.Weight = i;

                        data.Add(p);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void WriteFile()
        {
            string str = @"PersonList.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(str, false, System.Text.Encoding.Default))
                {
                    foreach (Person buff in data)
                    {
                        sw.WriteLine(buff.Surname);
                        sw.WriteLine(buff.Name);
                        sw.WriteLine(buff.DOB);
                        sw.WriteLine(buff.Gender);
                        sw.WriteLine(buff.Height);
                        sw.WriteLine(buff.Weight);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
