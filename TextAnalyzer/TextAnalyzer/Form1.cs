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

        // ���������� ������� ��� ������ ������� ������
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("������� ����� ��� �������.");
                return;
            }

            // �������� ������� ���� � ������� ������ �� TextAnalyzer
            var wordFrequencies = textAnalyzer.GetWordFrequencies(text);

            // �������� ���������� � ������� ������ �� TextAnalyzer
            var statistics = textAnalyzer.GetTextStatistics(wordFrequencies);

            // ��������� ����� �� ����� � �������� ������
            lblTotalWords.Text = $"����� ���������� ����: {wordFrequencies.Values.Sum()}";
            lblAverageWordLength.Text = $"������� ����� �����: {statistics["������� ����� �����"]}";
            lblMaxWordLength.Text = $"������������ ����� �����: {statistics["������������ ����� �����"]}";
            lblUniqueWords.Text = $"���������� ���������� ����: {statistics["���������� ���������� ����"]}";
            lblVowelsCount.Text = $"������� ����: {statistics["������� ����"]}";
            lblConsonantsCount.Text = $"��������� ����: {statistics["��������� ����"]}";

            // ��������� ListView ����������� �� ������
            listViewStats.Items.Clear();

            // ��������� ������� �� �������
            var sortedWordFrequencies = wordFrequencies.OrderByDescending(w => w.Value).ToList();

            foreach (var word in sortedWordFrequencies)
            {
                listViewStats.Items.Add(new ListViewItem(new[] { word.Key, word.Value.ToString() }));
            }
        }

        // ���������� ������� ��� �������� ������ �� �����
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
                        MessageBox.Show($"������ ��� �������� �����: {ex.Message}");
                    }
                }
            }
        }

    }
}
