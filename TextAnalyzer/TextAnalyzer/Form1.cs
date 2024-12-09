using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TextAnalyzerLibrary;

namespace TextAnalyzer
{
    public partial class Form1 : Form
    {
        private TextAnalyzerLib textAnalyzer;

        public Form1()
        {
            InitializeComponent();
            textAnalyzer = new TextAnalyzerLib();
        }

        // Обработчик события для кнопки анализа текста
        private void btnAnalyze_Click(object sender, EventArgs e)
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
            lblTotalWords.Text = $"Общее количество слов: {wordFrequencies.Values.Sum()}";
            lblAverageWordLength.Text = $"Средняя длина слова: {statistics["Средняя длина слова"]}";
            lblMaxWordLength.Text = $"Максимальная длина слова: {statistics["Максимальная длина слова"]}";
            lblUniqueWords.Text = $"Количество уникальных слов: {statistics["Количество уникальных слов"]}";
            lblVowelsCount.Text = $"Гласных букв: {statistics["Гласных букв"]}";
            lblConsonantsCount.Text = $"Согласных букв: {statistics["Согласных букв"]}";

            // Заполняем ListView статистикой по словам
            listViewStats.Items.Clear();

            // Сортируем словарь по частоте
            var sortedWordFrequencies = wordFrequencies.OrderByDescending(w => w.Value).ToList();

            foreach (var word in sortedWordFrequencies)
            {
                listViewStats.Items.Add(new ListViewItem(new[] { word.Key, word.Value.ToString() }));
            }
        }

        // Обработчик события для загрузки текста из файла
        private void btnLoadText_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        string text = textAnalyzer.LoadTextFromFile(filePath);
                        txtInput.Text = text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                    }
                }
            }
        }

    }
}
