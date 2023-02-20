using System;
using System.Text.RegularExpressions;

namespace Lab_OOP
{
    abstract class UI
    {

        static private InternetOperator internetOperator;

        // Метод, выводящий на экран поля класса разными способами
        public static void PrintPole()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Вывод полей класса с помощью ToString():");
            Console.WriteLine(internetOperator.ToString());

            Console.WriteLine("\nВывод полей класса, обращаясь к полю:");
            Console.WriteLine($"Имя: {internetOperator.NameOfTheOperator}\n" +
                $"Цена: { internetOperator.TheCostOfTheTariff}\n" +
                $"Количество пользователей: {internetOperator.NumberOfUsers}\n" +
                $"Скорость интернета: {internetOperator.InternetSpeed}\n" +
                $"Номер офиса: {internetOperator.PhoneNumberOffice}\n" +
                $"Рейтинг: {internetOperator.Score}\n" +
                $"Покрытие стран:\n{String.Join("\n", internetOperator.CountryCoverage)}");

            Console.WriteLine("\nВывод полей класса, c помощью метода:");
            Console.WriteLine($"Имя: {internetOperator.GetValue("NameOfTheOperator")}\n" +
                $"Цена: { internetOperator.GetValue("TheCostOfTheTariff")}\n" +
                $"Количество пользователей: {internetOperator.GetValue("NumberOfUsers") }\n" +
                $"Скорость интернета: {internetOperator.GetValue("InternetSpeed")}\n" +
                $"Номер офиса: {internetOperator.GetValue("PhoneNumberOffice")}\n" +
                $"Рейтинг: {internetOperator.GetValue("Score")}\n" +
                $"Покрытие стран:\n{internetOperator.GetValue("CountriesCoverage")}");
            Console.WriteLine("----------------------------------------------");
        }

        // Метод производящий проверку ввода значения
        private static string CheckInput(string pattern, string whatInput, string errorMassage)
        {
            string newPole;
            while (true) 
            {
                Console.Write(whatInput);
                newPole = Console.ReadLine();
                if (!Regex.IsMatch(newPole, @pattern))
                    Console.WriteLine(errorMassage);
                else return newPole;
            } 
        }

        // Метод, для создания объекта юзером
        private static void CreateObject()
        {
            string NameOfTheOperator;
            double TheCostOfTheTariff;
            int NumberOfUsers;
            double InternetSpeed;
            string PhoneNumberOffice;
            int Score;
            string CountryCoverage;

            Console.WriteLine("Создайте объект:");
            NameOfTheOperator = CheckInput("^[А-Яа-я]+$", "Введите название оператора => ", "Имя состоит только из русских букв");
            TheCostOfTheTariff = Convert.ToDouble(CheckInput("^[1-9][0-9]*[,]?[0-9]*$", "Введите цену тарифа => ", 
                "Цена - это целое или дробное (через ,) число"));
            NumberOfUsers = Convert.ToInt32(CheckInput("^[1-9][0-9]*$", "Введите число юзеров => ", "Только числа без ведущих нулей"));
            InternetSpeed = Convert.ToDouble(CheckInput("^[1-9][0-9]*.?[0-9]+$", "Введите скорость интернета => ",
                "Скорость - это целое или дробное (через ,) число"));
            PhoneNumberOffice = CheckInput("^[8][0-9]{10}$", "Введите номер офиса (с 8) => ", "Номер состоит из 11 цифр - первая 8");
            Score = Convert.ToInt32(CheckInput("^[0-5]{1}$", "Введите оценку юзеров (0-5) => ", "Число от 0 до 5"));
            CountryCoverage = CheckInput("^[А-Яа-я]{1,}$", "Введите страну покрытия оператора => ", " состоит только из русских букв");
            internetOperator = new InternetOperator(NameOfTheOperator, TheCostOfTheTariff, NumberOfUsers, InternetSpeed, PhoneNumberOffice, Score, CountryCoverage);

        }

        // Все возможности юзера
        public static void Opportunities()
        {
            Console.WriteLine("Лабораторная №1. Класс. Создание объекта. Работа с консолью.\n" +
                "Вариант №10 Грунин\n");
            CreateObject();
            do
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Что вы хотите сделать?\n" +
                    "0: Завершить;\n" +
                    "1: Вывести содержимое полей;\n" +
                    "2: Изменить значение поля\n" +
                    "3: Вывести поле в шестнадцатеричном представлении;");
                string action = CheckInput("^[0-3]{1}$", " Введите команду => ", "Команда - это цифра 0-31");
                Console.WriteLine("----------------------------------------------");
                switch (action)
                {
                    case "1":
                        PrintPole();
                        break;
                    case "2":
                        ToChange();
                        break;
                    case "0":
                        return;
                    case "3":
                        Console.WriteLine("Число пользователей в 16-ричной форме: "+ internetOperator.GetHexNumber());
                        break;
                }
            } while (true);
        }

        // Метод для изменения полей юзером
        public static void ToChange()
        {
            Console.WriteLine("Какое поле вы хотите изменить?");
            Console.WriteLine("1: NameOfTheOperator;\n" +
                "2: TheCostOfTheTariff;\n" +
                "3: NumberOfUsers;\n" +
                "4: InternetSpeed;\n" +
                "5: PhoneNumberOffice;\n" +
                "6: Score;\n" +
                "7: CountriesCoverage\n");
            string operation = CheckInput("^[0-7]{1}$", " Введите номер поля => ", "Цифра от 1 до 7");
            switch (operation)
            {
                case "1":
                    internetOperator.NameOfTheOperator = CheckInput("^[А-Яа-я]+$", "Введите новое имя => ", "Имя состоит только из русских букв");
                    break;
                case "2":
                    internetOperator.TheCostOfTheTariff = Convert.ToDouble(CheckInput("^[1-9][0-9]*[,]?[0-9]*$", "Введите новую цену тарифа => ",
               "Цена - это целое или дробное (через .) число"));
                    break;
                case "3":
                    internetOperator.NumberOfUsers = Convert.ToInt32(CheckInput("^[1-9][0-9]?$", "Введите новое число юзеров => ", "Только числа без ведущих нулей"));
                    break;
                case "4":
                    internetOperator.InternetSpeed = Convert.ToDouble(CheckInput("^[1-9][0-9]*.?[0-9]+$", "Введите новую скорость интернета => ",
                "Скорость - это целое или дробное (через .) число"));
                    break;
                case "5":
                    internetOperator.PhoneNumberOffice = CheckInput("^[8][0-9]{10}$", "Введите новый номер (с 8) => ", "Номер состоит из 11 цифр - первая 8");
                    break;
                case "6":
                    internetOperator.Score = Convert.ToInt32(CheckInput("^[0-5]{1}$", "Введите новую оценку (0-5) => ", "Число от 0 до 5"));
                    break;
                case "7":
                    internetOperator.CountryCoverage = CheckInput("^[А-Яа-я]{1,}$", "Введите новую страну покрытия => ", " состоит только из русских букв");
                    break;
            }
        }
    }
}
