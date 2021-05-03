using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork17
{   public static class StringExtensions
    {
        // МЕТОДЫ РАСШИРЕНИЯ
        public static string Capitalaise(this string str)
        {
            List<string> newWords = new List<string>();
            var words = str.Split(" ");
            foreach (var word in words)
            {
                
                var firstLetter = word[0].ToString().ToUpper();
                var newWord = firstLetter + word.Substring(1);
                newWords.Add(newWord);
            }
            return string.Join(" ", newWords);
        }

        public static string ToPriceString(this decimal amount)
        {
            string amountStr = Math.Round(amount,2).ToString();
            var result = amountStr.Split(',');
            return $"{result[0]}$  {result[1]}cents";
        }
    }
    
    class Program
    {
        
        static void Main(string[] args)
        {

            //Реализовать следующие методы расширения для типов данных:
            //String: Capitalize - заменить первую букву на заглавную во всех словах строки
            //Decima: ToPriceString  1.453-> “1 руб. 45 коп. ”

            string str = "список учеников";
            Console.WriteLine(str.Capitalaise());

            decimal amount = 789.987m;
            Console.WriteLine(amount.ToPriceString());


            //Исходный список разбить на несколько списков длины N.

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<List<int>> resultList = new List<List<int>>();
            int pageSize = 3;
            for (int i = 0; i < numbers.Count/pageSize; i++)
            {
                var result = numbers.Skip(i * pageSize).Take(pageSize).ToList();
                Console.WriteLine(string.Join(", ", result));
                resultList.Add(result);
            }



            //Подсчитать количество предлогов в строке
            string[] arrPrepositions = { "над", "под", "на", "за", "по" };
            string sourceString = "Над пропостью, под скалой, За лесом, за горой";
            var words = sourceString.ToLower().Split(' ', '.', ',');
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (arrPrepositions.Contains(word))
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                    else
                    {
                        dict.Add(word, 1);
                    }
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            //В двумерном квадратном массиве все отрицательные числа выше главной диагонали заменить
            //на положительные (*-1), а все положительные ниже главной диагонали заменить на отрицательные (*-1)

            int[,] array = new int[4, 4]
            {
                {-2,5,-4,6 },
                {1,-3,5,-7 },
                {-3,4,-6,9 },
                {2,-5,7,-8 }
            };

            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= array.GetUpperBound(1); j++)
                {
                    array[i, j] = i == j ? array[i, j] : (i < j ? 1 : -1) * Math.Abs(array[i, j]);
                    Console.Write($"{array[i, j]} ");

                }
                Console.WriteLine();
            }

        }
    }
}
