namespace TextAnalyzer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            btnAnalyze = new Button();
            btnLoadText = new Button();
            listViewStats = new ListView();
            WordColumn = new ColumnHeader();
            FrequencyColumn = new ColumnHeader();
            lblTotalWords = new Label();
            lblAverageWordLength = new Label();
            lblMaxWordLength = new Label();
            lblUniqueWords = new Label();
            lblVowelsCount = new Label();
            lblConsonantsCount = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(280, 13);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(771, 565);
            txtInput.TabIndex = 0;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(12, 12);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(131, 29);
            btnAnalyze.TabIndex = 1;
            btnAnalyze.Text = "Анализировать";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // btnLoadText
            // 
            btnLoadText.Location = new Point(149, 12);
            btnLoadText.Name = "btnLoadText";
            btnLoadText.Size = new Size(125, 29);
            btnLoadText.TabIndex = 2;
            btnLoadText.Text = "Загрузить текст";
            btnLoadText.UseVisualStyleBackColor = true;
            btnLoadText.Click += btnLoadText_Click;
            // 
            // listViewStats
            // 
            listViewStats.Columns.AddRange(new ColumnHeader[] { WordColumn, FrequencyColumn });
            listViewStats.Location = new Point(12, 47);
            listViewStats.Name = "listViewStats";
            listViewStats.Size = new Size(262, 638);
            listViewStats.TabIndex = 3;
            listViewStats.UseCompatibleStateImageBehavior = false;
            listViewStats.View = View.Details;
            // 
            // WordColumn
            // 
            WordColumn.Text = "Слово";
            WordColumn.Width = 150;
            // 
            // FrequencyColumn
            // 
            FrequencyColumn.Text = "Частота";
            FrequencyColumn.Width = 100;
            // 
            // lblTotalWords
            // 
            lblTotalWords.AutoSize = true;
            lblTotalWords.Location = new Point(441, 591);
            lblTotalWords.Name = "lblTotalWords";
            lblTotalWords.Size = new Size(191, 20);
            lblTotalWords.TabIndex = 4;
            lblTotalWords.Text = "Общее количество слов: 0";
            // 
            // lblAverageWordLength
            // 
            lblAverageWordLength.AutoSize = true;
            lblAverageWordLength.Location = new Point(441, 630);
            lblAverageWordLength.Name = "lblAverageWordLength";
            lblAverageWordLength.Size = new Size(173, 20);
            lblAverageWordLength.TabIndex = 5;
            lblAverageWordLength.Text = "Средняя длина слова: 0";
            // 
            // lblMaxWordLength
            // 
            lblMaxWordLength.AutoSize = true;
            lblMaxWordLength.Location = new Point(441, 665);
            lblMaxWordLength.Name = "lblMaxWordLength";
            lblMaxWordLength.Size = new Size(218, 20);
            lblMaxWordLength.TabIndex = 6;
            lblMaxWordLength.Text = "Максимальная длина слова: 0";
            // 
            // lblUniqueWords
            // 
            lblUniqueWords.AutoSize = true;
            lblUniqueWords.Location = new Point(685, 591);
            lblUniqueWords.Name = "lblUniqueWords";
            lblUniqueWords.Size = new Size(228, 20);
            lblUniqueWords.TabIndex = 7;
            lblUniqueWords.Text = "Количество уникальных слов: 0";
            // 
            // lblVowelsCount
            // 
            lblVowelsCount.AutoSize = true;
            lblVowelsCount.Location = new Point(685, 630);
            lblVowelsCount.Name = "lblVowelsCount";
            lblVowelsCount.Size = new Size(116, 20);
            lblVowelsCount.TabIndex = 8;
            lblVowelsCount.Text = "Гласных букв: 0";
            // 
            // lblConsonantsCount
            // 
            lblConsonantsCount.AutoSize = true;
            lblConsonantsCount.Location = new Point(685, 665);
            lblConsonantsCount.Name = "lblConsonantsCount";
            lblConsonantsCount.Size = new Size(133, 20);
            lblConsonantsCount.TabIndex = 9;
            lblConsonantsCount.Text = "Согласных букв: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 697);
            Controls.Add(lblConsonantsCount);
            Controls.Add(lblVowelsCount);
            Controls.Add(lblUniqueWords);
            Controls.Add(lblMaxWordLength);
            Controls.Add(lblAverageWordLength);
            Controls.Add(lblTotalWords);
            Controls.Add(listViewStats);
            Controls.Add(btnLoadText);
            Controls.Add(btnAnalyze);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnAnalyze;
        private Button btnLoadText;
        private ListView listViewStats;
        private ColumnHeader WordColumn;
        private ColumnHeader FrequencyColumn;
        private Label lblTotalWords;
        private Label lblAverageWordLength;
        private Label lblMaxWordLength;
        private Label lblUniqueWords;
        private Label lblVowelsCount;
        private Label lblConsonantsCount;
    }
}
