using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyzerLibrary
{
    public class TextAnalyzerLib
    {
        private List<string> StopWords = new List<string> { "и", "в", "на", "с", "по", "для", "к", "из", "для", "за" };

        // Метод для подсчета частоты слов в тексте с фильтрацией стоп-слов
        public Dictionary<string, int> GetWordFrequencies(string text)
        {
            // Убираем знаки препинания и приводим текст к нижнему регистру
            var cleanedText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray()).ToLower();

            // Разбиваем текст на слова
            var words = cleanedText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Фильтруем стоп-слова
            words = words.Where(word => !StopWords.Contains(word)).ToArray();

            // Подсчитываем частоту слов
            var wordFrequencies = words
                .GroupBy(word => word)
                .ToDictionary(g => g.Key, g => g.Count());

            return wordFrequencies;
        }

        // Метод для получения статистики по тексту
        public Dictionary<string, string> GetTextStatistics(Dictionary<string, int> wordFrequencies)
        {
            var statistics = new Dictionary<string, string>();

            // Средняя длина слова
            double averageWordLength = wordFrequencies.Keys.Average(word => word.Length);

            // Округление средней длины слова до целого числа
            int roundedAverageWordLength = (int)Math.Round(averageWordLength);

            statistics["Средняя длина слова"] = roundedAverageWordLength.ToString();

            // Максимальная длина слова
            int maxWordLength = wordFrequencies.Keys.Max(word => word.Length);
            statistics["Максимальная длина слова"] = maxWordLength.ToString();

            // Количество уникальных слов
            statistics["Количество уникальных слов"] = wordFrequencies.Count.ToString();

            // Подсчет гласных и согласных
            int vowelsCount = CountVowels(wordFrequencies.Keys);
            int consonantsCount = CountConsonants(wordFrequencies.Keys);

            statistics["Гласных букв"] = vowelsCount.ToString();
            statistics["Согласных букв"] = consonantsCount.ToString();

            return statistics;
        }

        // Подсчет гласных букв
        private int CountVowels(IEnumerable<string> words)
        {
            string vowels = "аеёиоуыэюя";
            return words.Sum(word => word.Count(c => vowels.Contains(c)));
        }

        // Подсчет согласных букв
        private int CountConsonants(IEnumerable<string> words)
        {
            string consonants = "бвгджзклмнпрстфхцчшщ";
            return words.Sum(word => word.Count(c => consonants.Contains(c)));
        }

        // Метод для загрузки текста из файла
        public string LoadTextFromFile(string filePath)
        {
            try
            {
                return System.IO.File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении файла: " + ex.Message);
            }
        }
    }
}
