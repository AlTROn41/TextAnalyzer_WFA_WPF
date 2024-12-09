using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

using TextAnalyzerLibrary;  // Подключаем библиотеку

namespace TextAnalyzerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextAnalyzerLib textAnalyzer;

        public MainWindow()
        {
            InitializeComponent();
            textAnalyzer = new TextAnalyzerLib();  // Инициализируем объект для анализа текста
        }

        // Метод для загрузки текста из файла
        private void btnLoadText_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и настраиваем диалоговое окно для открытия файла
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";  // Ограничение на файлы с расширением .txt

            // Открываем диалоговое окно и проверяем, был ли выбран файл
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Используем метод из класса TextAnalyzer для загрузки текста
                    string text = textAnalyzer.LoadTextFromFile(openFileDialog.FileName);
                    txtInput.Text = text;  // Загружаем текст в текстовое поле
                }
                catch (Exception ex)
                {
                    // Обрабатываем ошибки, если они возникли при чтении файла
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                }
            }
        }

        // Метод для анализа текста
        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите текст для анализа.");
                return;
            }

            // Получаем частоту слов с помощью метода из TextAnalyzer
            var wordFrequencies = textAnalyzer.GetWordFrequencies(text);

            // Получаем статистику с помощью метода из TextAnalyzer
            var statistics = textAnalyzer.GetTextStatistics(wordFrequencies);

            // Обновляем метки на форме с анализом текста
            lblTotalWords.Content = $"Общее количество слов: {wordFrequencies.Values.Sum()}";
            lblAverageWordLength.Content = $"Средняя длина слова: {statistics["Средняя длина слова"]}";
            lblMaxWordLength.Content = $"Максимальная длина слова: {statistics["Максимальная длина слова"]}";
            lblUniqueWords.Content = $"Количество уникальных слов: {statistics["Количество уникальных слов"]}";
            lblVowelsCount.Content = $"Гласных букв: {statistics["Гласных букв"]}";
            lblConsonantsCount.Content = $"Согласных букв: {statistics["Согласных букв"]}";

            // Заполняем ListView статистикой по словам
            listViewStats.Items.Clear();

            // Сортируем словарь по частоте
            var sortedWordFrequencies = wordFrequencies.OrderByDescending(w => w.Value).ToList();

            foreach (var word in sortedWordFrequencies)
            {
                listViewStats.Items.Add(new { Word = word.Key, Frequency = word.Value });
            }
        }
    }
}