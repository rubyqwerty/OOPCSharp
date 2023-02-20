using System;
using System.Collections.Generic;

namespace Lab_OOP
{
    public class InternetOperator
    {
        public string NameOfTheOperator { get;  set; }
        public double TheCostOfTheTariff { get; set; }
        public int NumberOfUsers { get; set; }
        public double InternetSpeed { get; set; }
        public string PhoneNumberOffice { get; set; }
        public int Score { get; set; }
        public string CountryCoverage { get; set; }

        // Конструктор по умолчанию
        public InternetOperator()
        {
            NameOfTheOperator = "";
            TheCostOfTheTariff = 0;
            NumberOfUsers = 0;
            InternetSpeed = 0;
            PhoneNumberOffice = "";
            Score = 0;
            CountryCoverage = "";
        }

        // Конструктор с одним параметром
        public InternetOperator(string _NameOfTheOperator)
        {
            NameOfTheOperator = _NameOfTheOperator;
        }

        // Конструктор с двумя параметрами
        public InternetOperator(string _NameOfTheOperator, double _TheCostOfTheTariff)
        {
            NameOfTheOperator = _NameOfTheOperator;
            TheCostOfTheTariff = _TheCostOfTheTariff;
        }

        // Конструктор с 7 параметрами
        public InternetOperator(string _NameOfTheOperator, double _TheCostOfTheTariff,
            int _NumberOfUsers, double _InternetSpeed, string _PhoneNumberOffice,
            int _Score, string _CountriesCoverage)
        {
            NameOfTheOperator = _NameOfTheOperator;
            TheCostOfTheTariff = _TheCostOfTheTariff;
            NumberOfUsers = _NumberOfUsers;
            InternetSpeed = _InternetSpeed;
            PhoneNumberOffice = _PhoneNumberOffice;
            Score = _Score;
            CountryCoverage = _CountriesCoverage;
        }

        // Переопределение метода ToString() для вывода всех полей класса
        public override string ToString()
        {
            return $"Имя: {NameOfTheOperator}\n" +
                $"Цена: { TheCostOfTheTariff}\n" +
                $"Количество пользователей: {NumberOfUsers}\n" +
                $"Скорость интернета: {InternetSpeed}\n" +
                $"Номер офиса: {PhoneNumberOffice}\n" +
                $"Рейтинг: {Score}\n" +
                $"Покрытие стран:\n{CountryCoverage}";
        }

        // Метод, возвращающий значение определенного поля
        public string GetValue(string name)
        {
            switch (name)
            {
                case "NameOfTheOperator":
                    return $"{NameOfTheOperator}";
                case "TheCostOfTheTariff":
                    return $"{TheCostOfTheTariff}";
                case "NumberOfUsers":
                    return $"{NumberOfUsers}";
                case "InternetSpeed":
                    return $"{InternetSpeed}";
                case "PhoneNumberOffice":
                    return $"{PhoneNumberOffice}";
                case "Score":
                    return $"{Score}";
                case "CountriesCoverage":
                    return $"{CountryCoverage}";
                default:
                    return "";
            }
        }

        // Метод, возвращающий числовое поле в 16-ричной форме
        public string GetHexNumber()
        {
            return Convert.ToString(NumberOfUsers, 16);
        }

        
    }
}